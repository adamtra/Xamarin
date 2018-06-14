using Epertoire2.Model.Entities;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Epertoire2.Model
{
    public class MovieShows
    {
        public long CinemaId { get; set; }
        public long MovieId { get; set; }
        public string Cinema { get; set; }
        public ImageSource ImageSource { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public string Shows { get; set; }
        public double Rating { get; set; }

        public MovieShows(long cinemaId, long movieId, string cinema, ImageSource imageSource, string title, List<string> genres, List<Show> shows, double rating)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
            Cinema = cinema;
            ImageSource = imageSource;
            Title = title;
            Genres = String.Join(", ", genres.ToArray());
            if (shows.Count != 0)
            {
                var list = new List<string>();
                foreach(var show in shows)
                {
                    if (show.ShowDate.Date.Equals(DateTime.Today))
                    {
                        list.Add(show.Start);
                    }
                }

                Shows = String.Join(", ", list.ToArray());
            }

            Rating = rating;
        }

        public MovieShows(long cinemaId, long movieId, string cinema, string title, List<string> genres, List<Show> shows, double rating) :
            this(cinemaId, movieId, cinema, null, title, genres, shows, rating)
        {

        }
    }
}
