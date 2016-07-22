using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Gnip.Utilities;
using Gnip.Utilities.JsonClasses;
using Newtonsoft.Json;

namespace Gnip.Powertrack.Rules
{

    public class RuleManager
    {
        public string Url { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool ErrorState { get; set; }
        public string ErrorMessage { get; set; }

        public List<Rule> GetRules()
        {
            try
            {
                ErrorState = false;
                string content;
                var resultCode = Restful.GetRestResponse("Get", Url, Username, Password, out content);
                if (resultCode == HttpStatusCode.OK)
                {
                    var ruleList = JsonConvert.DeserializeObject<Rules>(content).rules;
                    return ruleList;
                }
                else
                {
                    ErrorMessage = "Invalid HTTP Response code." + resultCode;
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

        public bool DeleteRules(List<Rule> rules, bool isPowerTrack20 = false)
        {
            try
            {
                var deleteJson = rules.ToJson();
                string responseString;
                HttpStatusCode responseCode;

                if (isPowerTrack20)
                {
                    responseCode = Restful.GetRestResponse(
                        "POST",
                        Url + @"?_method=delete",
                        Username,
                        Password,
                        out responseString,
                        deleteJson);
                }
                else
                {
                    responseCode = Restful.GetRestResponse(
                        "DELETE",
                        Url,
                        Username,
                        Password,
                        out responseString,
                        deleteJson);
                }
                if (responseCode == HttpStatusCode.OK)
                    return true;
                else
                {
                    ErrorMessage = "Delete, returned an HTTP Status Code " + responseCode.ToString();
                    return false;
                }
            }
            catch (WebException we)
            {
                Debug.WriteLine("Web Exception:" + we.Message);
                ErrorMessage = we.Message;
                ErrorState = true;
                return false;
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
                return false;
            }
                
        }

        public bool AddRules(List<Rule> rules)
        {
            try
            {

                // custom serializer to prevent the escaping of quotes on propertynames
                var sb = new StringBuilder();
                var sw = new StringWriter(sb);

                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("rules",false);
                    jw.WriteStartArray();
                    foreach (var rule in rules)
                    {
                        jw.WriteStartObject();
                        jw.WritePropertyName("value",false);
                        jw.WriteValue(rule.value);
                        jw.WritePropertyName("tag", false);
                        jw.WriteValue(rule.tag);
                        jw.WriteEndObject();
                    }

                    jw.WriteEndArray();
                    jw.WriteEndObject();
                }

                var addJson = sb.ToString();
                string responseString;

                var responseCode = Restful.GetRestResponse(
                    "POST",
                    Url,
                    Username,
                    Password,
                    out responseString,
                    addJson);

                if (responseCode == HttpStatusCode.Created)
                    return true;
                else
                {
                    ErrorMessage = "AddRules, returned an HTTP Status Code " + responseCode.ToString();
                    return false;
                }
            }
            catch (WebException we)
            {
                Debug.WriteLine("Web Exception:" + we.Message);
                ErrorMessage = we.Message;
                ErrorState = true;
                return false;
            }
            catch (Exception ex)
            {
                ErrorState = true;
                ErrorMessage = ex.Message;
                return false;
            }

        }
        
        public class Rules
        {
            // ReSharper disable once InconsistentNaming - casing matches JSON description for deserializing
            public List<Rule> rules;
        }
    }
}
