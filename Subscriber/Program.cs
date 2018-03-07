using NetMQ;
using NetMQ.Sockets;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = args[0] == "All" ? "" : args[0];
            Console.WriteLine("Subscriber started for Topic : {0}", topic);

            using (var subSocket = new SubscriberSocket())
            {
                subSocket.Options.ReceiveHighWatermark = 1000;
                subSocket.Connect("tcp://localhost:12345");
                subSocket.Subscribe(topic);
                Console.WriteLine("Subscriber socket connecting...");
                while (true)
                {
                    string messageTopicReceived = subSocket.ReceiveFrameString();
                    string messageReceived = subSocket.ReceiveFrameString();
                    Console.WriteLine(messageReceived);
                }
            }
        }
    }
}