using Breweries.Constants;
using Breweries.Objects;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Breweries.Models
{
    public class BreweriesModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<Brewery> _breweries;
        bool _errorLabelVisible, _breweryListVisible;

        public BreweriesModel()
        {
            if (App.IsConnectedToInternet)
            {
                ErrorLabelVisible = false;
                BreweryListVisible = true;
                GetBreweries();
            }
            else
            {
                BreweryListVisible = false;
                ErrorLabelVisible = true;
            }

            SearchBreweries = new Command<string>(async (string searchText) => await PerformSearch(searchText));
        }

        public async void GetBreweries()
        {
            _breweries = await BreweryConstants.Brewery_API.GetJsonAsync<List<Brewery>>();
            Breweries = _breweries;
        }

        public ICommand SearchBreweries { private set; get; }
        
        public async Task PerformSearch(string searchText)
        {
            if (App.IsConnectedToInternet)
            {
                string apiURL = BreweryConstants.Brewery_API + "/search?per_page=20" + "&query=" + searchText;
                _breweries = await apiURL.GetJsonAsync<List<Brewery>>();
                Breweries = _breweries;
                BreweryListVisible = true;
                ErrorLabelVisible = false;
            }
            else
            {
                BreweryListVisible = false;
                ErrorLabelVisible = true;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Brewery> Breweries
        {
            get
            {
                return _breweries;
            }
            set
            {
                _breweries = value;
                OnPropertyChanged("Breweries");
            }
        }
        public bool ErrorLabelVisible
        {
            get
            {
                return _errorLabelVisible;
            }
            set
            {
                _errorLabelVisible = value;
                OnPropertyChanged("ErrorLabelVisible");
            }
        }

        public bool BreweryListVisible
        {
            get
            {
                return _breweryListVisible;
            }
            set
            {
                _breweryListVisible = value;
                OnPropertyChanged("BreweryListVisible");
            }
        }
    }
            
}
