using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PublisherPage : ContentPage
	{
		public PublisherPage ()
		{
			InitializeComponent ();
		}

        async void Publish_Clicked(object sender, EventArgs e)
        {
            var msg = publishEntry.Text;

            try
            {
                using (var pubSocket = new PublisherSocket())
                {
                    pubSocket.Options.SendHighWatermark = 1000;

                    //pubSocket.Bind("tcp://10.0.2.2:12345");
                    pubSocket.Bind("tcp://192.168.1.66:12345");

                    pubSocket.SendMoreFrame("TopicA").SendFrame(msg);
                }
            }
            catch (NetMQException nex)
            {
                Console.WriteLine(nex.Message);
            }
        }
	}
}