using System;
using System.Collections.Generic;
using Android.Content;
using Android.Net.Wifi;
using Xamarin.Forms.Platform.Android;

namespace SensorsApp.Droid.Core
{
    public static class Wifi
    {
        private static WifiManager wifi;
        private static WifiReceiver wifiReceiver;

        public static void UpdateWifiNetworks()
        {
            SensorsApp.Core.Wifi.WiFiNetworks = new List<string>();

            // Get a handle to the Wifi
            wifi = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);

            // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
            wifiReceiver = new WifiReceiver();
            Android.App.Application.Context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            wifi.StartScan();
        }

        class WifiReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                IList<ScanResult> scanwifinetworks = wifi.ScanResults;
                foreach (ScanResult wifinetwork in scanwifinetworks)
                {
                    SensorsApp.Core.Wifi.WiFiNetworks.Add(wifinetwork.Ssid);
                }
            }
        }
    }
}
