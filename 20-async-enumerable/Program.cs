/**
 * Async Enumerables
 *
 * https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 17 August 2021
 */

using System.Threading.Tasks;

namespace async_enumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await NumberGenerator.SimpleNumberGenerator();
        }
    }
}
