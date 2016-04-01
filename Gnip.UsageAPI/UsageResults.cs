using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Gnip.UsageAPI
{
    public class UsageResults
    {
        public Account account;
        public string bucket;
        public string ErrorMessage;
        public bool hasError;
        public string fromDate;
        public string toDate;
        public Publisher[] publishers;
    }

    public class Account
    {
        public string name;
      //  public string status;  deprecated
    }

    public class Publisher
    {
        // public string name; deprecated
        public Product[] products;
        public UsageDetail projected;
        public string type; 
        public UsageDetail[] used;
    }

    
    public class Endpoints
    {
        public string label;
        public string type;
        public UsageDetail projected;
        public UsageDetail[] used;
    }
    public class Product
    {
        // public string name;  deprecated
        public string type;
        public UsageDetail projected;
        public UsageDetail[] used;
        public Endpoints[] endpoints;
    }

    public class UsageDetail
    {
        public int requests;
        public int activities;
        public int days;
        // new in 2.0
        public int jobs; 
        public string timePeriod;
        public int searchRequests30Day;
        public int searchRequestsFullArchive;
        public int historicalPowertrackDays;
        public int historicalPowertrackJobs;
    }
}
