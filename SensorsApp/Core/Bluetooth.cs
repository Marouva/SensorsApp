using System;
using System.Collections.Generic;

namespace SensorsApp.Core
{
    public static class Bluetooth
    {
        private static Action changeAction;
        private static Action enableAction;
        private static Action disableAction;

        public static Dictionary<String, String> bluetoothDevices = new Dictionary<string, string>();

        public static void ListChanged()
        {
            changeAction?.Invoke();
        }

        public static void Register()
        {
            enableAction?.Invoke();
        }

        public static void Unregister()
        {
            disableAction?.Invoke();
        }

        public static void SetChangeAction(Action newAction)
        {
            changeAction = newAction;
        }

        public static void SetEnableAction(Action newEnableAction)
        {
            enableAction = newEnableAction;
        }

        public static void SetDisableAction(Action newDisableAction)
        {
            disableAction = newDisableAction;
        }
    }
}
