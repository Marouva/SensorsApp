using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            items.Add(new DeviceInfoListItem("test", "test"));
            items.Add(new DeviceInfoListItem("test2", "test2"));

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