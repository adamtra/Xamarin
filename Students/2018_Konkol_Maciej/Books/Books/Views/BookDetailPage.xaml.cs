using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Books.Models;
using Books.ViewModels;

namespace Books.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        BookDetailViewModel viewModel;

        public BookDetailPage(BookDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

      
    }
}