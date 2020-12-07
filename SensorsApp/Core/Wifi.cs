using System;
using System.Collections.Generic;

namespace SensorsApp.Core
{
    public static class Wifi
    {
        public static List<string> WiFiNetworks;

        public delegate void FuncUpdateWifiNetworks();
        public static FuncUpdateWifiNetworks UpdateWifiNetworks;


    }
}
