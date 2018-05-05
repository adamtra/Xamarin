using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Books.Models;
using Books.ViewModels;

namespace Books.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public Book Book { get; set; }
        NewBookViewModel newBookViewModel;

        public NewBookPage()
        {
            InitializeComponent();

            BindingContext = newBookViewModel = new NewBookViewModel();
         }
     }
 }