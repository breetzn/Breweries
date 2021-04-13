using Breweries.Models;
using Breweries.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Breweries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreweriesView : ContentPage
    {
        BreweriesModel _vm;
        public BreweriesView()
        {
            _vm = new BreweriesModel();
            this.BindingContext = _vm;
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView list = (ListView)sender;
            Brewery brewery = (Brewery)list.SelectedItem;
            await Navigation.PushAsync(new BreweryView(brewery));
        }
    }
}