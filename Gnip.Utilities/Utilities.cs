using System;
using System.IO;
using System.Net;
using System.Text;

namespace Gnip.Utilities
{
    public static class Restful
    {
        /// <summary>
        /// Processes a request for a RESTful call and returns data as passed param.  Optionally supports posting data as well, and basic authorization.
        /// </summary>
        /// <param name="verb">REST call - GET, PUT, POST, DELETE)</param>
        /// <param name="requestUrl">HTTP endpoint</param>
        /// <param name="userName">Authorized user</param>
        /// <param name="password"></param>
        /// <param name="receiveContent">Any content will be returned here, as well as error messages</param>
        /// <param name="postContent">Content to send on PUT or POST call</param>
        /// <returns>HTTPStatusCode</returns>
        public static HttpStatusCode GetRestResponse(
            string verb, 
            string requestUrl, 
            string userName, 
            string password, 
            out string receiveContent, 
            string postContent = null)
        {
            const int blockSize = 512;

            // Create request object
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            request.Method = verb; // Get, Put, Post, Delete
            request.ContentType = @"application/json";
            
            // apply authorization
            if (userName != null)
            {
                var authInfo = string.Format("{0}:{1}", userName, password);
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers.Add("Authorization", "Basic " + authInfo);
            }

            // prepare content to post if passed in            
            if (postContent != null)
            {
                var encoding = new UTF8Encoding();
                var bytes = encoding.GetBytes(postContent);
                request.ContentLength = bytes.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    // Add data to request
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                var response = (HttpWebResponse) request.GetResponse();
                var receiveStream = response.GetResponseStream();
                var encode = Encoding.GetEncoding("utf-8");

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                if (receiveStream != null)
                {
                    var readStream = new StreamReader(receiveStream, encode);
                    var read = new Char[blockSize];

                    // Reads a block of characters at a time.     
                    var count = readStream.Read(read, 0, blockSize);
                    
                    // add to contents to string until done.
                    var content = new StringBuilder();
                    while (count > 0)
                    {
                        var str = new String(read, 0, count);
                        content.Append(str);
                        count = readStream.Read(read, 0, blockSize);
                    }

                    // Releases the resources of the stream object.
                    readStream.Close();

                    // Releases the resources of the response object.
                    response.Close();

                    // place content into (passed) return variable
                    receiveContent = content.ToString();
                    return response.StatusCode;
                }
            }
            catch (WebException we)
            {
                receiveContent = we.Message + " posted content = " + postContent;
                return HttpStatusCode.BadRequest;
            }
            receiveContent = null;
            return 0;
        }
    }
}
