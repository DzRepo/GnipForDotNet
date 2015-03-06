using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.PowerTrack.Stream
{
    public class ActivityStream
    {
        public string AccountName { get; set; }
        public string StreamName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public long ActivityCount { get; set; }
        public long TotalActivityJsonSize { get; set; }

        private bool stopRequested = false;
        private HttpWebRequest request;
        private AsyncCallback asyncCallback;

        public delegate void ActivityReceived(object sender, Activity activity);
        public event ActivityReceived Received;

        public delegate void ActivityException(object sender, Exception ex);
        public event ActivityException ActitivityEx;

        public delegate void ForcedDisconnect(object sender);
        public event ForcedDisconnect ForcedDisconnectEvent;

        private CounterCreationDataCollection counters = new CounterCreationDataCollection();

        private static string GnipPerformanceCategory = "Gnip PowerTrack Stream";
        private static string GnipActivitiesPerSec = "Activities / sec";
        private static string GnipPayloadSize = "Activity Length";

        public ActivityStream()
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

                var payloadSize = new CounterCreationData
                {
                    CounterName = GnipPayloadSize,
                    CounterHelp = "Size of last Activity Record in JSON format, in bytes",
                    CounterType = PerformanceCounterType.NumberOfItems32
                };
                counters.Add(payloadSize);

                PerformanceCounterCategory.Create(GnipPerformanceCategory,"Performance data related to Gnip Powertrack Stream Activity"
                    , 
                    PerformanceCounterCategoryType.MultiInstance,
                    counters);
            }
        }

        protected virtual void OnRecieved(Activity activity)
        {
            ActivityCount++;
            if (Received != null)
                Received(this, activity);
        }

 
        protected virtual void OnActivityEx(Exception ex)
        {
            if (ActitivityEx != null)
                ActitivityEx(this, ex);
        }

        protected virtual void OnForcedDisconnectEvent()
        {
            if (!stopRequested)
            {
                if (ForcedDisconnectEvent != null)
                    ForcedDisconnectEvent(this);

                Debug.WriteLine("Processing Forced disconnect");
                // Disconnect();  // trigger stop of current request
                // Thread.CurrentThread.Abort(); // Kill myself
                Debug.WriteLine("Reconnecting after disconnect");
                // restart
            }
        }

        private void HandleResult(IAsyncResult result)
        {
            var activitiesPerSec = new PerformanceCounter(GnipPerformanceCategory,GnipActivitiesPerSec,StreamName,false)
            {
                MachineName = ".",
                RawValue = 0,
            };

            var payloadAverage = new PerformanceCounter(GnipPerformanceCategory, GnipPayloadSize, StreamName, false)
            {
                MachineName = ".",
                RawValue = 0,
            };

            while (!stopRequested)
            {
                Debug.WriteLine("Stop not requested (top)");
                try
                {
                    request = (HttpWebRequest) result.AsyncState;
                    {
                        Debug.WriteLine("request created");
                        var response = (HttpWebResponse) request.EndGetResponse(result);
                        try
                        {
                            Debug.WriteLine("response created");
                            var stream = response.GetResponseStream();
                            try
                            {
                                Debug.WriteLine("stream created");
                                var memory = new MemoryStream();
                                try
                                {
                                    Debug.WriteLine("memory created");
                                    var gzip = new GZipStream(memory, CompressionMode.Decompress);
                                    var bufferSize = 8124;
                                    try
                                    {
                                        Debug.WriteLine("gzipstream created");
                                        
                                        var readBuffer = new byte[bufferSize];
                                        
                                        //   List<byte> output = new List<byte>();

                                        if (stream == null || !stream.CanRead)
                                        {
                                            Debug.WriteLine(" --- Cannot Read Stream");
                                            OnActivityEx(new Exception("Fatal error: Stream cannot be opened."));
                                        }
                                        else
                                        {
                                            var results = new StringBuilder("");

                                            while (stream.CanRead & !stopRequested)
                                            {
                                                try
                                                {

                                                    var readCount = stream.Read(readBuffer, 0, readBuffer.Length);
                                                    if (readCount == 0)
                                                    {
                                                        OnActivityEx(new Exception("Stream Read failed.  Restarting."));
                                                        // Stream read error.  Force abort.
                                                        OnForcedDisconnectEvent();
                                                    }
                                                    var readBufferAsString = Encoding.Default.GetString(readBuffer);

                                                    // add decompressed string to results string, which may have leftover bits from last read.
                                                    results.Append(readBufferAsString);
                                                    
                                                    // split up results into an array of rows that can be parsed
                                                    var resArray = results.ToString()
                                                        .Split(new[] {Environment.NewLine}, 
                                                        new StringSplitOptions());

                                                    // Debug.WriteLine("ResArray is " + resArray.Count() + " row long");
                                                    for (var index = 0; index < resArray.Count(); index++)
                                                    {
                                                        var resultRow = resArray[index];
                                                        if (resultRow.Length == 0) Debug.WriteLine("KeepAlive detected.");
                                                        else
                                                        {
                                                            if (resultRow.StartsWith(@"{""id""") &&
                                                                resultRow.EndsWith(@"}}"))
                                                                // does it look like we have a complete activity JSON object?
                                                                try
                                                                {
                                                                    var activity =JsonConvert.DeserializeObject<Activity>(resultRow);
                                                                    OnRecieved(activity);
                                                                    activitiesPerSec.Increment();
                                                                    TotalActivityJsonSize += resultRow.Length;
                                                                    // var averageSize = Convert.ToInt32(TotalActivityJSONSize / ActivityCount);
                                                                    payloadAverage.RawValue = resultRow.Length;
                                                                    // Debug.WriteLine("Average Payload Size: " + AverageSize );
                                                                    // bufferSize = averageSize * 2;
                                                                }
                                                                catch (JsonSerializationException jsEx)
                                                                {
                                                                    // add back the incomplete contents for future processing
                                                                    // Debug.Write("decode error: in row " + index + " : " + jsEx.Message);

                                                                    // if it's the last line of the array, assume incomplete block and reset results string to contents of line.
                                                                    if (index == resArray.Count() - 1)
                                                                    {
                                                                       // Debug.Write("on last row - passing data forward ");
                                                                        results.Clear();
                                                                        results.Append(resultRow);
                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    OnActivityEx(ex);
                                                                    Debug.Write("Failed to process row " + index + " " + resultRow);
                                                                }
                                                            else
                                                            {
                                                                if (resultRow.StartsWith(@"{""error"":"))
                                                                {
                                                                    var jsonError = JsonConvert.DeserializeObject<Error>(resultRow);
                                                                    ActitivityEx(this, new Exception("Stream Error Received:" + jsonError.message));
                                                                    OnForcedDisconnectEvent();
                                                                }
                                                                else
                                                                // Debug.WriteLine("Incomplete data in row: " + index + " " + resultRow);
                                                                if (index == resArray.Count() - 1)
                                                                {
                                                                    // Debug.WriteLine("Last row - Passing data forward ");
                                                                    results.Clear();
                                                                    results.Append(resultRow);
                                                                }
                                                            }
                                                        } // valid record
                                                    }
                                                } // end try
                                                catch (IOException ioEx)
                                                {
                                                    OnActivityEx(ioEx);
                                                    Debug.WriteLine("IO Exception in stream processing: " + ioEx.Message);
                                                    OnForcedDisconnectEvent();
                                                }
                                                catch (WebException wEx)
                                                {
                                                    OnActivityEx(wEx);
                                                    Debug.WriteLine("Web Exception stream processing: " + wEx.Message);
                                                }
                                                catch (InvalidOperationException ioEx)
                                                {
                                                    // This should be where "read timeout errors" end up - 
                                                    // for example, network latency or disconnects are preventing heartbeats from arriving.
                                                    Debug.WriteLine("Invalid Operation Error:" + ioEx.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    OnActivityEx(ex);
                                                    Debug.WriteLine("Error in stream processing: " + ex.Message);
                                                    OnForcedDisconnectEvent();
                                                }
                                                
                                                // reset position to 0
                                                memory.SetLength(0);
                                                // Debug.WriteLine("Stop = " + stopRequested.ToString());
                                            } // end while
                                        }
                                    } // stream is not null and is readable 
                                    catch (Exception ex)
                                    {
                                        OnActivityEx(ex);
                                        Debug.WriteLine("Error in gzip processing: " + ex.Message);
                                        OnForcedDisconnectEvent();
                                    }
                                    finally
                                    {
                                        Debug.WriteLine("Disposing of gzip object");
                                        gzip.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    OnActivityEx(ex);
                                    Debug.WriteLine("Error in memory stream processing: " + ex.Message);
                                    OnForcedDisconnectEvent();
                                }
                                finally
                                {
                                    Debug.WriteLine("Disposing of memory object");
                                    ((IDisposable) memory).Dispose();
                                }
                            }
                            catch (Exception ex)
                            {
                                OnActivityEx(ex);
                                Debug.WriteLine("Error in stream processing: " + ex.Message);
                                OnForcedDisconnectEvent();
                            }
                            finally
                            {
                                Debug.WriteLine("Disposing of stream object");
                                if (stream != null) ((IDisposable) stream).Dispose();
                            }
                        } // end response object
                        catch (Exception ex)
                        {
                            OnActivityEx(ex);
                            Debug.WriteLine("Error in response object: " + ex.Message);
                            OnForcedDisconnectEvent();
                        }
                        finally
                        {
                            Debug.WriteLine("Disposing of response object");
                            ((IDisposable) response).Dispose();
                        }
                    }
                } // try
                catch (Exception ex) // catchall exception handler
                {
                    OnActivityEx(ex);
                    Debug.WriteLine("General Error: " + ex.Message);
                    OnForcedDisconnectEvent();
                }
            } // while
        } // end of HandleResult

        public void Connect()
        {
            if (request != null)
            {
                // clean up if necessary
                request.Abort();
                request = null;
            }

            var powerTrackUrl = @"https://stream.gnip.com:443/accounts/" + AccountName + "/publishers/twitter/streams/track/" + StreamName + ".json";

            request = (HttpWebRequest)WebRequest.Create(powerTrackUrl);
            request.Method = "GET";

            var authInfo = string.Format("{0}:{1}", Username, Password);
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers.Add("Authorization", "Basic " + authInfo);

            stopRequested = false;
            
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Headers.Add("Accept-Encoding", "gzip");
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = 30000;

            request.Timeout = 10; //seconds, PowerTrack sends 15-second heartbeat.
            asyncCallback = HandleResult;    //Setting handleResult as Callback method...
            request.BeginGetResponse(asyncCallback, request);    //Calling BeginGetResponse on request...
        }


        public void Disconnect()
        {
            //Note that this sends a signal to the streaming method to stop, so some there may be a delay in execution.
            stopRequested = true;
        }
    } // end of ActivityStream

} // end of namespace
