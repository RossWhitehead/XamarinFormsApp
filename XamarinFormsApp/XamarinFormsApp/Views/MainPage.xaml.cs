﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

            void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                if (e.SelectedItem is MasterPageItem item)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tidePredictorModelService = new Services.TidePredictorModelService();
            var prediction = tidePredictorModelService.Predict();

            DisplayAlert("Tide Predictions", string.Join(", ", prediction), "OK");
        }
    }
}