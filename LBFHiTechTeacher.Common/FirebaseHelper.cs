using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LBFVideoLib.Common
{
    public static class FirebaseHelper
    {
        //private const string URL = "https://lbf-video-content.firebaseio.com/registrations-data/{0}/.json";
        private const string BaseURL = "https://lbf-video-content.firebaseio.com/{0}/.json";


        public static void PostData(string requestJson, string url)
        {
            string requestUrl = string.Format(BaseURL, url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("API-KEY", "");
            request.KeepAlive = false;
            request.Timeout = -1;
            request.ContentLength = requestJson.Length;
            using (var requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                requestWriter.Write(requestJson);
            };

            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            //requestWriter.Write(requestJson);
            //requestWriter.Close();


            using (var webResponse = (HttpWebResponse)request.GetResponse())
            {
                if (webResponse.ContentLength == 0 && webResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    //Connection to internet available
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    string response = responseReader.ReadToEnd();
                    responseReader.Close();
                }
                else
                {
                    //Connection to internet not available
                    // throw new Exception("Internet connection is not available");

                }
            }

            //WebResponse webResponse = request.GetResponse();
            //Stream webStream = webResponse.GetResponseStream();
            //StreamReader responseReader = new StreamReader(webStream);
            //string response = responseReader.ReadToEnd();
            //Console.Out.WriteLine(response);
            //responseReader.Close();
        }

        public static void PatchData(string requestJson, string url)
        {
            string requestUrl = string.Format(BaseURL, url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "PATCH";
            request.ContentType = "application/json";
            request.Headers.Add("API-KEY", "");
            request.KeepAlive = false;
            request.Timeout = -1;
            request.ContentLength = requestJson.Length;
            using (var requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                requestWriter.Write(requestJson);
            };

            using (var webResponse = (HttpWebResponse)request.GetResponse())
            {
                if (webResponse.ContentLength == 0 && webResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    //Connection to internet available
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    string response = responseReader.ReadToEnd();
                    responseReader.Close();
                }
                else
                {
                    //Connection to internet not available
                    //throw new Exception("Internet connection is not available");

                }
            }
        }

        public static string GetData(string url)
        {
            try
            {
                string response = "";
                string requestUrl = string.Format(BaseURL, url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add("API-KEY", "");
                request.KeepAlive = false;
                request.Timeout = -1;

                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    //if (webResponse.ContentLength == 0 && webResponse.StatusCode == HttpStatusCode.NoContent)
                    //{
                    //Connection to internet available
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    response = responseReader.ReadToEnd();
                    responseReader.Close();
                    //}
                    //else
                    //{
                    //    //Connection to internet not available
                    //    //throw new Exception("Internet connection is not available");

                    //}
                }

                return response;
            }
            catch (Exception WebException)
            {
                return string.Empty;
            }
        }

    }
}
