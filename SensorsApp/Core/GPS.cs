using System;
using System.Numerics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SensorsApp.Core
{
    public static class GPS
    {
        private static SensorSpeed speed       = SensorSpeed.UI;
        private static bool        enabledOnce = false;

        private static double velocity;
        private static double latitude;
        private static double longtitude;

        public static async Task Update()
        {
            try
            {
                GeolocationRequest request  = new GeolocationRequest(GeolocationAccuracy.Best);
                Location           location = await Geolocation.GetLocationAsync(request);

                velocity   = location.Speed.GetValueOrDefault();
                latitude   = location.Latitude;
                longtitude = location.Longitude;
                //return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static double GetVelocity()
        {
            return velocity;
        }

        public static double GetLatitude()
        {
            return latitude;
        }

        public static double GetLongtitude()
        {
            return longtitude;
        }
    }
}
