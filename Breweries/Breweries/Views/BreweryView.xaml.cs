using Breweries.Models;
using Breweries.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Breweries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreweryView : ContentPage
    {
        BreweryModel _vm;

        public BreweryView(Brewery brewery)
        {
            _vm = new BreweryModel(brewery);
            this.BindingContext = _vm;
            InitializeComponent();
        }
    }
}