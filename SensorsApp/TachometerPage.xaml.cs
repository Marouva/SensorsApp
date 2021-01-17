using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SensorsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TachometerPage : ContentPage
    {
        public const float MeterSpaceAngle = 30.0f;
        public const float MeterMaxVelocity = 150.0f;
        public const int   MinMeterMargin = 150;
        public const int   MeterThickness = 56;

        public double velocity = 0.0;

        private System.Timers.Timer updateTimer = new System.Timers.Timer(500);

        public TachometerPage()
        {
            InitializeComponent();

            updateTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) => { UpdatePage(); };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Core.Gyroscope.Enable();

            UpdatePage();

            updateTimer.Enabled = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Core.Gyroscope.Disable();

            updateTimer.Enabled = false;
        }

        private async void UpdatePage()
        {
            velocity = Core.GPS.GetVelocity() * 3.6; 
            meterCanvas.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;

            UpdateMeter(velocity, info, surface);
        }

        public void UpdateMeter(double velocity, SKImageInfo info, SKSurface surface)
        {
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            int drawResolution = info.Height > info.Width ? info.Width : info.Height;
            int rectResolution = drawResolution - 2 * MinMeterMargin;


            //SKRect rect = new SKRect((info.Width - resolution) / 2, (info.Height - resolution) / 2, resolution, resolution);
            SKRect rect = new SKRect((info.Width - rectResolution) / 2,
                                     (info.Height - rectResolution) / 2,
                                     ((info.Width - rectResolution) / 2) + rectResolution,
                                     ((info.Height - rectResolution) / 2) + rectResolution);

            const float startAngle = -270.0f + MeterSpaceAngle;
            const float sweepAngle = 360.0f - 2.0f * MeterSpaceAngle;

            // Base
            var basePaint = new SKPaint
            {
                TextSize = 64.0f,
                IsAntialias = true,
                Color = new SKColor(192, 204, 218),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = MeterThickness
            };

            SKPath basePath = new SKPath();
            basePath.AddArc(rect, startAngle, sweepAngle);
            canvas.DrawPath(basePath, basePaint);

            // Velocity
            float velocityAngle = (float)Math.Min(Math.Max((sweepAngle * velocity) / MeterMaxVelocity, 0.0f), sweepAngle);

            var velocityPaint = new SKPaint
            {
                TextSize = 64.0f,
                IsAntialias = true,
                Color = new SKColor(230, 100, 100),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = MeterThickness
            };

            SKPath velocityPath = new SKPath();
            velocityPath.AddArc(rect, startAngle, velocityAngle);
            canvas.DrawPath(velocityPath, velocityPaint);

            // Text
            var velocityTextPaint = new SKPaint
            {
                TextSize = 256.0f,
                IsAntialias = true,
                Color = new SKColor(230, 100, 100),
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center
            };

            canvas.DrawText(Math.Round(velocity).ToString(), info.Width / 2.0f, (drawResolution / 2.0f) + 80.0f, velocityTextPaint);

            var unitTextPaint = new SKPaint
            {
                TextSize = 80.0f,
                IsAntialias = true,
                Color = new SKColor(192, 204, 218),
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center
            };

            canvas.DrawText("km/h", info.Width / 2.0f, (drawResolution / 2.0f) + 300.0f, unitTextPaint);
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            //velocity = 0.0f;
            velocity = Core.Gyroscope.GetRotation().X;
            meterCanvas.InvalidateSurface();
        }
    }
}