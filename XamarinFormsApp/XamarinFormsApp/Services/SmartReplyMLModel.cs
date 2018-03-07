using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TensorFlow;
using XamarinFormsApp.Resources;

namespace XamarinFormsApp.Services
{
    public class SmartReplyMLModel : IMLModel
    {
        static byte[] modelDefinition;

        private const string modelFileName = "Resources/smartreply.tflite";

        static SmartReplyMLModel()
        {
            modelDefinition = ResourceLoader.GetEmbeddedResourceBytes(modelFileName);
        }

        public SmartReply[] Predict(string message)
        {
            using(var graph = new TFGraph())
            {
                graph.Import(modelDefinition);

                var session = new TFSession(graph);

                var runner = session.GetRunner();

                var messageBytes = Encoding.ASCII.GetBytes(message);

                runner.AddInput(graph["input"][0], TFTensor.CreateString(messageBytes));
                runner.Fetch(graph["output"][0]);

                var output = runner.Run();

                // Fetch the results from output:
                TFTensor result = output[0];


            }

            throw new NotImplementedException();
        }
    }
}
