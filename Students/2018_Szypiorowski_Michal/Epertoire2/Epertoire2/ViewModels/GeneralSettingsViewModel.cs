using Epertoire2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Epertoire2.ViewModels
{
    public class GeneralSettingsViewModel : ViewModel
    {
        private readonly IApplicationSettings _appSettings;
        private readonly IDataStorage _dataStorage;
        private int _selectedLocationIndex;

        public int SelectedLocationIndex
        {
            get
            {
                if (!Locations.Contains(_appSettings.Location))
                {
                    return _selectedLocationIndex = -1;
                }

                return Locations.IndexOf(_appSettings.Location);
            }

            set
            {
                if (_selectedLocationIndex != value)
                {
                    _selectedLocationIndex = value;
                    _appSettings.Location = Locations[_selectedLocationIndex];
                }
            }
        }

        public List<string> Locations { get; private set; }

        public GeneralSettingsViewModel(IApplicationSettings appSettings, IDataStorage dataStorage)
        {
            _appSettings = appSettings;
            _dataStorage = dataStorage;
            
            Locations = Task.Run(() => _dataStorage.GetCities()).Result;
        }

        public GeneralSettingsViewModel() : this(DependencyService.Get<IApplicationSettings>(), DependencyService.Get<IDataStorage>())
        {

        }
    }
}
