using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowCell : ViewCell
	{
        public static readonly BindableProperty GenresProperty =
            BindableProperty.Create("Genres", typeof(string), typeof(ShowCell), "?", BindingMode.TwoWay);
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create("Rating", typeof(double), typeof(ShowCell), default(double), BindingMode.TwoWay);
        public static readonly BindableProperty ShowsProperty =
            BindableProperty.Create("Shows", typeof(string), typeof(ShowCell), "?", BindingMode.TwoWay);
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ShowCell), "?", BindingMode.TwoWay);

        public string Genres
        {
            get => (string)GetValue(GenresProperty);
            set => SetValue(GenresProperty, value);
        }

        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public string Shows
        {
            get => (string)GetValue(ShowsProperty);
            set => SetValue(ShowsProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

		public ShowCell ()
		{
			InitializeComponent ();
		}

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                TitleLabel.Text = Title;
                GenreLabel.Text = Genres;
                ReadOnlyRatingControl.Value = Rating;
                ShowsLabel.Text = Shows;
            }
        }
    }
}
