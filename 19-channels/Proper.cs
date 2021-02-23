/**
 * PROPER.CS
 * 
 * Simple producer/consumer example using Dotnet's Channels facility.
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 22 February 2021
 */

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace _19_channels
{
    internal sealed class StringProducer
    {
        internal StringProducer(Channel<string> channel, int valueCount)
        {
            this.channel = channel;
            this.valueCount = valueCount;
        }
        internal void produceAsync()
        {
            for (int i = 0; i < valueCount; ++i)
            {
                var value = $"value-{i}";
                channel.Writer.TryWrite(value);
                Console.WriteLine($"[producer] Made {value}");
                Thread.Sleep(100);
            }
            channel.Writer.Complete();
        }
        private readonly Channel<string> channel;
        private int valueCount;
    }

    internal sealed class StringConsumer
    {
        internal StringConsumer(Channel<string> channel)
        {
            this.channel = channel;
        }
        internal async Task consumeAsync()
        {
            while (await channel.Reader.WaitToReadAsync())
            {
                bool readSuccessful = channel.Reader.TryRead(out string value);
                if (!readSuccessful) {
                    Console.WriteLine("[consumer] Could not read from channel");
                    break;
                }
                Console.WriteLine($"[consumer] Got {value}");
            }
            Console.WriteLine("[consumer] Done");
        }
        private readonly Channel<string> channel;
    }

    internal static class ProperChannelSampler
    {
        internal static void TryItOut()
        {
            var strChannel = Channel.CreateUnbounded<string>();

            var producer = new StringProducer(strChannel, 10);
            var consumer = new StringConsumer(strChannel);

            var producerTask = Task.Run(() => producer.produceAsync());
            Task.WaitAll(producerTask, consumer.consumeAsync());
        }
    }
}

