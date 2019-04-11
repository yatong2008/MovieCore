using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCore.Models;
using MovieCore.ViewModels;

namespace MovieCore.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetAllAsync();
        Task<MovieDetailsViewModel> GetDetailsByIdAsync(string id);
    }
}
