using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace _02Greetings {
    public class GreetingsPage : ContentPage {
        public GreetingsPage() {
            Content = new Label {
                Text = "Greetings, Xamarin.Forms!",
                // center text
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
                // or 
                //HorizontalTextAlignment = TextAlignment.Center,
                //VerticalTextAlignment = TextAlignment.Center
            };

            // 20 units from the top of the page for all platforms
            // Padding = new Thickness(0, 20, 0, 0);

            // Just for IOS, works only for Shared Asset Project (SAP)
            //#if __IOS__
            //    Padding = new Thickness(0, 20, 0, 0); 
            //#endif

            // PCL version for Android
            // Device.OnPlatform(Android: () => { Padding = new Thickness(0, 20, 0, 0); });
            // More recent version
            switch (Device.RuntimePlatform) {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
                case Device.Android:
                    Padding = new Thickness(0, 0, 0, 0);
                    break;
                case Device.UWP:
                    Padding = new Thickness(0, 0, 0, 0);
                    break;
            }


        }
    }
}