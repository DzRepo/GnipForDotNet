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

        public delegate void FileDownloadComplete(object sender, string fileName);
        public event FileDownloadComplete DownloadComplete;

        protected virtual void OnDownloadComplete(string fileName)
        {
            if (DownloadComplete != null)
                DownloadComplete(this, fileName);
        }

        public string Create(HptJobInfo job)
        {
            ErrorState = false;
            return null;

        }

        public string GetStatus(string uuid)
        {
            ErrorState = false;
            return null;
        }

        public HptJobInfo Accept(string uuid)
        {
            return UpdateJob(uuid, AcceptJson);
            
        }

        public HptJobInfo Reject(string uuid)
        {
            return UpdateJob(uuid, RejectJson);
        }

        private HptJobInfo UpdateJob(string uuid, string toStatus)
        {
            ErrorState = false;

            try
            {
                string jsonResponse = "";
                var responseCode = Utilities.Restful.GetRestResponse(
                    "PUT",
                    jobURL(uuid),
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

        public string GetResults(string uuid)
        {
            ErrorState = false;
            return null;
        }

        
        // In an ideal world, this would be an asychronous call, and would call a callback when the data was ready.

        public List<HptJobInfo> GetJobs()
        {
            ErrorState = false;

            try
            {
                var jsonResponse = "";
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
                    // parse out and capture uuid for each record
                    foreach (var job in JobList)
                    {
                        Debug.WriteLine("JobID:" + job.uuid);
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

                            //var uStart = job.jobURL.LastIndexOf(@"jobs") + 5;
                            //var uEnd = job.jobURL.LastIndexOf(@".json");
                            //job.uuid = job.jobURL.Substring(uStart, uEnd - uStart);
                           
                        }
                    }
                            }
                    catch (Exception)
                    {
                        Debug.WriteLine("jsonResponse:" + jsonResponse);
                    }
                    return JobList;
                }
                // If we're here... something has gone wrong...
                ErrorState = true;
                ErrorMessage = "Response returned: " + responseCode.ToString();
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
        private string jobURL(string uuid)
        {
            return "https://historical.gnip.com:443/accounts/" + AccountName + "/publishers/twitter/historical/track/jobs/"+ uuid + ".json";

        }


        private async Task<int> DownloadFile(string url, string DestinationFolder, string title, int fileNumber)
        {
            Debug.WriteLine("Downloading file# " + fileNumber);
            WebClient myWebClient = new WebClient();
            
            var fileName = title + "-File" + fileNumber.ToString().PadLeft(6, "0".ToCharArray()[0]) + ".gz";
            var localFileName = DestinationFolder + @"\" + fileName;

            if (!System.IO.File.Exists(localFileName)) 
            await myWebClient.DownloadFileTaskAsync(url, localFileName);
            // need to send an event to cross threads and free UI thread.  "Starting download of file..."
            return fileNumber;
        }

 
        public void StartDownload(string uuid, string DestinationFolder)
        {
            ThreadPool.SetMaxThreads(500, 500);
            var jobToDownload = JobList.Where(info => info.uuid == uuid).FirstOrDefault();

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
                    for (var index = 0; index < jobResultData.urlCount; index = index + 500)
                    {
                        var maxIndex = index + 500;
                        if (index > jobResultData.urlCount) maxIndex = jobResultData.urlCount;

                        Debug.WriteLine("Outerloop: index is " + index);
                        Task<int> x = null;
                        for (var innerIndex = index; innerIndex < maxIndex; innerIndex++)
                        {
                            x = DownloadFile(
                                jobResultData.urlList[innerIndex],
                                DestinationFolder,
                                jobToDownload.title,
                                innerIndex);
                            
                        }
                        int threadCount;
                        int completionPortThreads;
                        ThreadPool.GetAvailableThreads(out threadCount, out completionPortThreads);
                        while (threadCount < 500)
                        {
                            // wait 10 seconds?
                            Thread.Sleep(10000);
                            ThreadPool.GetAvailableThreads(out threadCount, out completionPortThreads);
                            Debug.WriteLine("TC:" + threadCount + "  comPT:" + completionPortThreads);
                        }
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
