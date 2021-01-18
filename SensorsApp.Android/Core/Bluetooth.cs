using System;
using Android.Bluetooth;
using Android.Content;

namespace SensorsApp.Droid.Core
{
    /// <summary>
    /// BlueTooth Android wrapper
    /// </summary>
    public static class Bluetooth
    {
        private static BluetoothDeviceReceiver receiver;

        public static void PrepareRegister()
        {
            Console.WriteLine("Registering events");
            SensorsApp.Core.Bluetooth.SetEnableAction(Register);
            
            SensorsApp.Core.Bluetooth.SetDisableAction(Unregister);
        }

        public static void Register()
        {
            Console.WriteLine("Registering event listener for Bluetooth");
            BluetoothAdapter bta = BluetoothAdapter.DefaultAdapter;

            if (bta == null || !bta.IsEnabled)
            {
                Console.WriteLine("Device does not support Bluetooth");
                return;
            }

            // Find nearest blueetoth devices
            receiver = new BluetoothDeviceReceiver();
            Android.App.Application.Context.RegisterReceiver(receiver, new IntentFilter(BluetoothDevice.ActionFound));
            bta.StartDiscovery();
        }

        public static void Unregister()
        {
            Android.App.Application.Context.UnregisterReceiver(receiver);
        }
    }

    class BluetoothDeviceReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context? context, Intent? intent)
        {
            Console.WriteLine("Bluetooth event received");
            
            if (intent == null) return;

            string action = intent.Action;

            if (action != BluetoothDevice.ActionFound) return;

            BluetoothDevice bluetoothDevice = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

            if (bluetoothDevice == null)
            {
                return;
            }

            string bluetoothDeviceName = bluetoothDevice.Name;
            string bluetoothDeviceAddress = bluetoothDevice.Address;

            if (bluetoothDeviceName == null) return;

            if (!SensorsApp.Core.Bluetooth.bluetoothDevices.ContainsKey(bluetoothDeviceAddress))
            {
                SensorsApp.Core.Bluetooth.bluetoothDevices.Add(bluetoothDeviceAddress, bluetoothDeviceName);
                SensorsApp.Core.Bluetooth.ListChanged();
            }
        }
    }
}