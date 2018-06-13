using Epertoire2.Views;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ProgressIndicator), typeof(Epertoire2.UWP.Renderers.ProgressIndicatorRenderer))]
namespace Epertoire2.UWP.Renderers
{
    public class ProgressIndicatorRenderer : ViewRenderer<ProgressIndicator, ProgressRing>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressIndicator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var progressRing = new ProgressRing();
                SetProperties(e.NewElement, progressRing);
                SetNativeControl(progressRing);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetProperties(Element, Control);
        }

        private void SetProperties(ProgressIndicator element, ProgressRing control)
        {
            var converter = new ColorConverter();
            var solidColorBrush = (SolidColorBrush)converter.Convert(element.Color, typeof(SolidColorBrush), null, null);

            control.Foreground = solidColorBrush;
            if (element.HeightRequest != -1)
            {
                control.Height = element.HeightRequest;
            }

            control.IsActive = element.IsRunning;
            control.IsEnabled = element.IsEnabled;
            if (element.IsVisible)
            {
                control.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                control.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }

            if (element.WidthRequest != -1)
            {
                control.Width = element.WidthRequest;
            }
        }
    }
}
