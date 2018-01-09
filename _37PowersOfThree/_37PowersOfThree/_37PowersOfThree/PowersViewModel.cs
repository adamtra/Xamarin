using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace _37PowersOfThree
{
    class PowersViewModel : ViewModelBase
    {
        double exponent, power;

        public PowersViewModel(double baseValue)
        {
            // Initialize properties.
            BaseValue = baseValue;
            Exponent = 0;

            // Initialize ICommand properties.
            IncreaseExponentCommand = new Command(ExecuteIncreaseExponent);
            DecreaseExponentCommand = new Command(ExecuteDecreaseExponent);
            // or using lambda
            //IncreaseExponentCommand = new Command(() => { Exponent += 1; });
            //DecreaseExponentCommand = new Command(() => { Exponent -= 1; });
        }

        void ExecuteIncreaseExponent()
        {
            Exponent += 1;
        }

        void ExecuteDecreaseExponent()
        {
            Exponent -= 1;
        }

        public double BaseValue { private set; get; }

        public double Exponent {
            private set {
                if (SetProperty(ref exponent, value))
                {
                    Power = Math.Pow(BaseValue, exponent);
                }
            }
            get {
                return exponent;
            }
        }

        public double Power {
            private set { SetProperty(ref power, value); }
            get { return power; }
        }

        public ICommand IncreaseExponentCommand { private set; get; }

        public ICommand DecreaseExponentCommand { private set; get; }
    }
}
