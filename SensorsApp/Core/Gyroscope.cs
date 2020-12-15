using System;
using System.Numerics;
using Xamarin.Essentials;

namespace SensorsApp.Core
{
    public static class Gyroscope
    {
        private static SensorSpeed speed       = SensorSpeed.UI;
        private static bool        enabledOnce = false;

        private static Vector3 deltaRotation;
        private static Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

        public static void Enable()
        {
            if (!enabledOnce)
            {
                Xamarin.Essentials.Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                enabledOnce = true;
            }

            Xamarin.Essentials.Gyroscope.Start(speed);
        }

        public static void AddCallback(Action callback)
        {
            Xamarin.Essentials.Gyroscope.ReadingChanged +=
                (object sender, GyroscopeChangedEventArgs args) => { callback(); };
        }

        public static void Disable()
        {
            Xamarin.Essentials.Gyroscope.Stop();
        }

        public static void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            deltaRotation = data.AngularVelocity;
            rotation += data.AngularVelocity;
            System.Diagnostics.Debug.WriteLine("OOF!");
        }

        public static Vector3 GetDeltaRotation()
        {
            return deltaRotation;
        }

        public static Vector3 GetRotation()
        {
            return rotation;
        }
    }
}
