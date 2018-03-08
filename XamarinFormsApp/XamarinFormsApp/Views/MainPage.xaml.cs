using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
        private ITidePredictor predictor;

        public MainPage (ITidePredictor predictor)
		{
            this.predictor = predictor;

			InitializeComponent ();

            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

            void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                if (e.SelectedItem is MasterPageItem item)
                {
                    if (item.TargetType == typeof(TidePredictorPage))
                    {
                        Detail = new NavigationPage(new TidePredictorPage(this.predictor));
                    }
                    else
                    {
                        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    }
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
	}
}