using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCore.Models;
using MovieCore.ViewModels;

namespace MovieCore.Services.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(string id);
        Task<IEnumerable<MovieDetailsViewModel>> GetDetailsById(string id);
        Task<MovieDetailsViewModel> GetLowerPriceMovieDetailsById(string id);
        Task<IEnumerable<T>> GetMovieSet();

    }
}
