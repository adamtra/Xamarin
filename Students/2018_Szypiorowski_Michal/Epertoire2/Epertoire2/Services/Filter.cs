using Epertoire2.Model;
using Epertoire2.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Services.Filter))]
namespace Epertoire2.Services
{
    public class Filter : IFilter
    {
        private bool _genreFiltering;
        private List<Genre> _genres;

        public string Title { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTime { get; set; }

        public Filter()
        {
            // Temporary hardcoded list of genres, this list should be be on the server side
            _genres = new List<Genre>
            {
                new Genre("Action", new List<string>{ "action", "akcj" }),
                new Genre("Adventure", new List<string>{ "adventure", "przygodow" }),
                new Genre("Animation", new List<string>{ "anim" }),
                new Genre("Biographical", new List<string>{ "biogra" }),
                new Genre("Comedy", new List<string>{ "comedy", "komedia" }),
                new Genre("Drama", new List<string>{ "drama" }),
                new Genre("Family", new List<string>{ "famil" }),
                new Genre("Fantasy", new List<string>{ "fantas" }),
                new Genre("Horror", new List<string>{ "horror" }),
                new Genre("Musical", new List<string>{ "music", "muzycz" }),
                new Genre("Romance", new List<string>{ "roman" }),
                new Genre("Sci-Fi", new List<string>{ "sci-fi", "science-fiction" }),
                new Genre("Thriller", new List<string>{ "thriller" })
            };
        }

        public bool Check(object movie)
        {
            var movieToCheck = movie as Movie;
            if (Title != null)
            {
                if (!movieToCheck.Title.Contains(Title))
                {
                    return false;
                }
            }

            if (movieToCheck.Genres != null)
            {
                if (movieToCheck.Genres.Count != 0)
                {
                    var query = from g in _genres where g.IsIn(movieToCheck.Genres) select g.Name;
                    movieToCheck.Genres = query.ToList();

                    if (_genreFiltering && query.Count() == 0)
                    {
                        return false;
                    }
                }
            }

            if (movieToCheck.Shows != null)
            {
                if (movieToCheck.Shows.Count == 0)
                {
                    return false;
                }
            }

            int showsAfter = 0;
            foreach (var show in movieToCheck.Shows)
            {
                if (show.ShowDate.Date.Equals(DateTime.Today))
                {
                    if (StartTime != default(TimeSpan) && EndTime != default(TimeSpan))
                    {
                        var showHour = TimeSpan.Parse(show.Start);
                        if ((showHour > StartTime) && (showHour < EndTime))
                        {
                            showsAfter++;
                        }
                    }
                    else
                    {
                        showsAfter++;
                    }
                }
            }

            if(showsAfter == 0)
            {
                return false;
            }

            return true;
        }

        public Genre GetGenre(string name)
        {
            var query = from genre in _genres where genre.Name.Contains(name) select genre;
            return query.First();
        }

        public void Clear()
        {
            foreach (var genre in _genres)
            {
                genre.IsToggled = false;
            }

            Title = default(string);
            EndTime = default(TimeSpan);
            StartTime = default(TimeSpan);
        }

        public void RefreshStatus()
        {
            foreach (var genre in _genres)
            {
                if (genre.IsToggled)
                {
                    _genreFiltering = true;
                    break;
                }
            }

        }
    }
}
