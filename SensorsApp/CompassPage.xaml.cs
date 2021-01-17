using System;
using System.Threading;
using SensorsApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensorsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompassPage : ContentPage
    {
        private System.Timers.Timer updateTimer = new System.Timers.Timer(2000);
        
        public CompassPage()
        {
            InitializeComponent();
            Compass.AddCallback(() =>
            {
                compassPicture.Rotation = Compass.heading;
            });

            updateTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) => { UpdatePage(); };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Compass.Enable();

            UpdatePage();

            updateTimer.Enabled = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Compass.Disable();

            updateTimer.Enabled = false;
        }

        private async void UpdatePage()
        {
            await GPS.Update();

            Device.BeginInvokeOnMainThread(() => 
            {
                latitudeLabel.Text  = GPS.GetLatitude().ToString("0.000000");
                longitudeLabel.Text = GPS.GetLongtitude().ToString("0.000000");
            });
        }
    }
}