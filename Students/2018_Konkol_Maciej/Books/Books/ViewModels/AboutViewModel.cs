using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Books.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "O autorze";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.linkedin.com/in/maciej-konkol-684b8210a/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}