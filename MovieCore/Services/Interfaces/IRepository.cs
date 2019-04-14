using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCore.Models;
using MovieCore.ViewModels;

namespace MovieCore.Services.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<MovieDetailsViewModel>> GetDetailsById(string id);
        Task<IEnumerable<T>> GetMovieSet();
        Task<IEnumerable<MovieDetailsViewModel>> SearchMoviesByDigits(string id);
        MovieDetailsViewModel GetLowerPriceMovieDetails(IEnumerable<MovieDetailsViewModel> movieSet);
    }
}
