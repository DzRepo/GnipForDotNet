using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.Powertrack.Historical
{
    public class HptJob
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool ErrorState { get; set; }
        public string ErrorMessage { get; set; }
        public List<HptJobInfo> JobList;

        const string AcceptJson = @"{""status"":""accept""}";
        const string RejectJson = @"{""status"":""reject""}";

        public delegate void FileDownloadComplete(object sender, int fileNumber);
        public event FileDownloadComplete DownloadComplete;

        protected virtual void OnDownloadComplete(int fileNumber)
        {
            if (DownloadComplete != null)
                DownloadComplete(this, fileNumber);
        }

        public string Create(HptJobInfo job)
        {
            ErrorState = false;
            return null;

        }

        public string GetStatus(string job_uuid)
        {
            ErrorState = false;
            return null;
        }

        public HptJobInfo Accept(string job_uuid)
        {
            return UpdateJob(job_uuid, AcceptJson);
            
        }

        public HptJobInfo Reject(string job_uuid)
        {
            return UpdateJob(job_uuid, RejectJson);
        }

        private HptJobInfo UpdateJob(string job_uuid, string toStatus)
        {
            ErrorState = false;

            try
            {
                string jsonResponse = "";
                var responseCode = Utilities.Restful.GetRestResponse(
                    "PUT",
                    jobURL(job_uuid),
                    Username,
                    Password,
                    out jsonResponse,
                    toStatus);

                var jobDetails = JsonConvert.DeserializeObject<HptJobInfo>(jsonResponse);
                return jobDetails;
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
            }

            return null;
        }

        public string GetResults(string job_uuid)
        {
            ErrorState = false;
            return null;
        }

        
        // In an ideal world, this would be an asychronous call, and would call a callback when the data was ready.

        public List<HptJobInfo> GetJobs()
        {
            ErrorState = false;
            string jsonResponse = "";
            List<HptJobInfo> returnValue = null;
            
            try
            {
                var responseCode = Utilities.Restful.GetRestResponse(
                    "GET", 
                    jobStatusURL(), 
                    Username, 
                    Password, 
                    out jsonResponse);

                if (responseCode == HttpStatusCode.OK)
                { 
                    try
                            {
                    var JobObject = JsonConvert.DeserializeObject<HptJobHeader>(jsonResponse);

                    JobList = new List<HptJobInfo> (JobObject.jobs);
                    // parse out and capture job_uuid for each record
                    foreach (var job in JobList)
                    {
                        Debug.WriteLine("JobID:" + job.job_uuid);
                        Debug.WriteLine("expiresAt:" + job.expiresAt);
                        if (job.results != null) Debug.WriteLine("results.expiresAt:" + job.results.expiresAt);
                        if (job.quote != null) Debug.WriteLine("quote.expiresAt:" + job.quote.expiresAt);
                        
                        if (job.jobURL != "")
                        {
                            var jsonJobDetail = "";
                            
                            var detailResponseCode = Utilities.Restful.GetRestResponse(
                                "GET",
                                job.jobURL,
                                Username,
                                Password,
                                out jsonJobDetail);

                            if (detailResponseCode == HttpStatusCode.OK)
                            {
                                try
                                {
                                    var JobDetail = JsonConvert.DeserializeObject<HptJobInfo>(jsonJobDetail);
                                    // job.expiresAt = JobDetail.expiresAt;
                                    job.percentComplete = JobDetail.percentComplete;
                                    job.statusMessage = JobDetail.statusMessage;
                                    job.fromDate = JobDetail.fromDate;
                                    job.toDate = JobDetail.toDate;
                                    job.fileCount = JobDetail.fileCount;
                                    job.quote = JobDetail.quote;
                                    job.results = JobDetail.results;

                                    Debug.WriteLine("detail.expiresAt:" + JobDetail.expiresAt);
                                    if (JobDetail.quote != null) Debug.WriteLine("detail.quote.expiresAt:" + JobDetail.quote.expiresAt);
                                    if (JobDetail.results!= null) Debug.WriteLine("detail.results.expiresAt:" + JobDetail.results.expiresAt);
                        
                                    if (job.status == "finished")
                                        job.expiresAt = JobDetail.results.expiresAt;
                                    if (job.status == "quoted")
                                        job.expiresAt = JobDetail.quote.expiresAt;
                                }
                                catch (Exception)
                                {
                                    Debug.WriteLine("jsonJobDetail:" + jsonJobDetail);
                                }
                            }

                            var uStart = job.jobURL.LastIndexOf(@"jobs") + 5;
                            var uEnd = job.jobURL.LastIndexOf(@".json");
                            job.job_uuid = job.jobURL.Substring(uStart, uEnd - uStart);
                           
                        }
                    }
                            }
                    catch (Exception)
                    {
                        Debug.WriteLine("jsonResponse:" + jsonResponse);
                    }
                    return JobList;
                }
                else
                {
                    ErrorState = true;
                    ErrorMessage = "Response returned: " + responseCode.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
            }
            return null;
        }

        private string jobStatusURL()
        {
            return "https://historical.gnip.com:443/accounts/" + AccountName + "/jobs.json";

        }
        private string jobURL(string job_uuid)
        {
            return "https://historical.gnip.com:443/accounts/" + AccountName + "/publishers/twitter/historical/track/jobs/"+ job_uuid + ".json";

        }


        private async Task DownloadFile(string url, string DestinationFolder, string title, int fileNumber)
        {
            WebClient myWebClient = new WebClient();
            var fileName = title + "-File" + fileNumber.ToString().PadLeft(6, "0".ToCharArray()[0]) + ".gz";
            var localFileName = DestinationFolder + @"\" + fileName;

            // don't redownload if stopped for whatever reason
            if (!System.IO.File.Exists(localFileName)) 
                 await myWebClient.DownloadFileTaskAsync(url, localFileName);

            OnDownloadComplete(fileNumber);
            // need to send an event to cross threads and free UI thread.  "Starting download of file..."
        }
        public void StartDownload(string job_uuid, string DestinationFolder)
        {
            var jobToDownload = JobList.Where(info => info.job_uuid == job_uuid).FirstOrDefault();

            var jsonResponse = "";
            try
            {
                var responseCode = Utilities.Restful.GetRestResponse(
                    "GET",
                    jobToDownload.results.dataURL,
                    Username,
                    Password,
                    out jsonResponse);
                if (responseCode == HttpStatusCode.OK)
                {
                    var jobResultData = JsonConvert.DeserializeObject<HptJobResultData>(jsonResponse);
                    Debug.WriteLine("Number of files to download: " + jobResultData.urlCount);
                    for (var index = 0; index < jobResultData.urlCount; index++)
                    {
                        var x = DownloadFile(jobResultData.urlList[index], DestinationFolder, jobToDownload.title, index);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Download: " + ex.Message);
            }
            //  call Rest API to get list of files.  Need to build Json class for filelist object array
            //    jobToDownload.results.dataURL
        }

    } // class
} // namespace
