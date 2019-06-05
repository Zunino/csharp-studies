using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetStudies
{

    class Async
    {
        const string BEECEPTOR_URL_1 = "https://zunino.free.beeceptor.com/foo";
        const string BEECEPTOR_URL_2 = "https://zunino.free.beeceptor.com/bar";
        const string BEECEPTOR_URL_3 = "https://zunino.free.beeceptor.com/baz";

        const int NO_OF_REQUESTS = 3;

        static WebResponse GetUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            Console.Write("GETting {0}...", url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Console.WriteLine(" {0}", response.StatusCode);
            return response;
        }

        static async Task<WebResponse> GetUrlAsync(string url)
        {
            WebRequest request = WebRequest.Create(url);
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

        static void MakeSynchronousRequests()
        {
            Console.WriteLine("==> Request 1");
            string body1 = GetBody(GetUrl(BEECEPTOR_URL_1));
            Console.WriteLine("Response 1: {0}", body1);

            Console.WriteLine("==> Request 2");
            string body2 = GetBody(GetUrl(BEECEPTOR_URL_2));
            Console.WriteLine("Response 2: {0}", body2);

            Console.WriteLine("==> Request 3");
            string body3 = GetBody(GetUrl(BEECEPTOR_URL_3));
            Console.WriteLine("Response 3: {0}", body3);
        }

        static async void MakeAsynchronousRequests()
        {
            var tasks = new List<Task<WebResponse>>
            {
                GetUrlAsync(BEECEPTOR_URL_1),
                GetUrlAsync(BEECEPTOR_URL_2),
                GetUrlAsync(BEECEPTOR_URL_3)
            };
            for (int i = 0; i < NO_OF_REQUESTS; ++i)
            {
                var taskIdx = Task.WaitAny(tasks.ToArray());
                var task = tasks[taskIdx];
                tasks.RemoveAt(taskIdx);
                WebResponse response = await task;
                string body = GetBody(response);
                Console.WriteLine("Asynchronous response: {0}", body);
            }
            Console.WriteLine("All tasks completed");
        }

        static void Main(string[] args)
        {
            bool runAsynchronously = false;
            if (args.Length == 1 && args[0] == "async")
            {
                runAsynchronously = true;
            }
            if (!runAsynchronously)
            {
                Console.WriteLine("== [SYNCHRONOUS MODE] ==");
                MakeSynchronousRequests();
            } 
            else
            {
                Console.WriteLine("== [ASYNCHRONOUS MODE] ==");
                MakeAsynchronousRequests();
            }
        }
    }

}
