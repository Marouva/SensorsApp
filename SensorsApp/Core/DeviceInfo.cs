using System;

namespace SensorsApp.Core
{
    /// <summary>
    /// DeviceInfo wrapper
    /// </summary>
    public static class DeviceInfo
    {
        public static String GetManufacturer()
        {
            return Xamarin.Essentials.DeviceInfo.Manufacturer;
        }
        
        public static String GetModel()
        {
            return Xamarin.Essentials.DeviceInfo.Model;
        }
        
        public static String GetName()
        {
            return Xamarin.Essentials.DeviceInfo.Name;
        }
        
        public static String GetVersion()
        {
            return Xamarin.Essentials.DeviceInfo.VersionString;
        }
    }
}
