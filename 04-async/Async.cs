using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetStudies
{

    class Async
    {
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
                HttpRequests.MakeSynchronousRequests();
            } 
            else
            {
                Console.WriteLine("== [ASYNCHRONOUS MODE] ==");
                HttpRequests.MakeAsynchronousRequests();
            }
        }
    }

}
