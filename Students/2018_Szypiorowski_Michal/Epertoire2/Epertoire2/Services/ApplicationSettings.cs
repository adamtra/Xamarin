using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Services.ApplicationSettings))]
namespace Epertoire2.Services
{
    public class ApplicationSettings : IApplicationSettings
    {
        private const string _locationKey = "location";

        private ISettings Settings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public string Location
        {
            get
            {
                return Settings.GetValueOrDefault(_locationKey, default(string));
            }
            set
            {
                Settings.AddOrUpdateValue(_locationKey, value);
            }
        }
    }
}
