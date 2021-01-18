using System;
using System.Collections.Generic;

namespace SensorsApp.Core
{
    /// <summary>
    /// WiFI wrapper
    /// </summary>
    public static class Wifi
    {
        private static Action registerAction;
        private static Action unregisterAction;
        private static Action changeAction;
        
        public static Dictionary<String, String> wifiNetworks = new Dictionary<string, string>();

        public static void Register()
        {
            registerAction?.Invoke();
        }
        
        public static void Unregister()
        {
            unregisterAction?.Invoke();
        }
        
        public static void ListChanged()
        {
            changeAction?.Invoke();
        }
        
        public static void SetRegisterAction(Action action)
        {
            registerAction = action;
        }
        
        public static void SetUnregisterAction(Action action)
        {
            unregisterAction = action;
        }
        
        public static void SetChangeAction(Action action)
        {
            changeAction = action;
        }
    }
}
