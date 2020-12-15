using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SensorsApp.Core.DeviceInfo;

namespace SensorsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfo : ContentPage
    {
        public DeviceInfo()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<DeviceInfoListItem> items = new List<DeviceInfoListItem>();
            items.Add(new DeviceInfoListItem("Výrobce", GetManufacturer()));
            items.Add(new DeviceInfoListItem("Model", GetModel()));
            items.Add(new DeviceInfoListItem("Název zařízení", GetName()));
            items.Add(new DeviceInfoListItem("Verze OS", GetVersion()));

            infoList.ItemsSource = items;
        }
    }

    public class DeviceInfoListItem
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public DeviceInfoListItem(String Name, String Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}