using SensorsApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensorsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompassPage : ContentPage
    {
        public CompassPage()
        {
            InitializeComponent();
            Compass.AddCallback(() =>
            {
                compassPicture.Rotation = Compass.heading;
            });
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
    }
}