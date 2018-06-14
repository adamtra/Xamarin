using Epertoire2.Services;
using Windows.Networking.Connectivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.UWP.Services.Connectivity))]
namespace Epertoire2.UWP.Services
{
    public class Connectivity : IConnectivity
    {
        public bool EnsureInternetAccess()
        {
            var internetConnection = NetworkInformation.GetInternetConnectionProfile();
            if (internetConnection != null)
            {
                var networkConnectivityLevel = internetConnection.GetNetworkConnectivityLevel();
                if (networkConnectivityLevel == NetworkConnectivityLevel.InternetAccess)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
