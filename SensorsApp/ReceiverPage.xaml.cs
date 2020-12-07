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
    public partial class ReceiverPage : ContentPage
    {
        public ReceiverPage()
        {
            InitializeComponent();
        }

        void OnWifiIconPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPath svg = SKPath.ParseSvgPathData("M12,21L15.6,16.2C14.6,15.45 13.35,15 12,15C10.65,15 9.4,15.45 8.4,16.2L12,21M12,3C7.95,3 4.21,4.34 1.2,6.6L3,9C5.5,7.12 8.62,6 12,6C15.38,6 18.5,7.12 21,9L22.8,6.6C19.79,4.34 16.05,3 12,3M12,9C9.3,9 6.81,9.89 4.8,11.4L6.6,13.8C8.1,12.67 9.97,12 12,12C14.03,12 15.9,12.67 17.4,13.8L19.2,11.4C17.19,9.89 14.7,9 12,9Z");                           // O

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Gray,
                StrokeWidth = 1
            };

            SKRect bounds;
            svg.GetTightBounds(out bounds);

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(info.Width / (bounds.Width + paint.StrokeWidth),
                         info.Height / (bounds.Height + paint.StrokeWidth));
            canvas.Translate(-bounds.MidX, -bounds.MidY);

            canvas.DrawPath(svg, paint);


            Core.Wifi.UpdateWifiNetworks();
                
        }

        void OnBluetoothIconPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPath svg = SKPath.ParseSvgPathData("M14.88,16.29L13,18.17V14.41M13,5.83L14.88,7.71L13,9.58M17.71,7.71L12,2H11V9.58L6.41,5L5,6.41L10.59,12L5,17.58L6.41,19L11,14.41V22H12L17.71,16.29L13.41,12L17.71,7.71Z");                           // O

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Gray,
                StrokeWidth = 1
            };

            SKRect bounds;
            svg.GetTightBounds(out bounds);

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(info.Width / (bounds.Width + paint.StrokeWidth),
                         info.Height / (bounds.Height + paint.StrokeWidth));
            canvas.Translate(-bounds.MidX, -bounds.MidY);

            canvas.DrawPath(svg, paint);
        }

        void OnCelltowerIconPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPath svg = SKPath.ParseSvgPathData("M12,10A2,2 0 0,1 14,12C14,12.5 13.82,12.94 13.53,13.29L16.7,22H14.57L12,14.93L9.43,22H7.3L10.47,13.29C10.18,12.94 10,12.5 10,12A2,2 0 0,1 12,10M12,8A4,4 0 0,0 8,12C8,12.5 8.1,13 8.28,13.46L7.4,15.86C6.53,14.81 6,13.47 6,12A6,6 0 0,1 12,6A6,6 0 0,1 18,12C18,13.47 17.47,14.81 16.6,15.86L15.72,13.46C15.9,13 16,12.5 16,12A4,4 0 0,0 12,8M12,4A8,8 0 0,0 4,12C4,14.36 5,16.5 6.64,17.94L5.92,19.94C3.54,18.11 2,15.23 2,12A10,10 0 0,1 12,2A10,10 0 0,1 22,12C22,15.23 20.46,18.11 18.08,19.94L17.36,17.94C19,16.5 20,14.36 20,12A8,8 0 0,0 12,4Z");                           // O

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Gray,
                StrokeWidth = 1
            };

            SKRect bounds;
            svg.GetTightBounds(out bounds);

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(info.Width / (bounds.Width + paint.StrokeWidth),
                         info.Height / (bounds.Height + paint.StrokeWidth));
            canvas.Translate(-bounds.MidX, -bounds.MidY);

            canvas.DrawPath(svg, paint);
        }
    }
}