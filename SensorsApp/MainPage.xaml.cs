﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;

namespace SensorsApp
{
    public partial class MainPage : ContentPage
    {
        public TachometerPage tachometerPage = new TachometerPage();
        public ReceiverPage receiverPage = new ReceiverPage();

        public MainPage()
        {
            Title = "Demo stránka";

            InitializeComponent();
        }

        private async void TachometerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(tachometerPage);
        }

        private async void ReceiverButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(receiverPage);
        }
    }
}
