using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public Request()
        {
            MaxResults = 500;
        }

        public string AccountName { get; set; }
        public string StreamName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool ErrorState { get; set; }
        public string ErrorMessage { get; set; }
        public string Query { get; set; }
        public int MaxResults { get; set; }

        private string searchJson { get; set; }
    
        private string nextToken = null;

        public bool hasMore
        {
            get { return (nextToken != null); }
        }


        public void Reset()
        {
            nextToken = null;
            ErrorMessage = null;
            ErrorState = false;
        }

        public Counts GetCounts()
        {
            if (Username == null || Password == null || StreamName == null || AccountName == null)
            {
                throw new ArgumentNullException(null, "Required parameter missing");
            }
            var endPoint = @"https://search.gnip.com/accounts/" + AccountName + "/search/" + StreamName + "/counts.json";
            try
            {
                ErrorState = false;
                string content = "";

                var searchData = new SearchPost();
                searchData.query = Query;
                searchData.maxResults = MaxResults;
                searchData.publisher = "twitter";
                searchData.bucket = "day";
                if (hasMore) searchData.next = nextToken;
                var postSearch = BuildQueryJson(searchData);

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
       
        public List<Activity> GetResults()
        {
            if (Username == null || Password == null || StreamName == null || AccountName == null)
            {
                throw new ArgumentNullException(null, "Required parameter missing");
            }

            var endPoint = @"https://search.gnip.com/accounts/" + AccountName + "/search/" + StreamName + ".json";
            try
            {
                ErrorState = false;
                string content = "";

                var searchData = new SearchPost();
                searchData.query = Query;
                searchData.maxResults = MaxResults;
                searchData.publisher = "twitter";
                if (hasMore) searchData.next = nextToken;
                searchData.bucket = null;
                var postSearch = BuildQueryJson(searchData);
               
                var resultCode = Restful.GetRestResponse("Post", endPoint, Username, Password, out content, postSearch);
                if (resultCode == HttpStatusCode.OK)
                {
                    var searchResult = JsonConvert.DeserializeObject<Results>(content.ToString());
                    nextToken = searchResult.next;
                    if (searchResult.results != null)
                        return searchResult.results.ToList();
                    // else (no data to return, but not an error)
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

        private string BuildQueryJson(SearchPost searchPost)
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
                jw.WritePropertyName("maxResults", false);
                jw.WriteValue(searchPost.maxResults.ToString());
                if (searchPost.fromDate > DateTime.Parse("1/1/0001"))
                {
                    jw.WritePropertyName("fromDate", false);
                    jw.WriteValue(searchPost.fromDate);
                }
                if (searchPost.toDate > DateTime.Parse("1/1/0001"))
                {
                    jw.WritePropertyName("toDate", false);
                    jw.WriteValue(searchPost.toDate);
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

    }
}
