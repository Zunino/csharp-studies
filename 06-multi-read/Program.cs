using System;
using System.IO;
using System.Threading.Tasks;

namespace DotnetStudies
{
    
    internal static class Program
    {
        private static async Task<string> ReadFileAsync(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                Console.WriteLine("Reading file {0}", filePath);
                return await reader.ReadToEndAsync()
                    .ContinueWith(antecedent =>
                    {
                        var result = antecedent.Result;
                        Console.WriteLine("Read {0} bytes", result.Length);
                        return result;
                    });
            }
        }

        private static void Main(string[] args)
        {
            var filePaths = new string[]
            {
                "data/abstraction.html",
                "data/computer-science.html",
                "data/concurrency.html",
                "data/cs-pioneers.html",
                "data/turing-machine.html"
            };
            
            var readTasks = new Task<string>[filePaths.Length];
            for (var i = 0; i < filePaths.Length; ++i)
            {
                readTasks[i] = ReadFileAsync(filePaths[i]);
            }

            Task.WaitAll(readTasks);
            Console.WriteLine("All files read");
        }
    }
}
