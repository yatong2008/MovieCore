using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MovieCore.Helpers;
using MovieCore.Models;
using MovieCore.Services.Interfaces;
using MovieCore.ViewModels;

namespace MovieCore.Services
{
    public class CinemaWorldMovieService : IMovieService
    {
        private const string DatabaseName = "cinemaworld";
        private const string WebsiteDomain = "http://webjetapitest.azurewebsites.net";
        
        public async Task<List<MovieViewModel>> GetAllAsync()
        {
            string url = $"{WebsiteDomain}/api/{DatabaseName}/movies";

            var responseData = await HtmlGetHelper.GetResult(url);

            MovieDatabase mdb = JsonMovieHelper.DeserializeJson<MovieDatabase>(responseData);

            var movies = new List<MovieViewModel>();

            foreach (var m in mdb.Movies)
            {
                movies.Add(new MovieViewModel()
                {
                    ID = m.ID,
                    DatabaseName = DatabaseName,
                    Poster = m.Poster,
                    Title = m.Title,
                    Type = m.Type,
                    Year = m.Year
                });
            }

            

            return movies;
        }


        public async Task<MovieDetailsViewModel> GetDetailsByIdAsync(string id)
        {
            string url = $"{WebsiteDomain}/api/{DatabaseName}/movie/cw{id}";

            var responseData = await HtmlGetHelper.GetResult(url);

            MovieDetails details = JsonMovieHelper.DeserializeJson<MovieDetails>(responseData);

            return new MovieDetailsViewModel
                {
                Title = details.Title,
                Year = details.Year,
                Rated = details.Rated,
                Released = details.Released,
                Runtime = details.Runtime,
                Genre = details.Genre,
                Director = details.Director,
                Writer = details.Writer,
                Actors = details.Actors,
                Plot = details.Plot,
                Language = details.Language,
                Country = details.Country,
                Awards = details.Awards,
                Poster = details.Poster,
                Metascore = details.Metascore,
                Rating = details.Rating,
                Votes = details.Votes,
                ID = details.ID,
                Type = details.Type,
                Price = details.Price,
                DatabaseName = DatabaseName
            };
        }
    }
}
