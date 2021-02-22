/**
 * HOMEMADE.CS
 * 
 * Barebones implementation of a "channel", based on the article at
 * https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels/
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 21 February 2021
 */

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace _19_channels
{
    public interface IBareboneChannel<T>
    {
        void Write(T value);
        Task<T> ReadAsync();
        void Close();
        bool IsOpen();
    }

    public sealed class BareboneChannel<T> : IBareboneChannel<T>
    {
        public void Write(T value)
        {
            queue.Enqueue(value);
            semaphore.Release();
        }

        public async Task<T> ReadAsync()
        {
            await semaphore.WaitAsync(50);

            // once the semaphore releases, we must be able to dequeue a value
            bool dequeueResult = queue.TryDequeue(out T value);

            if (!dequeueResult)
            {
                return default;
            }

            return value;
        }

        public void Close()
        {
            Interlocked.Exchange(ref open, 0);
        }

        public bool IsOpen()
        {
            // we might have finished putting values on the queue, but the channel
            // should remain open until they've all been consumed
            return open != 0;
        }

        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(0);
        private int open = 1;
    }

    internal sealed class BareboneStringProducer
    {
        internal BareboneStringProducer(IBareboneChannel<string> channel, int valueCount)
        {
            this.channel = channel;
            this.valueCount = valueCount;
        }
        internal void produceAsync()
        {
            for (int i = 0; i < valueCount; ++i)
            {
                var value = $"value-{i}";
                channel.Write(value);
                Console.WriteLine($"[producer] Made {value}");
                /* await Task.Delay(100); */
            }
            channel.Close();
        }
        private readonly IBareboneChannel<string> channel;
        private int valueCount;
    }

    internal sealed class BareboneStringConsumer
    {
        internal BareboneStringConsumer(IBareboneChannel<string> channel)
        {
            this.channel = channel;
        }
        internal async Task consumeAsync()
        {
            while (channel.IsOpen())
            {
                string value = await channel.ReadAsync();
                if (value == default) continue;
                Console.WriteLine($"[consumer] Got {value}");
            }
            Console.WriteLine("[consumer] Channel was closed");
        }
        private readonly IBareboneChannel<string> channel;
    }

    internal static class BarebonesChannelSampler
    {
        internal static void TryItOut()
        {
            IBareboneChannel<string> strChannel = new BareboneChannel<string>();

            var producer = new BareboneStringProducer(strChannel, 10);
            var consumer = new BareboneStringConsumer(strChannel);

            var producerTask = Task.Run(() => producer.produceAsync());
            Task.WaitAll(producerTask, consumer.consumeAsync());
        }
    }
}

