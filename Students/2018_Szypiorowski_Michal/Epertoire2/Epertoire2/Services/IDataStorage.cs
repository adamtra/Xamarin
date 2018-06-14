using Epertoire2.Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epertoire2.Services
{
    public interface IDataStorage
    {
        Task<CinemaDetails> GetCinema(string name);
        Task<ObservableCollection<Cinema>> GetCinemaRepertoires(string city);
        Task<List<string>> GetCities();
        Task<MovieDetails> GetMovie(long id);
        Task<List<Rating>> GetRating(long cinemaId, long movieId);
    }
}
