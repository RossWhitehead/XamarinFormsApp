using System;

using XamarinFormsApp.Views;
using Xamarin.Forms;

namespace XamarinFormsApp
{
	public partial class App : Application
	{
		public App (ITidePredictor predictor)
		{
			InitializeComponent();
            MainPage = new MainPage(predictor);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
