using System;
using System.IO;
using System.Net;
using WebApplication2.Entity;

namespace WebApplication2.Service
{
    public class ApiService
    {
        private static readonly string notify = "http://releasegw1.staxi.vn/api/AlertAllDevice";
        public static string callApiNotify(Message message)
        {
            var body ="{" +
                "\"title\":\"" + message.Title + "\"," +
                "\"content\":\"" + message.Content + "\"," +
                "}";
            return callApi(notify, body);
        }

        private static string callApi(string url, string body)
        {
            // initialization  request
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            // httpWebRequest.Headers["Authorization"] = accessToken;
            // httpWebRequest.Headers["Cookie"] = COOKIE;
            // add method
            httpWebRequest.Method = "POST";
            // use stream write
            string status;
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Close();
                }

                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader streamReader =
                           new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        status = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    status = "501";
                }

                response.Close();
            }
            catch (Exception e)
            {
                status = "502";
            }

            // return status;
            return status;
        }
    }
}