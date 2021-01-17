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
        private Timer updateTimer = null;
        
        public CompassPage()
        {
            InitializeComponent();
            Compass.AddCallback(() =>
            {
                compassPicture.Rotation = Compass.heading;
            });
            updateTimer = new Timer(OnTimerLapse, null, 2000, Timeout.Infinite);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Compass.Enable();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Compass.Disable();
        }

        private async void OnTimerLapse(Object stateInfo)
        {
            await GPS.Update();
        }
    }
}