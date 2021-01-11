using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SensorsApp.Core
{
    public static class Bluetooth
    {
        private static Action changeAction;
        private static Action enableAction;

        public static Dictionary<String, String> bluetoothDevices = new Dictionary<string, string>();

        public static void ListChanged()
        {
            changeAction?.Invoke();
        }

        public static void Register()
        {
            enableAction?.Invoke();
        }

        public static void SetAction(Action newAction)
        {
            changeAction = newAction;
        }

        public static void SetEnableAction(Action newEnableAction)
        {
            enableAction = newEnableAction;
        }
    }
}
