using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Gnip.Utilities;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.UsageAPI
{
    public static class Usage
    {
        public static UsageResults GetUsage(string AccountName, string Username, string Password, string Bucket="month")
        {
            if (AccountName== null || Bucket == null)
            {
                throw new ArgumentNullException(null, "Required parameter missing");
            }

            // https://account-api.gnip.com/accounts/[your_account_name]/usage.json

            // https://gnip-api.twitter.com/metrics/usage/accounts/[account-name].json

            var endPoint = @"https://gnip-api.twitter.com/metrics/usage/accounts/" + AccountName + ".json";

            try
            {
                string content = "";

                var fullEndPoint = endPoint + "?bucket=" + Bucket;
                Debug.WriteLine("fullEndPoint = |" + fullEndPoint + "|");
                

                var resultCode = Restful.GetRestResponse("Get", fullEndPoint, Username, Password, out content);
                if (resultCode == HttpStatusCode.OK)
                {
                    var searchResult = JsonConvert.DeserializeObject<UsageResults>(content.ToString());
                    if (searchResult.account != null)
                        return searchResult;
                    // else (no data to return, but not an error)
                    return null;
                }
                else
                {
                    var result = new UsageResults() { 
                    ErrorMessage = "Invalid HTTP Response code." + resultCode + " " + content,
                    hasError = true};
                    return result;
                }
            }
            catch (Exception ex)
            {
                var result = new UsageResults()
                {
                    ErrorMessage = ex.Message,
                    hasError = true
                };
                return result;
            }

        }
    }
}
