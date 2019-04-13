using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MovieCore.Helpers
{
    public class HtmlGetHelper
    {

        public static async Task<string> GetResult(string url, IEnumerable<KeyValuePair<string, string>> headers)
        {
            HttpWebRequest webRequest = WebRequest.Create(url)  as HttpWebRequest;

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest?.Headers.Add(header.Key, header.Value);
                }
            }

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
