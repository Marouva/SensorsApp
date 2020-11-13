using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsApp.Util;
using Xamarin.Forms;

namespace SensorsApp
{
    public partial class MainPage : ContentPage
    {
        private IWifi wifi;

        public MainPage()
        {
            InitializeComponent();
            this.wifi = DependencyService.Get<IWifi>();
        }
    }
}
