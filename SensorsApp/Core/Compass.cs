using System;
using Xamarin.Essentials;

namespace SensorsApp.Core
{
    public static class Compass
    {
        private static SensorSpeed speed = SensorSpeed.Fastest;
        private static bool enabledOnce = false;
        public static double heading = 0.0d;
        
        public static void Enable()
        {
            if (!enabledOnce)
            {
                Xamarin.Essentials.Compass.ReadingChanged += CompassOnReadingChanged;
                enabledOnce = true;
            }
            
            Xamarin.Essentials.Compass.Start(speed);
        }

        public static void Disable()
        {
            Xamarin.Essentials.Compass.Stop();
        }

        private static void CompassOnReadingChanged(object sender, CompassChangedEventArgs e)
        {
            CompassData data = e.Reading;
            heading = data.HeadingMagneticNorth * -1;
        }
        
        public static void AddCallback(Action callback)
        {
            Xamarin.Essentials.Compass.ReadingChanged += (object sender, CompassChangedEventArgs args) =>
            {
                callback();
            };
        }
    }
}