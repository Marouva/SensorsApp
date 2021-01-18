using System;
using System.Numerics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SensorsApp.Core
{
    /// <summary>
    /// GPS wrapper
    /// </summary>
    public static class GPS
    {
        private static SensorSpeed speed       = SensorSpeed.UI;
        private static bool        enabledOnce = false;

        private static double velocity;
        private static double latitude;
        private static double longtitude;
        private static double lastLatitude;
        private static double lastLongtitude;

        private static DateTime lastSampleTime = new DateTime();

        public static async Task Update()
        {
            try
            {
                lastLongtitude = longtitude;
                lastLatitude = latitude;

                GeolocationRequest request  = new GeolocationRequest(GeolocationAccuracy.Best);
                Location           location = await Geolocation.GetLocationAsync(request);

                latitude   = location.Latitude;
                longtitude = location.Longitude;

                //velocity = location.Speed.GetValueOrDefault();

                /*
                 * Xamarin je tragédie
                 * location.speed nefunguje, proto musíme počítat manuálně
                 */
                const double earthRadius = 6378.137; // Radius of earth in KM

                double diffLattitude = (latitude * Math.PI / 180) - (lastLatitude * Math.PI / 180);
                double diffLongtitude = (latitude * Math.PI / 180) - (lastLatitude * Math.PI / 180);

                double angle = Math.Sin(diffLattitude / 2) * Math.Sin(diffLattitude / 2) +
                               Math.Cos(lastLatitude * Math.PI / 180) * Math.Cos(latitude * Math.PI / 180) *
                               Math.Sin(diffLongtitude / 2) * Math.Sin(diffLongtitude / 2);

                double curve = 2 * Math.Atan2(Math.Sqrt(angle), Math.Sqrt(1 - angle));
                double distance = earthRadius * curve;

                velocity = (distance * 1000) / (DateTime.Now - lastSampleTime).TotalSeconds; // meters


                lastSampleTime = DateTime.Now;
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
