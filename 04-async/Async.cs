using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetStudies
{

    enum TaskType
    {
        DUMMY,
        HTTP_REQUESTS
    }

    class Async
    {
        static void Main(string[] args)
        {
            bool runAsynchronously = false;
            TaskType type = TaskType.DUMMY;

            if (args.Length >= 1)
            {
                if (args[0] == "http")
                {
                    type = TaskType.HTTP_REQUESTS;
                }
                if (args.Length == 2 && args[1] == "async")
                {
                    runAsynchronously = true;
                }
            }

            if (type == TaskType.DUMMY)
            {
                if (!runAsynchronously)
                {
                    Console.WriteLine("== [DUMMY SYNC] ==");
                    DummyTasks.DoSynchronousTasks();
                }
                else
                {
                    Console.WriteLine("== [DUMMY ASYNC] ==");
                    DummyTasks.DoAsynchronousTasks();
                }
            }
            else if (type == TaskType.HTTP_REQUESTS)
            {
                if (!runAsynchronously)
                {
                    Console.WriteLine("== [HTTP SYNC] ==");
                    HttpRequests.MakeSynchronousRequests();
                } 
                else
                {
                    Console.WriteLine("== [HTTP ASYNC] ==");
                    HttpRequests.MakeAsynchronousRequests();
                }
            }
        }
    }

}
