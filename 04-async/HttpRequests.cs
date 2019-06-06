using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetStudies
{

    class HttpRequests
    {
        const string BEECEPTOR_URL_1 = "https://zunino.free.beeceptor.com/foo";
        const string BEECEPTOR_URL_2 = "https://zunino.free.beeceptor.com/bar";
        const string BEECEPTOR_URL_3 = "https://zunino.free.beeceptor.com/baz";

        const int NO_OF_REQUESTS = 3;

        static WebResponse GetUrl(string requestId, string url)
        {
            WebRequest request = WebRequest.Create(url);
            Console.WriteLine("==> Request {0}", requestId);
            Console.Write("GETting {0}...", url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Console.WriteLine(" {0}", response.StatusCode);
            return response;
        }

        static async Task<WebResponse> GetUrlAsync(string requestId, string url)
        {
            WebRequest request = WebRequest.Create(url);
            Console.WriteLine("==> Request {0}", requestId);
            Console.WriteLine("GETting {0}...", url);
            return await request.GetResponseAsync();
        }

        static string GetBody(WebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                string body = reader.ReadToEnd();
                return body;
            }
        }

        internal static void MakeSynchronousRequests()
        {
            string body1 = GetBody(GetUrl("FOO", BEECEPTOR_URL_1));
            Console.WriteLine("Response 1: {0}", body1);

            string body2 = GetBody(GetUrl("BAR", BEECEPTOR_URL_2));
            Console.WriteLine("Response 2: {0}", body2);

            string body3 = GetBody(GetUrl("BAZ", BEECEPTOR_URL_3));
            Console.WriteLine("Response 3: {0}", body3);
        }

        internal static void MakeAsynchronousRequests()
        {
            var tasks = new List<Task<WebResponse>>
            {
                GetUrlAsync("FOO", BEECEPTOR_URL_1),
                GetUrlAsync("BAR", BEECEPTOR_URL_2),
                GetUrlAsync("BAZ", BEECEPTOR_URL_3)
            };
            for (int i = 0; i < NO_OF_REQUESTS; ++i)
            {
                int taskIdx = Task.WaitAny(tasks.ToArray());
                var task = tasks[taskIdx];
                tasks.RemoveAt(taskIdx);
                try
                {
                    WebResponse response = task.Result;
                    string body = GetBody(response);
                    Console.WriteLine("Asynchronous response: {0}", body);
                }
                catch (Exception e)
                {
                    Console.WriteLine("=== [Exception] ===\n{0}", e.ToString());
                    continue;
                }
            }
            Console.WriteLine("All tasks processed");
        }

    }

}
