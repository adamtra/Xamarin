using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _39AlertCallbacks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertCallbacksPage : ContentPage
    {
        bool result;

        public AlertCallbacksPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1),
                () =>
                {
                    label.Text = DateTime.Now.ToString();
                    return true;
                });
        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            // APM style tasks: callbacks
            // promise a bool in the future
            Task<bool> task = DisplayAlert("Simple Alert", "Decide on an option",
                                           "yes or ok", "no or cancel");
            task.ContinueWith(AlertDismissedCallback);
            // lambda version
            //task.ContinueWith((Task<bool> taskResult) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        label.Text = String.Format("Alert {0} button was pressed",
            //            taskResult.Result ? "OK" : "Cancel");
            //    });
            //});
            label.Text = "Alert is currently displayed";
        }

        void AlertDismissedCallback(Task<bool> task)
        {
            result = task.Result;
            // call DisplayResultCallback in UI thread
            Device.BeginInvokeOnMainThread(DisplayResultCallback);
        }

        void DisplayResultCallback()
        {
            label.Text = String.Format("Alert {0} button was pressed",
                                       result ? "OK" : "Cancel");
        }
    }
}