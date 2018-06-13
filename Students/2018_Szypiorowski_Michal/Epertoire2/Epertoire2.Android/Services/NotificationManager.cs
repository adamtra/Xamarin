using Android.App;
using Android.Support.Design.Widget;
using Epertoire2.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Droid.Services.NotificationManager))]
namespace Epertoire2.Droid.Services
{
    public class NotificationManager : INotificationManager
    {
        public void CreateToastNotifier(string title, string content, int duration, string action, Action callback)
        {
            var activity = AndroidApp.CurrentContext as Activity;
            var view = activity.FindViewById(Android.Resource.Id.Content);
            var snackbar = Snackbar.Make(view, title, duration * 100);
            if (action != null && callback != null)
            {
                snackbar.SetAction("ok", c => callback());
            }

            snackbar.Show();
        }

        public void CreateToastNotifier(string title, string content, int duration)
        {
            CreateToastNotifier(title, content, duration, null, null);
        }
    }
}