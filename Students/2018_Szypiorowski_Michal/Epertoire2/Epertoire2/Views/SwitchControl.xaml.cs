using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwitchControl : ContentView
	{
        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(SwitchControl), false, BindingMode.TwoWay);
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(SwitchControl), null, BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

		public SwitchControl ()
		{
			InitializeComponent ();
		}
	}
}
