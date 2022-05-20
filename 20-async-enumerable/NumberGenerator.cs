using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_enumerable
{
    public class NumberGenerator
    {
        private static async IAsyncEnumerable<int> NumberSource(int lim = 10)
        {
            for (int i = 1; i <= lim; ++i)
            {
                await Task.Delay(300);
                yield return i;
            }
        }

        public static async Task SimpleNumberGenerator() {
            await foreach (var i in NumberSource())
            {
                Console.WriteLine(i);
            }
        }
    }
}
