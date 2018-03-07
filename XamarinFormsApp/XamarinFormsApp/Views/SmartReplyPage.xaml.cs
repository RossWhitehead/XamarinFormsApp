using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensorFlow;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Services;

namespace XamarinFormsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SmartReplyPage : ContentPage
	{
		public SmartReplyPage ()
		{
			InitializeComponent ();
		}

        void Submit_Clicked(object sender, EventArgs args)
        {
            try
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
                    reply.Text = $"a+b={addingResultValue}";
                }
            }
            catch (Exception ex)
            {
            }


            //var messageText = message.Text;
            //if (messageText.Length == 0)
            //{
            //    return;
            //}

            //StringBuilder builder = new StringBuilder();
            //builder.AppendLine("Message:");
            //builder.AppendLine(message.Text);

            //var model = new SmartReplyMLModel();
            //var replies = model.Predict(messageText);

            //if (replies.Length == 0)
            //{
            //    builder.AppendLine("No reply...nothing to say");
            //}
            //else
            //{
            //    foreach(var reply in replies)
            //    {
            //        builder.AppendLine($"Reply: {reply.Reply}, Score: {reply.Score}");
            //    }
            //}

            //builder.AppendLine("------------------------");

            //reply.Text = builder.ToString();
        }
    }
}