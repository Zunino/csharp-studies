/**
 * HOMEMADE.CS
 * 
 * Homemade implementation of a "channel", based on the article at
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
    public interface IHomemadeChannel<T>
    {
        void Write(T value);
        Task<T> ReadAsync();
        void Close();
        bool IsOpen();
    }

    public sealed class HomemadeChannel<T> : IHomemadeChannel<T>
    {
        public void Write(T value)
        {
            queue.Enqueue(value);
            semaphore.Release();
        }

        public async Task<T> ReadAsync()
        {
            // if no timeout is specified here, the semaphore might be waited on
            // forever and the main thread will hang waiting for the consumer
            // task to end
            await semaphore.WaitAsync(1);

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
            lock(this) {
                open = false;
            }
        }

        public bool IsOpen()
        {
            bool isOpen;
            lock(this) {
                isOpen = this.open;
            }
            return isOpen;
        }

        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(0);
        private bool open = true;
    }


    internal sealed class HomemadeStringProducer
    {
        internal HomemadeStringProducer(IHomemadeChannel<string> channel, int valueCount)
        {
            this.channel = channel;
            this.valueCount = valueCount;
        }
   
        internal void produce()
        {
            for (int i = 0; i < valueCount; ++i)
            {
                var value = $"value-{i}";
                Console.WriteLine($"[producer] Made {value}");
                channel.Write(value);
                Thread.Sleep(100);
            }
            channel.Close();
        }
       
        private readonly IHomemadeChannel<string> channel;
        private int valueCount;
    }

   
    internal sealed class HomemadeStringConsumer
    {
        internal HomemadeStringConsumer(IHomemadeChannel<string> channel)
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
       
        private readonly IHomemadeChannel<string> channel;
    }


    internal static class HomemadeChannelSampler
    {
        internal static void TryItOut()
        {
            IHomemadeChannel<string> strChannel = new HomemadeChannel<string>();

            var producer = new HomemadeStringProducer(strChannel, 10);
            var consumer = new HomemadeStringConsumer(strChannel);

            var producerTask = Task.Run(() => producer.produce());
            Task.WaitAll(producerTask, consumer.consumeAsync());
        }
    }
}

