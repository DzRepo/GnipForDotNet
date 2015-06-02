using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.Powertrack
{
    public class GnipStreamReader
    {
        // size of read block - larger is more efficient, but smaller is better for less active streams.  
        // 1600 is rough average size of activities.

        const int Blocksize = (25 * 1600);
       
        public delegate void Received(object sender, Activity activity);
        public event Received OnActivityReceived;

        public delegate void ReceivedJson(object sender, string activityJson);
        public event ReceivedJson OnJsonReceived;

        public delegate void Disconnected(object sender);
        public event Disconnected OnDisconnect;

        public delegate void ReaderException(object sender, ApplicationException ex);
        public event ReaderException OnReaderExeception;

        private HttpWebRequest _request;
        private AsyncCallback _asyncCallback;

        private string _streamName = "";
        private StringBuilder rawBlock = new StringBuilder();

        private char leftBracket = "{".ToCharArray()[0];
        private char rightBracket = "}".ToCharArray()[0];
                
        private double _activitiesReceived;

        public GnipStreamReader()
        {
            // Initialize Performance counters
            InitializeCounters();
        }

        private CounterCreationDataCollection counters = new CounterCreationDataCollection();

        private static string GnipPerformanceCategory = "Gnip PowerTrack Stream";
        private static string GnipActivitiesPerSec = "Activities / sec";
        private void InitializeCounters()
        {

            if (!PerformanceCounterCategory.Exists(GnipPerformanceCategory))
            {
                var counterData = new CounterCreationData
                {
                    CounterName = GnipActivitiesPerSec,
                    CounterHelp = "Number of Activities processed per second via the stream.  Note that this may be less than the stream rate, and is dependant upon processing efficiency.",
                    CounterType = PerformanceCounterType.RateOfCountsPerSecond32
                };

                counters.Add(counterData);

                PerformanceCounterCategory.Create(GnipPerformanceCategory, "Performance data related to Gnip Powertrack Stream Activity"
                    ,
                    PerformanceCounterCategoryType.MultiInstance,
                    counters);
            }
        }

        public bool Connect(
            string accountName,
            string userName,
            string password,
            string streamName)
        {

            // store stream name in class variable for use by performance counter
            _streamName = streamName;
            _shutDown = false;

            // form URL based on parameters
            var powerTrackUrl = 
                @"https://stream.gnip.com:443/accounts/" + 
                accountName + 
                "/publishers/twitter/streams/track/" + 
                streamName +
                ".json";

            _request = (HttpWebRequest)WebRequest.Create(powerTrackUrl);
            _request.Method = "GET";

            var authInfo = string.Format("{0}:{1}", userName, password);
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            _request.Headers.Add("Authorization", "Basic " + authInfo);

            // set stream parameters
            _request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            _request.Headers.Add("Accept-Encoding", "gzip");
            _request.Accept = "application/json";
            _request.ContentType = "application/json";
            _request.ReadWriteTimeout = 30000;
            _request.AllowReadStreamBuffering = false;

            _request.Timeout = 30; //seconds, PowerTrack sends 15-second heartbeat.
            _asyncCallback = HandleResult;    //Setting handleResult as Callback method...
            _request.BeginGetResponse(_asyncCallback, _request);    //Calling BeginGetResponse on 
            
            return true;
        }

        private bool _shutDown;
        public void Disconnect()
        {
            _shutDown = true;
        }
     
        private PerformanceCounter _activitiesPerSec;

        private void HandleResult(IAsyncResult result)
        {
            _activitiesPerSec = new PerformanceCounter(GnipPerformanceCategory, GnipActivitiesPerSec, _streamName, false)
            {
                MachineName = ".",
                RawValue = 0,
            };

            try
            {
                using (var response = (HttpWebResponse) _request.EndGetResponse(result))
                using (var stream = response.GetResponseStream())
                using (var memory = new MemoryStream())
                {
                    byte[] compressedBuffer = new byte[Blocksize];

                    if (stream != null && !stream.CanRead)
                    {
                        Debug.WriteLine(" --- Cannot Read Stream");
                        if (OnReaderExeception != null)
                            OnReaderExeception(this, new ApplicationException("Cannot Open Stream"));
                    }

                    while (stream != null && stream.CanRead)
                    {

                        try
                        {
                            int readCount = stream.Read(compressedBuffer, 0, compressedBuffer.Length);

                            // if readCount is 0, then the stream must have disconnected.  Process and abort!
                            if (readCount == 0)
                            {
                                if (OnDisconnect != null) OnDisconnect(this);
                                break;
                            }
                            var outputString = Encoding.UTF8.GetString(compressedBuffer);
                            ProcessBlock(outputString);
                        }
                        catch (Exception error)
                        {
                            if (OnReaderExeception != null)
                                OnReaderExeception(this, new ApplicationException(error.Message));
                        }
                        memory.SetLength(0);

                        // got signal to shut down.  Don't notify of disconnect.
                        if (_shutDown) break;
                    }
                    if (stream != null && !stream.CanRead)
                    {
                        if (OnReaderExeception != null)
                            OnReaderExeception(this, new ApplicationException("Can't Read Stream"));
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnReaderExeception != null) 
                    OnReaderExeception(this, new ApplicationException(ex.Message));
                // Notify the user app that the stream is dead.
                if (OnDisconnect != null) OnDisconnect(this);
            }
        }

        public double ActivityCount()
        {
            return _activitiesReceived;
        }

        /// <summary>
        /// Takes block of data that has been read from the stream and processes it into Activities
        /// </summary>
        /// <param name="outputString"></param>
        protected virtual void ProcessBlock(string outputString)
        {
            
            try
            {
                rawBlock.Append(outputString);

                // parse the block into an array of strings
                string[] rows = rawBlock.ToString().Split(new[] {Environment.NewLine}, new StringSplitOptions());
                rawBlock.Clear();  // reset rawBlock

                // process each line of the array
                for (var row = 0; row < rows.Length; row++)
                {
                    var rawText = rows[row];
                    if (rawText.Length > 0)
                    {
                        Activity activity;
                        if (TryDeserializeActivity(rawText, out activity))
                        {
                            try
                            {
                                if (OnActivityReceived != null) OnActivityReceived(this, activity);
                                if (OnJsonReceived != null) OnJsonReceived(this, rawText);

                                _activitiesPerSec.Increment();
                                _activitiesReceived ++;
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("General error in activity processing - row " + row + " of block " + rows.Length + " :" + rawText);
                                if (OnReaderExeception != null)
                                    OnReaderExeception(this, new ApplicationException("Activity processsing error:" + rawText + " message= " + ex.Message));
                            }
                        }
                        else
                        // not a valid Activity record
                        {
                            // is it the first or last row?  if so, pass it on to the next block.
                            if (row == (rows.Length - 1)) rawBlock.Append(rawText);

                            // otherwise surface as an exception
                            else
                            {
                                // unless it's the first row, which may contain incomplete data (the first time)
                                if (row != 0)
                                {
                                    Debug.WriteLine("Unknown text in line " + row + " of " + rows.Length + " :" + rawText);
                                    if (OnReaderExeception != null) OnReaderExeception(this, new ApplicationException(rawText));
                                }
                            }
                        }
                    }
                    else
                    {
                        // blank line?  should be a heart beat.  Usually first row.
                        Debug.WriteLine("*** Heartbeat on line " + row + " of " + rows.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unknown Error in streamreader:" + ex.Message);
                if (OnReaderExeception != null) OnReaderExeception(this, new ApplicationException(ex.Message));
            }
        }

        // determines if a row of text can be converted to an activity record, returning true if possible, false if exception generated.
        private bool TryDeserializeActivity(string rawText, out Activity activity)
        {
            // does it end in a }?  If not, return false instead of attempting deserialize
            if (rawText.EndsWith("}"))
            try
            {
                activity = JsonConvert.DeserializeObject<Activity>(rawText);
                return true;
            }
            catch (Exception) { }
            activity = null;
            return false;
        }
    }
}