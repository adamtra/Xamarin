using System;

namespace Epertoire2.Resources
{
    public static class ResourceIdentifier
    {
        public static String CinemaCityUri(string cinemaAdress)
        {
            var cinemaId = cinemaAdress.Split('@')[0];
            return String.Format("https://www.cinema-city.pl/kina/{0}", cinemaId);
        }

        public static string CinemasUri()
        {
            return "https://epertuar.azurewebsites.net/api/v2/Cinema/all";
        }

        public static string CinemaRepertoiresUri(string city)
        {
            return String.Format("https://epertuar.azurewebsites.net/api/Show/{0}", city);
        }

        public static string CityUri()
        {
            return "https://epertuar.azurewebsites.net/api/Cinema/Cities";
        }

        public static string MovieUri(long id)
        {
            return String.Format("https://epertuar.azurewebsites.net/api/Movie/{0}", id);
        }

        public static string MultikinoUri(long id)
        {
            return null;
        }

        public static string RatingUri(long cinemaId, long movieId)
        {
            return String.Format("https://epertuar.azurewebsites.net/api/Rating?IdC={0}&IdMovie={1}", cinemaId, movieId);
        }

        public static string YoutubeUri(string title)
        {
            var search = title.Split(' ');
            return String.Format("https://www.youtube.com/results?search_query={0}", String.Join("+", search));
        }
    }
}
