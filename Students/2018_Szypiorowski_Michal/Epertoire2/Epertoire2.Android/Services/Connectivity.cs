using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Epertoire2.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Droid.Services.Connectivity))]
namespace Epertoire2.Droid.Services
{
    public class Connectivity : IConnectivity
    {
        ConnectivityManager _connectivityManager;

        public Connectivity()
        {
            _connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
        }

        public bool EnsureInternetAccess()
        {
            bool isConnected = false;
            var activeNetwork = _connectivityManager.ActiveNetworkInfo;
            if (activeNetwork != null)
            {
                isConnected = activeNetwork.IsConnected;
            }
            return isConnected;
        }
    }
}