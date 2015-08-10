using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Gnip.Utilities;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.SearchAPI
{

    public class SearchPost
    {
        public string query { get; set; }
        public string publisher { get; set; }
        public int maxResults { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string next { get; set; }
        public string bucket { get; set; }
            
    }
    public class Request
    {
        string AccountName { get; set; }
        string StreamName { get; set; }
        string Password { get; set; }
        string Username { get; set; }
        public bool ErrorState { get; set; }
        public string ErrorMessage { get; set; }
        public string QueryJson { get; set; }
        string Query { get; set; }
        // int MaxResults { get; set; }

        private string searchJson { get; set; }
    
        private string nextToken = null;

        public bool hasMore
        {
            get { return (nextToken != null); }
        }

        public Request(string accountName, string userName,  string password, string streamName)
        {
            AccountName = accountName;
            Username = userName;
            Password = password;
            StreamName = streamName;
        }

        public void Reset()
        {
            nextToken = null;
            ErrorMessage = null;
            ErrorState = false;
        }

        public Counts GetCounts(string Query, string bucket = "day", DateTime? fromDateTime = null, DateTime? toDateTime = null)
        {
            var endPoint = @"https://search.gnip.com/accounts/" + AccountName + "/search/" + StreamName + "/counts.json";
            try
            {
                ErrorState = false;
                string content = "";

                var searchData = new SearchPost();
                searchData.query = Query;
                searchData.maxResults = 0;
                searchData.publisher = "twitter";
                searchData.bucket = bucket;
               if (fromDateTime != null) searchData.fromDate = fromDateTime.GetValueOrDefault();
               if (toDateTime != null) searchData.toDate = toDateTime.GetValueOrDefault();
                if (hasMore) searchData.next = nextToken;
                var postSearch = BuildQueryJson(searchData);
                QueryJson = postSearch;

                var resultCode = Restful.GetRestResponse("Post", endPoint, Username, Password, out content, postSearch);
                if (resultCode == HttpStatusCode.OK)
                {
                    var searchResult = JsonConvert.DeserializeObject<Counts>(content.ToString());
                    if (searchResult.results != null)
                        return searchResult;
                
                    return null;
                }
                else
                {
                    ErrorMessage = "Invalid HTTP Response code." + resultCode + " " + content;
                    ErrorState = true;
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
                return null;
            }

            
        }
       
        public List<Activity> GetResults(string Query,DateTime? fromDateTime = null, DateTime? toDateTime = null, int maxResults = 500)
        {
            var endPoint = @"https://search.gnip.com/accounts/" + AccountName + "/search/" + StreamName + ".json";
            try
            {
                ErrorState = false;
                string content = "";

                var searchData = new SearchPost();
                searchData.query = Query;
                searchData.maxResults = maxResults;
                searchData.publisher = "twitter";
                searchData.fromDate = fromDateTime.GetValueOrDefault();
                searchData.toDate = toDateTime.GetValueOrDefault();
                if (hasMore) searchData.next = nextToken;
                searchData.bucket = null;
                var postSearch = BuildQueryJson(searchData);
                QueryJson = postSearch;
                var resultCode = Restful.GetRestResponse("Post", endPoint, Username, Password, out content, postSearch);
                if (resultCode == HttpStatusCode.OK)
                {
                    var searchResult = JsonConvert.DeserializeObject<Results>(content.ToString());
                    nextToken = searchResult.next;
                    return searchResult.results != null ? searchResult.results.ToList() : null;
                }
                else
                {
                    ErrorMessage = "Invalid HTTP Response code." + resultCode + " " + content;
                    ErrorState = true;
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
                return null;
            }
        }

        private static string BuildQueryJson(SearchPost searchPost)
        {
            // custom serializer to prevent the escaping of quotes on propertynames
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.WriteStartObject();
                jw.WritePropertyName("query", false);
                jw.WriteValue(searchPost.query);
                jw.WritePropertyName("publisher", false);
                jw.WriteValue(searchPost.publisher);
                if (searchPost.maxResults > 0)
                {
                    jw.WritePropertyName("maxResults", false);
                    jw.WriteValue(searchPost.maxResults.ToString());
                }
                if (searchPost.fromDate > DateTime.Parse("1/1/0001"))
                {
                    jw.WritePropertyName("fromDate", false);
                    jw.WriteValue(AsUtcString(searchPost.fromDate));
                }
                if (searchPost.toDate > DateTime.Parse("1/1/0001"))
                {
                    jw.WritePropertyName("toDate", false);
                    jw.WriteValue(AsUtcString(searchPost.toDate));
                }
                if (searchPost.next != null)
                {
                    jw.WritePropertyName("next", false);
                    jw.WriteValue(searchPost.next);
                }
                if (searchPost.bucket != null)
                {
                    jw.WritePropertyName("bucket", false);
                    jw.WriteValue(searchPost.bucket);
                }
                jw.WriteEndObject();
                return sb.ToString();
            }
        }

        private static string AsUtcString(DateTime inDate)
        {
            return inDate.Year.ToString() +
                   inDate.Month.ToString().PadLeft(2, "0".ToCharArray()[0]) +
                   inDate.Day.ToString().PadLeft(2, "0".ToCharArray()[0]) +
                   inDate.Hour.ToString().PadLeft(2, "0".ToCharArray()[0]) +
                   inDate.Minute.ToString().PadLeft(2, "0".ToCharArray()[0]);
        }

    }
}
