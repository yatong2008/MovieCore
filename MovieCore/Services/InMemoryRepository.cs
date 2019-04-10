using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MovieCore.Models;
using MovieCore.Services.Interfaces;
using MovieCore.ViewModels;

namespace MovieCore.Services
{
    public class InMemoryRepository : IRepository<MovieViewModel>
    {

        private readonly IEnumerable<IMovieService> _movieServices;
        private IEnumerable<MovieViewModel> _allMovies;

        public InMemoryRepository(IEnumerable<IMovieService> movieServices)
        {
            _movieServices = movieServices;
        }


        public async Task<IEnumerable<MovieViewModel>> GetAll()
        {
            _allMovies = new List<MovieViewModel>();
            foreach (IMovieService movieService in _movieServices)
            {
                _allMovies = _allMovies.Concat(await movieService.GetAllAsync());
            }

            return _allMovies;
        }

        public MovieViewModel GetById(string id)
        {
            var movie = _allMovies.FirstOrDefault(x => x.ID == id);
            return movie;
        }

        public async Task<MovieDetails> GetDetailsById(string id)
        {

            foreach (var movieService in _movieServices)
            {
                var result = await movieService.GetDetailsByIdAsync(id);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }


    }
}
