using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public const float MeterMaxVelocity = 20.0f;
        public const int   MinMeterMargin = 150;
        public const int   MeterThicknes = 56;

        public float velocity = 7.0f;

        public TachometerPage()
        {
            Title = "Tachometr";

            InitializeComponent();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;

            UpdateMeter(velocity, info, surface);
        }

        public void UpdateMeter(float velocity, SKImageInfo info, SKSurface surface)
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
                StrokeWidth = MeterThicknes
            };

            SKPath basePath = new SKPath();
            basePath.AddArc(rect, startAngle, sweepAngle);
            canvas.DrawPath(basePath, basePaint);

            // Velocity
            float velocityAngle = Math.Min(Math.Max((sweepAngle * velocity) / MeterMaxVelocity, 0.0f), sweepAngle);

            var velocityPaint = new SKPaint
            {
                TextSize = 64.0f,
                IsAntialias = true,
                Color = new SKColor(230, 100, 100),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = MeterThicknes
            };

            SKPath velocityPath = new SKPath();
            velocityPath.AddArc(rect, startAngle, velocityAngle);
            canvas.DrawPath(velocityPath, velocityPaint);

            // Text
            var textPaint = new SKPaint
            {
                TextSize = 256.0f,
                IsAntialias = true,
                Color = new SKColor(230, 100, 100),
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center
            };

            canvas.DrawText(Math.Round(velocity).ToString(), info.Width / 2.0f, (drawResolution / 2.0f) + 96.0f, textPaint);
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            velocity = 0.0f;
            meterCanvas.InvalidateSurface();
        }
    }
}