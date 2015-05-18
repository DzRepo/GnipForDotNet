using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
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

        const int Blocksize = (10 * 1600);
       
        public delegate void Received(object sender, Activity activity);
        public event Received OnActivityReceived;

        public delegate void Disconnected(object sender);
        public event Disconnected OnDisconnect;

        public delegate void ReaderException(object sender, ApplicationException ex);
        public event ReaderException OnReaderExeception;

        private HttpWebRequest _request;
        private AsyncCallback _asyncCallback;

        private string _streamName = "";
        private StringBuilder rawBlock = new StringBuilder();
                
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
            _request.ReadWriteTimeout = 10000;
            _request.AllowReadStreamBuffering = false;

            _request.Timeout = 10; //seconds, PowerTrack sends 15-second heartbeat.
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
          

            using (HttpWebResponse response = (HttpWebResponse)_request.EndGetResponse(result))
            using (Stream stream = response.GetResponseStream())
            using (Stream memory = new MemoryStream())
            using (new GZipStream(memory, CompressionMode.Decompress))
            {
                byte[] compressedBuffer = new byte[Blocksize];
                // byte[] uncompressedBuffer = new byte[Blocksize];

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
                            OnReaderExeception(this,new ApplicationException(error.Message));
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

        public double ActivityCount()
        {
            return _activitiesReceived;
        }

        /// <summary>
        /// Takes block of data that has been read from the stream and processes it into Activities
        /// </summary>
        /// <param name="outputString"></param>
        private void ProcessBlock(string outputString)
        {
            
            try
            {
                rawBlock.Append(outputString);

                // parse the block into an array of strings
                string[] rows = rawBlock.ToString().Split(new[] {Environment.NewLine}, new StringSplitOptions());
                rawBlock.Clear();  // reset rawBlock

                // process each line of the array
                for (int row = 0; row < rows.Length; row++)
                {
                    var rawText = rows[row];
                    if (rawText.Length > 0)
                    {
                        // does it pass the basic test of a JSON Activity record?
                        if (rawText.StartsWith(@"{""id""") && rawText.EndsWith(@"}"))
                        {
                            try
                            {
                                Activity activity;
                                activity = JsonConvert.DeserializeObject<Activity>(rawText);
                                if (OnActivityReceived != null) OnActivityReceived(this, activity);
                                _activitiesPerSec.Increment();
                                _activitiesReceived ++;
                            }
                            catch (JsonException jsonException)
                            {
                                Debug.WriteLine("Deserialize not successful.");
                                // Didn't deserialize, so...  

                                // is it the last row?  if so, pass it forward.
                                if (row == (rows.Length - 1))
                                {
                                    Debug.WriteLine("incomplete block detected - passing data to next read");
                                    rawBlock.Append(rawText);
                                }
                                else
                                {
                                    Debug.WriteLine("JSON Deserialize error - Line " + row + " of " + rows.Length + " :" + rawText + " Message: " + jsonException.Message);
                                    // Otherwise, surface error.
                                    if (OnReaderExeception != null)
                                        OnReaderExeception(this, new ApplicationException("Json Deserialize error:" + rawText));
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("General error in deserialize - Line " + row + " of " + rows.Length + " :" + rawText);
                                if (OnReaderExeception != null)
                                    OnReaderExeception(this, new ApplicationException("Json Deserialize error:" + rawText + " message= " + ex.Message));
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
                                    if (OnReaderExeception != null)
                                        OnReaderExeception(this, new ApplicationException(rawText));
                                }
                            }
                        }
                    }
                    else
                    {
                        // blank line?  should be a heart beat.
                        Debug.WriteLine("*** Heartbeat on line " + row + " of " + rows.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unknown Error:" + ex.Message);
                if (OnReaderExeception != null) OnReaderExeception(this, new ApplicationException(ex.Message));
            }
        }
    }
}