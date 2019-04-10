using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Twitter;

namespace MovieCore.Helpers
{
    public class HtmlGetHelper
    {
        private const string AccessToken = "";

        public static async Task<string> GetResult(string url)
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Headers.Add("x-access-token", AccessToken);
            webRequest.Method = "GET";
            try
            {

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                        throw new Exception("Error: " + webResponse.StatusCode + " - " + webResponse.StatusDescription);

                    StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                    string responseData = await responseReader.ReadToEndAsync();
                    responseReader.Close();

                    return responseData;
                }
            }
            catch (WebException e)
            {
                return null;
            }
        }
    }
}
