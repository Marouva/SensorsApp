using System;
using System.Collections.Generic;
using Android.Bluetooth;
using Android.Content;
using Android.Net.Wifi;
using Xamarin.Forms.Platform.Android;

namespace SensorsApp.Droid.Core
{
    public static class Wifi
    {
        private static WifiManager wifi;
        private static WifiReceiver wifiReceiver;

        public static void PrepareRegister()
        {
            SensorsApp.Core.Wifi.SetRegisterAction(Register);
            SensorsApp.Core.Wifi.SetUnregisterAction(Unregister);
        }

        public static void Register()
        {
            // Get a handle to the Wifi
            wifi = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);

            // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
            wifiReceiver = new WifiReceiver();
            Android.App.Application.Context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            wifi.StartScan();
        }

        public static void Unregister()
        {
            Android.App.Application.Context.UnregisterReceiver(wifiReceiver);
        }

        class WifiReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                IList<ScanResult> scanwifinetworks = wifi.ScanResults;
                foreach (ScanResult wifinetwork in scanwifinetworks)
                {
                    String? bssid = wifinetwork.Bssid;

                    if (bssid == null)
                    {
                        continue;
                    }

                    if (!SensorsApp.Core.Wifi.wifiNetworks.ContainsKey(bssid))
                    {
                        SensorsApp.Core.Wifi.wifiNetworks.Add(bssid, wifinetwork.Ssid);
                        SensorsApp.Core.Wifi.ListChanged();
                    }
                }
            }
        }
    }
}
