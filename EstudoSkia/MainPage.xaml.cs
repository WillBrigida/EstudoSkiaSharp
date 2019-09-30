using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace EstudoSkia
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        const double cycleTime = 1000;       // in milliseconds

        //SKCanvasView canvasView;
        Stopwatch stopwatch = new Stopwatch();
        bool pageIsActive;
        float t;

        //SKPaint paint = new SKPaint
        //{
        //    Style = SKPaintStyle.Stroke
        //};

        public MainPage()
        {
            InitializeComponent();
        }

        SKPaint paintStrokeRed = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = Color.Red.ToSKColor(),
            StrokeWidth = 10, // borda
            IsAntialias = true
        };

        SKPaint paintStrokeBlue = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = Color.Blue.ToSKColor(),
            StrokeWidth = 10,
            IsAntialias = true
        };

        SKPaint paintFillOrange= new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = Color.Orange.ToSKColor(),
            IsAntialias = true
        };

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            #region PONTOS CARDEAIS

            var se = new SKPoint(0, 0); // superior esquerdo
            var sd = new SKPoint(info.Width, 0); // superior direito
            var ie = new SKPoint(0, info.Height); // inferior esquerdo
            var id = new SKPoint(info.Width, info.Height); // inferior direito

            var ce = new SKPoint(0, info.Height / 2); // centro esquerdo
            var cd = new SKPoint(info.Width, info.Height / 2); // centro direito
            var cs = new SKPoint(info.Width / 2, 0); // centro superior
            var ci = new SKPoint(info.Width / 2, info.Height); // centro inferior


            var centro = new SKPoint(info.Width / 2, info.Height / 2); // centro
            #endregion

            #region DESENHANDO OS PONTOS NA TELA
            canvas.DrawPoint(centro, paintStrokeRed);

            canvas.DrawPoint(se, paintStrokeRed);
            canvas.DrawPoint(sd, paintStrokeRed);
            canvas.DrawPoint(ie, paintStrokeRed);
            canvas.DrawPoint(id, paintStrokeRed);

            canvas.DrawPoint(ce, paintStrokeRed);
            canvas.DrawPoint(cd, paintStrokeRed);
            canvas.DrawPoint(cs, paintStrokeRed);
            canvas.DrawPoint(ci, paintStrokeRed);
            #endregion

            #region ANIMAÇÃO CIRCULO
            //float baseRadius = Math.Min(info.Width, info.Height) / 12;

            //for (int circle = 0; circle < 1; circle++)
            //{
            //    float radius = baseRadius * (circle + t);

            //    paint2.StrokeWidth = baseRadius / 2 * (circle == 0 ? t : 1);
            //    paint2.Color = new SKColor(0, 0, 255,
            //        (byte)(255 * (circle == 2 ? (1 - t) : 1)));

            //    canvas.DrawCircle(centro, radius, paint2);
            //}
            #endregion

            #region PATH
            SKPath path = new SKPath();

            #region ESTRELA
            //path.MoveTo(0.5f * info.Width, 0 * info.Height);
            //path.LineTo(0 * info.Width, 1 * info.Height);
            //path.LineTo(1 * info.Width, 0.33f * info.Height);
            //path.LineTo(0 * info.Width, 0.33f * info.Height);
            //path.LineTo(1 * info.Width, 1 * info.Height);
            //path.Close();
            //canvas.DrawPath(path, paintStrokeBlue);
            //canvas.DrawPath(path, paintFillOrange);

            #endregion
            #endregion
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            pageIsActive = true;
            stopwatch.Start();
            #region ANIMAÇÃO CIRCULO
            //Device.StartTimer(TimeSpan.FromMilliseconds(5), () =>
            //{
            //    t = (float)(stopwatch.Elapsed.TotalMilliseconds % cycleTime / cycleTime);
            //    SKCanvasView.InvalidateSurface();

            //    if (!pageIsActive)
            //    {
            //        stopwatch.Stop();
            //    }
            //    return pageIsActive;
            //});
            #endregion
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsActive = false;
        }
    }
}
