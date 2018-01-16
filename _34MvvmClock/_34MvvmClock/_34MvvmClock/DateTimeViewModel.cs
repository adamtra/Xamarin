using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace _34MvvmClock
{
    public class DateTimeViewModel : INotifyPropertyChanged
    {
        DateTime dateTime = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTimeViewModel()
        {
            //Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
            Device.StartTimer(TimeSpan.FromSeconds(3), OnTimerTick);
        }

        bool OnTimerTick()
        {
            DateTime = DateTime.Now;
            return true;
        }

        public DateTime DateTime {
            private set {
                if (dateTime != value)
                {
                    dateTime = value;

                    // Fire the event.
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
                }
            }

            get {
                return dateTime;
            }
        }
    }
}
