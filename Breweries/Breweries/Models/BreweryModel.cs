using Breweries.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Breweries.Models
{
    public class BreweryModel
    {
        public BreweryModel(Brewery brewery)
        {
            Brewery = brewery;
            PhoneTappedCommand = new Command(OpenPhoneNumber);
            AddressTappedCommand = new Command(OpenAddressInMaps);
            WebsiteTappedCommand = new Command(OpenWebsite);
        }

        public Brewery Brewery { get; set; }
        public ICommand PhoneTappedCommand { private set; get; }
        public ICommand AddressTappedCommand { private set; get; }
        public ICommand WebsiteTappedCommand { private set; get; }

        public void OpenPhoneNumber()
        {
            if (!string.IsNullOrEmpty(Brewery.Phone))
                Launcher.OpenAsync($"tel:{Brewery.Phone}");
        }

        public void OpenAddressInMaps()
        {
            try
            {
                Map.OpenAsync(Double.Parse(Brewery.Latitude), Double.Parse(Brewery.Longitude));
            }
            catch { }
            
        }

        public void OpenWebsite()
        {
            if (!string.IsNullOrEmpty(Brewery.Website_Url))
                Launcher.OpenAsync(Brewery.Website_Url);
        }
    }
}
