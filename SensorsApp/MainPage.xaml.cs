using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsApp.Util;
using Xamarin.Forms;
using SkiaSharp;

namespace SensorsApp
{
    public partial class MainPage : ContentPage
    {
        private IWifi wifi;
        public TachometerPage tachometerPage = new TachometerPage();
        public ReceiverPage receiverPage = new ReceiverPage();
        public DeviceInfo deviceInfo = new DeviceInfo();
        public CompassPage compassPage = new CompassPage();

        public MainPage()
        {
            Title = "Demo stránka";

            InitializeComponent();
            this.wifi = DependencyService.Get<IWifi>();
        }

        private async void TachometerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(tachometerPage);
        }

        private async void ReceiverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(receiverPage);
        }

        private async void DeviceInfo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(deviceInfo);
        }

        private async void CompassButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(compassPage);
        }
    }
}
