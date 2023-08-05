using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Security.Policy;
using System.Net.Http;
using System.IO;

namespace WebBundle
{
    public class API
    {
        /// <summary>
        /// This is a generic method for all type of API call
        /// </summary>
        /// <param name="baseURL">Takes string as argument for base url</param>
        /// <param name="parameters">Takes Dictionary&#60;string, Object&#62; as argument for parame. Pass null if not present.</param>
        /// <param name="headers">Takes Dictionary&#60;string, Object&#62; as argument for parame. Pass null if not present.</param>
        /// <param name="requestBody">Takes string as argument for request body</param>
        /// <param name="httpMethod">Takes string as argument for HTTP Methods. Eg. GET,POST,PUT etc</param>
        /// <param name="contentType">Takes string as argument for content type</param>
        /// <param name="requestTimeout">Takes int as argument for timeout</param>
        /// <returns>System.Net.WebRequest object</returns>
        public static WebRequest ApiCall(string baseURL, Dictionary<string,object> parameters, Dictionary<string, object> headers, string requestBody, string httpMethod, string contentType, int requestTimeout)
        {
            string paramURL = (parameters == null)?"": "?" + String.Join("&", parameters.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));

            string URL = baseURL + paramURL;
            var webRequest = WebRequest.Create(URL);
            
            if (webRequest != null)
            {
                webRequest.Method = httpMethod;
                webRequest.Timeout = requestTimeout;
                webRequest.ContentType = contentType;
                //Add headers if present
                if (headers != null)
                {
                    foreach (var kvp in headers)
                    {
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);

                        string hKey = string.Format(kvp.Key);
                        string hValue = string.Format("{0}", kvp.Value);
                        webRequest.Headers.Add(hKey,hValue);
                    }                    
                }
                //Add request body if present
                if (requestBody != null)
                    using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        streamWriter.Write(requestBody);
                    }
            }
            return webRequest;
        }
        /// <summary>
        /// This method returns response string
        /// </summary>
        /// <param name="webRequest">Takes an argument of System.Net.WebRequest</param>
        /// <returns>string</returns>
        public string getResponseString(WebRequest webRequest)
        {
            if (webRequest != null)
            {
                using (System.IO.Stream stream = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
                    {
                        string responseString = string.Empty;
                        responseString = streamReader.ReadToEnd();
                        return responseString;
                    }
                }
            }
            return null;
        }                
    }
}
