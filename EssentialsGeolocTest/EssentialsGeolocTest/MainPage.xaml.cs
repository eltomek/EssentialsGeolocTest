using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace EssentialsGeolocTest
{
    public partial class MainPage : ContentPage
    {
        private static System.Timers.Timer locationUpdateTimer;
        private Location currentLocation;

        public MainPage()
        {
            InitializeComponent();

            locationUpdateTimer = new System.Timers.Timer(1000) { AutoReset = true };

            locationUpdateTimer.Elapsed += async (o, e) =>
            {
                currentLocation = await LocationService.GetCurrentLocation();
                Debug.WriteLine($"Curr. location: {currentLocation?.ToString()}");
            };
            
            locationUpdateTimer.Start();

        }

        protected override async void OnAppearing()
        {
            if ((currentLocation = await LocationService.GetCurrentLocation()) != null)
            {
                Debug.WriteLine($"OnAppearing currentLocation: {currentLocation?.ToString()}");
            }

            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((currentLocation = await LocationService.GetCurrentLocation()) != null)
            {
                Debug.WriteLine($"Button_Clicked currentLocation: {currentLocation?.ToString()}");
            }
        }
    }
}
