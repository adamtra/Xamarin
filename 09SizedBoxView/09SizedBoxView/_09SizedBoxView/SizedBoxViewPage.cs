using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace _09SizedBoxView {
    public class SizedBoxViewPage : ContentPage {
        public SizedBoxViewPage() {
            BackgroundColor = Color.Pink;

            Content = new BoxView {
                Color = Color.Navy,
                HorizontalOptions = LayoutOptions.Center, // default is Fill
                VerticalOptions = LayoutOptions.Center,   // default is Fill
                WidthRequest = 200,  // default is 40 WidthRequest = -1
                HeightRequest = 100  // default is 40 HeightRequest = -1
            };
        }
    }
}