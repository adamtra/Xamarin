using Epertoire2.Services;
using PropertyChanged;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Epertoire2.ViewModels
{
    public class FilterViewModel : INotifyPropertyChanged
    {
        private readonly IFilter _filter;

        public bool IsActionToggled { get; set; }
        public bool IsAdventureToggled { get; set; }
        public bool IsAnimationToggled { get; set; }
        public bool IsBiographicalToggled { get; set; }
        public bool IsComedyToggled { get; set; }
        public bool IsDramaToggled { get; set; }
        public bool IsFamilyToggled { get; set; }
        public bool IsFantasyToggled { get; set; }

        private bool _isHorrorToggled;

        public event PropertyChangedEventHandler PropertyChanged;

        [DoNotNotify]
        public bool IsHorrorToggled
        {
            get { return _isHorrorToggled; }
            set
            {
                if (_isHorrorToggled != value)
                {
                    _isHorrorToggled = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsHorrorToggled"));
                }
            }
        }
        public bool IsMusicalToggled { get; set; }
        public bool IsRomanceToggled { get; set; }
        public bool IsSciFiToggled { get; set; }
        public bool IsThrillerToggled { get; set; }
        public string Title { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTime { get; set; }

        [DoNotNotify]
        public ICommand ApplyFilterCommand { get; set; }

        [DoNotNotify]
        public ICommand ClearFilterCommand { get; set; }

        public FilterViewModel(IFilter filter)
        {
            _filter = filter;
            IsActionToggled = _filter.GetGenre("Action").IsToggled;
            IsAdventureToggled = _filter.GetGenre("Adventure").IsToggled;
            IsAnimationToggled = _filter.GetGenre("Animation").IsToggled;
            IsBiographicalToggled = _filter.GetGenre("Biographical").IsToggled;
            IsComedyToggled = _filter.GetGenre("Comedy").IsToggled;
            IsDramaToggled = _filter.GetGenre("Drama").IsToggled;
            IsFamilyToggled = _filter.GetGenre("Family").IsToggled;
            IsFantasyToggled = _filter.GetGenre("Fantasy").IsToggled;
            IsHorrorToggled = _filter.GetGenre("Horror").IsToggled;
            IsMusicalToggled = _filter.GetGenre("Musical").IsToggled;
            IsRomanceToggled = _filter.GetGenre("Romance").IsToggled;
            IsSciFiToggled = _filter.GetGenre("Sci-Fi").IsToggled;
            IsThrillerToggled = _filter.GetGenre("Thriller").IsToggled;
            Title = _filter.Title;
            EndTime = _filter.EndTime;
            StartTime = _filter.StartTime;

            ApplyFilterCommand = new Command(ApplyFilter);
            ClearFilterCommand = new Command(ClearFilter);
        }

        public FilterViewModel() : this(DependencyService.Get<IFilter>())
        {

        }

        private void ApplyFilter()
        {
            _filter.GetGenre("Action").IsToggled = IsActionToggled;
            _filter.GetGenre("Adventure").IsToggled = IsAdventureToggled;
            _filter.GetGenre("Animation").IsToggled = IsAnimationToggled;
            _filter.GetGenre("Biographical").IsToggled = IsBiographicalToggled;
            _filter.GetGenre("Comedy").IsToggled = IsComedyToggled;
            _filter.GetGenre("Drama").IsToggled = IsDramaToggled;
            _filter.GetGenre("Family").IsToggled = IsFamilyToggled;
            _filter.GetGenre("Fantasy").IsToggled = IsFantasyToggled;
            _filter.GetGenre("Horror").IsToggled = IsHorrorToggled;
            _filter.GetGenre("Musical").IsToggled = IsMusicalToggled;
            _filter.GetGenre("Sci-Fi").IsToggled = IsSciFiToggled;
            _filter.GetGenre("Thriller").IsToggled = IsThrillerToggled;
            _filter.Title = Title;
            _filter.EndTime = EndTime;
            _filter.StartTime = StartTime;
            _filter.RefreshStatus();
        }

        private void ClearFilter()
        {
            IsActionToggled = false;
            IsAdventureToggled = false;
            IsAnimationToggled = false;
            IsBiographicalToggled = false;
            IsComedyToggled = false;
            IsDramaToggled = false;
            IsFamilyToggled = false;
            IsFantasyToggled = false;
            IsHorrorToggled = false;
            IsMusicalToggled = false;
            IsRomanceToggled = false;
            IsSciFiToggled = false;
            IsThrillerToggled = false;
            Title = default(string);
            EndTime = default(TimeSpan);
            StartTime = default(TimeSpan);
        }
    }
}
