using System;
using System.IO;
using System.Text;
using TensorFlow;

namespace SmartReply
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new TFSession())
            {
                var graph = session.Graph;

                var a = graph.Const(2);
                var b = graph.Const(3);
                Console.WriteLine("a=2 b=3");

                // Add two constants
                var addingResults = session.GetRunner().Run(graph.Add(a, b));
                var addingResultValue = addingResults.GetValue();
                Console.WriteLine("a+b={0}", addingResultValue);

                // Multiply two constants
                var multiplyResults = session.GetRunner().Run(graph.Mul(a, b));
                var multiplyResultValue = multiplyResults.GetValue();
                Console.WriteLine("a*b={0}", multiplyResultValue);
            }

            //var message = "happy new year";

            //Console.WriteLine($"Message: {message}");

            //var replies = Predict(message);

            //if (replies.Length == 0)
            //{
            //    Console.WriteLine("No reply...nothing to say");
            //}
            //else
            //{
            //    foreach (var reply in replies)
            //    {
            //        Console.WriteLine($"Reply: {reply.Reply}, Score: {reply.Score}");
            //    }
            //}

            //Console.WriteLine("------------------------");

            Console.ReadKey();
        }

        static SmartReply[] Predict(string message)
        {
            var model = File.ReadAllBytes("smartreply.tflite");

            using (var graph = new TFGraph())
            {
                graph.Import(model);

                var session = new TFSession(graph);

                var runner = session.GetRunner();

                var messageBytes = Encoding.ASCII.GetBytes(message);

                runner.AddInput(graph["input"][0], TFTensor.CreateString(messageBytes));
                runner.Fetch(graph["output"][0]);

                var output = runner.Run();

                // Fetch the results from output:
                TFTensor result = output[0];
            }

            return null;
        }
    }
}
