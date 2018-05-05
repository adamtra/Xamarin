using System;
//using Windows.ApplicationModel.Contacts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
        {
            var speak = new Button
            {
                Text = "Button !",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            speak.Clicked += (sender, e) => {
                DependencyService.Get<ITextToSpeech>().Speak("Hello from Xamarin Forms");
            };
            //Contact = speak;
            InitializeComponent();
		}
	}
}