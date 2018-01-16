using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _40AlertAwait
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertAwaitPage : ContentPage
    {
        public AlertAwaitPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Task<bool> task = DisplayAlert("Simple Alert", "Decide on an option",
                                           "yes or ok", "no or cancel");
            label.Text = "Alert is currently displayed";
            bool result = await task;
            label.Text = String.Format("Alert {0} button was pressed",
                                       result ? "OK" : "Cancel");
        }
    }
}