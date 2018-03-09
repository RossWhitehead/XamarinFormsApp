using System;

using XamarinFormsApp.Views;
using Xamarin.Forms;
using Autofac;
using XamarinFormsApp.Services;

namespace XamarinFormsApp
{
	public partial class App : Application
	{
		public App (ITidePredictor predictor)
		{
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance(predictor);
            DependencyContainer = containerBuilder.Build();

            InitializeComponent();

            MainPage = new MainPage();
        }

        public static IContainer DependencyContainer { get; set; }

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
