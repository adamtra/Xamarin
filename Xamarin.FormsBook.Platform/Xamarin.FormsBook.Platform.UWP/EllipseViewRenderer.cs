using System.ComponentModel;

using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

#if WINDOWS_UWP
using Xamarin.Forms.Platform.UWP;
#else
using Xamarin.Forms.Platform.WinRT;
#endif

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.EllipseView), 
                          typeof(Xamarin.FormsBook.Platform.UWP.EllipseViewRenderer))]

namespace Xamarin.FormsBook.Platform.UWP
{
    public class EllipseViewRenderer : ViewRenderer<EllipseView, Ellipse>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<EllipseView> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new Ellipse());
            }

            if (args.NewElement != null)
            {
                SetColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, 
                                                         PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == EllipseView.ColorProperty.PropertyName)
            {
                SetColor();
            }
        }

        void SetColor()
        {
            if (Element.Color == Xamarin.Forms.Color.Default)
            {
                Control.Fill = null;
            }
            else
            {
                Xamarin.Forms.Color color = Element.Color;

                global::Windows.UI.Color winColor =
                    global::Windows.UI.Color.FromArgb((byte)(color.A * 255),
                                                      (byte)(color.R * 255),
                                                      (byte)(color.G * 255),
                                                      (byte)(color.B * 255));

                Control.Fill = new SolidColorBrush(winColor);
            }
        }
    }
}