using System;
using System.Collections.Generic;
using Android.Content;
using Android.Net.Wifi;
using SensorsApp.Droid.Util;
using SensorsApp.Util;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(Wifi))]
namespace SensorsApp.Droid.Util
{
    public class Wifi: IWifi
    {
        private Context context = null;
        private static WifiManager wifi;
        private WifiReceiver wifiReceiver;
        public static List<string> WiFiNetworks;

        public Wifi()
        {
            this.context = Android.App.Application.Context;
        }

        public void GetWifiNetworks()
        {
            WiFiNetworks = new List<string>();

            // Get a handle to the Wifi
            wifi = (WifiManager)context.GetSystemService(Context.WifiService);

            // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
            wifiReceiver = new WifiReceiver();
            context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            wifi.StartScan();
        }

        class WifiReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                IList<ScanResult> scanwifinetworks = wifi.ScanResults;
                foreach (ScanResult wifinetwork in scanwifinetworks)
                {
                    WiFiNetworks.Add(wifinetwork.Ssid);
                }
            }
        }
    }
}
