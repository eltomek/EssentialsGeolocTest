using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EssentialsGeolocTest
{
    public static class LocationService
    {
        public static async Task<Location> GetLastKnownLocation()
        {
            Location lastKnownLocation = null;
            try
            {
                lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();

                if (lastKnownLocation != null)
                {
                    Debug.WriteLine($"Last known location: {lastKnownLocation?.ToString()}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return lastKnownLocation;
        }

        public static async Task<Location> GetCurrentLocation()
        {
            Location actualLocation = null;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                actualLocation = await Geolocation.GetLocationAsync(request);

                if (actualLocation != null)
                {
                    Debug.WriteLine($"Actual location: {actualLocation?.ToString()}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return actualLocation;
        }
    }
}
