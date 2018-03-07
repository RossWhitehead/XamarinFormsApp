using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStatusHistoryPage : ContentPage
    {
        public ObservableCollection<ListItem> Items { get; set; }

        public AppStatusHistoryPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<ListItem>
            {
                new ListItem{Text = "Item 1", Details = "Details 1"},
                new ListItem{Text = "Item 2", Details = "Details 2"},
                new ListItem{Text = "Item 3", Details = "Details 3"},
                new ListItem{Text = "Item 4", Details = "Details 4"},
                new ListItem{Text = "Item 5", Details = "Details 5"}
            };

            ItemsListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }

    public class ListItem
    {
        public string Text { get; set; }
        public string Details { get; set; }
    }
}
