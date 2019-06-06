using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetStudies
{

    class DummyTasks
    {

        static Task<string> CreateDummyTask(string id, int waitTimeMs)
        {
            return new Task<string>(() => {
                Console.WriteLine("Starting task {0}", id);
                Thread.Sleep(waitTimeMs);
                return String.Format("Finished task {0}", id);
            });
        }
        
        static List<Task<string>> CreateTasks()
        {
            var tasks = new List<Task<string>>(new Task<string>[] {
                CreateDummyTask("FOO", 2000),
                CreateDummyTask("BAR", 1500),
                CreateDummyTask("BAZ", 2500)
            });
            return tasks;
        }

        internal static void DoSynchronousTasks()
        {
            var tasks = CreateTasks();
            foreach (var task in tasks)
            {
                task.RunSynchronously();
                Console.WriteLine(task.Result);
            }
        }

        static async Task<string> ShenaniganAsync(string id, int delayMilli) {
            await Task.Delay(delayMilli);
            return String.Format("{0} RESULT", id);
        }

        internal static void DoAsynchronousTasks()
        {
            Console.WriteLine("== BEGIN ==");
            var task1 = ShenaniganAsync("FOO", 3500);
            var task2 = ShenaniganAsync("BAR", 5000);
            Console.WriteLine("TASK 1: {0}", task1.Result); // Reading Result will block
            Console.WriteLine("TASK 2: {0}", task2.Result); // A little more to go before this one's done
            Console.WriteLine("== ALL DONE ==");
        }

    }

}
