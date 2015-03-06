using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gnip.Utilities.JsonClasses
{
    public class HptJobHeader
    {
        public HptJobsSummary delivered { get; set; }
        public HptJobInfo[] jobs;
    }

    public class HptJobsSummary
    {
        public int activityCount { get; set; }
        public int jobCount { get; set; }
        public int jobDaysRun { get; set; }
        public string period { get; set; }
        public string since { get; set; }
    }

    public class HptJobInfo
    {
        public string title { get; set; } // summary
        public string account { get; set; } // summary
        public string publisher { get; set; } // summary
        public string streamType { get; set; } // summary, put - must always be "track"
        public string dataFormat { get; set; } // put - must always be "activity-stream"
        public string format { get; set; }  // detail
        public string fromDate { get; set; }  // summary
        public string toDate { get; set; }  // summary
        public string requestedBy { get; set; }  // detail
        public string requestedAt { get; set; }  // detail
        public string status { get; set; }  // summary, detail - "accepted, opened, estimating, quoted, running, rejected, delivered"
        public string statusMessage { get; set; }
        public int fileCount { get; set; }
        public DateTime expiresAt { get; set; }  // summary
        public string jobURL { get; set; }
        public HptJobQuote quote { get; set; }  // detail after estimate
        public int percentComplete { get; set; }  // summary
        public Rule[] rules { get; set; }  // put - rules for searching - max of 1000
        public string job_uuid { get; set; }  // this data is not currently passed directly via Json, but is parsed out of jobURL when available
        public HptJobResult results { get; set; }  // detail
    }

    public class HptJobResult
    {
        public DateTime completedAt { get; set; }
        public int activityCount { get; set; }
        public int fileCount { get; set; }
        public Single fileSizeMb { get; set; }
        public string dataURL { get; set; }
        public DateTime expiresAt { get; set; }
    }

    public class HptJobQuote
    {
        public Single costDollars { get; set; }
        public UInt64 estimatedActivityCount { get; set; }
        public Single estimatedDurationHours { get; set; }
        public Single estimatedFileSizeMb { get; set; }
        public DateTime expiresAt { get; set; }
    }

    public class HptJobResultData
    {
        public int urlCount { get; set; }
        public string[] urlList { get; set; }
        public UInt64 totalFileSizeBytes { get; set; }
        public string suspectMinutesUrl { get; set; }
        public DateTime expiresAt { get; set; }
    }
}
