using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gnip.Utilities.JsonClasses
{
    public class SearchRequest
    {
        public string query { get; set; }
        public string publisher { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        // public int maxResults { get; set; }

        // public string next { get; set; }
    }
}
