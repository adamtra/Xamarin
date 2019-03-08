using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizytówki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wizytówki.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonDetailPage : ContentPage
	{
        PersonDetailViewModel viewModel;
        public PersonDetailPage(PersonDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            this.viewModel = viewModel;
        }
	}
}