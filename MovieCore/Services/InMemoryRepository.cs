using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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

        public async Task<IEnumerable<MovieViewModel>> GetMovieSet()
        {
            _allMovies = await GetAll();

            List<MovieViewModel> distinctMovies = _allMovies
                .GroupBy(x => x.Title)
                .Select(g => g.First())
                .ToList();

            return distinctMovies;
        }

        public MovieViewModel GetById(string id)
        {
            var movie = _allMovies.FirstOrDefault(x => x.ID == id);
            return movie;
        }

        public async Task<IEnumerable<MovieDetailsViewModel>> GetDetailsById(string id)
        {
            var results = new List<MovieDetailsViewModel>();

            foreach (var movieService in _movieServices)
            {
                var movieDetails = await movieService.GetDetailsByIdAsync(id);
                if (movieDetails != null)
                {
                    results.Add(movieDetails);
                }
            }

            return results;
        }

        public async Task<MovieDetailsViewModel> GetLowerPriceMovieDetailsById(string id)
        {
            var allowedChars = Enumerable.Range('0', 10);
            var searchString = String.Concat(id.Where(c => allowedChars.Contains(c)));

            var movieIdsFromAllDatabase = (await GetAll()).Where(x => x.ID.Contains(searchString)).Select(x => x.ID).ToList();

            var movies = await GetDetailsById(searchString);

            return movies.OrderBy(x => x.Price).FirstOrDefault();
        }


    }
}
