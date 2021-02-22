/**
 * PROGRAM.CS
 * 
 * Exploring Dotnet Core 3's Channel feature that aims to facilitate the
 * implementation of producer/consumer scenarios.
 *
 * The first part of this study focuses on exploring the basic concepts by
 * implementing a simplified version of Channels. The implementation is based
 * on the devblogs article linked below and can be found in Homemade.cs.
 *
 * Resources:
 *   - https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/
 *   - https://dotnetcoretutorials.com/2020/11/24/using-channels-in-net-core-part-1-getting-started/
 *   - https://youtu.be/E0Ld7ZgE4oY
 *   - https://docs.microsoft.com/en-us/dotnet/api/system.threading.channels.channel-1?view=netcore-3.1
 * 
 * Andre Zunino <neyzunino@gmail.com>
 * 21 February 2021
 */

namespace _19_channels
{
    class Program
    {
        static void Main(string[] args)
        {
            BarebonesChannelSampler.TryItOut();
        }
    }
}
