using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieCore.Helpers;
using MovieCore.Services;
using MovieCore.Services.Interfaces;
using MovieCore.ViewModels;
using NSubstitute;
using Xunit;

namespace MovieCore.Tests
{
    public class InMemoryRepositoryTest 
    {
        private IEnumerable<IMovieService> _movieServices;
        private readonly InMemoryRepository _imp;
        private readonly List<MovieViewModel> _movieSet = new List<MovieViewModel>
        {
            new MovieViewModel
            {
                ID ="fw0076759",
                DatabaseName = "filmworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BOTIyMDY2NGQtOGJjNi00OTk4LWFhMDgtYmE3M2NiYzM0YTVmXkEyXkFqcGdeQXVyNTU1NTfwOTk@._V1_SX300.jpg",
                Title = "Star Wars: Episode IV - A New Hope",
                Type ="movie",
                Year = "1977"
            },
            new MovieViewModel
            {
                ID ="fw0080684",
                DatabaseName = "filmworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BMjE2MzQwMTgxN15BMl5BanBnXkFtZTfwMDQzNjk2OQ@@._V1_SX300.jpg",
                Title = "Star Wars: Episode V - The Empire Strikes Back",
                Type ="movie",
                Year = "1980"
            }
        };

        private readonly List<MovieDetailsViewModel> _movieDetailsSet = new List<MovieDetailsViewModel>
        {
            new MovieDetailsViewModel
            {
                Actors = "Liam Neeson, Ewan McGregor, Natalie Portman, Jake Lloyd",
                Awards = "Nominated for 3 Oscars. Another 24 wins & 60 nominations.",
                Country = "USA",
                DatabaseName = "cinemaworld",
                Director = "George Lucas",
                Genre = "Action, Adventure, Fantasy",
                ID = "cw0120915",
                Language = "English",
                Metascore = 51,
                Plot = "Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to reclaim their old glory.",
                Poster = "http://ia.media-imdb.com/images/M/MV5BMTQ4NjEwNDA2Nl5BMl5BanBnXkFtZTcwNDUyNDQzNw@@._V1_SX300.jpg",
                Price = 123343.5,
                Rated = "PG",
                Rating = 6.5,
                Released = "19 May 1999",
                Runtime = "136 min",
                Title = "Star Wars = Episode I - The Phantom Menace",
                Type = "movie",
                Votes = "537,242",
                Writer = "George Lucas",
                Year = "1999"
            }, 
            new MovieDetailsViewModel()
            {
                Actors = "Liam Neeson, Ewan McGregor, Natalie Portman, Jake Lloyd",
                Awards = null,
                Country = "USA",
                DatabaseName = "filmworld",
                Director = "George Lucas",
                Genre = "Action, Adventure, Fantasy",
                ID = "fw0120915",
                Language = "English",
                Metascore = 51,
                Plot = "Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to reclaim their old glory.",
                Poster = "http://ia.media-imdb.com/images/M/MV5BMTQ4NjEwNDA2Nl5BMl5BanBnXkFtZTfwNDUyNDQzNw@@._V1_SX300.jpg",
                Price = 900.5,
                Rated = "PG",
                Rating = 6.5,
                Released = "19 May 1999",
                Runtime = "136 min",
                Title = "Star Wars = Episode I - The Phantom Menace",
                Type = "movie",
                Votes = "537,242",
                Writer = "George Lucas",
                Year = "1999"
            }
        };


        public InMemoryRepositoryTest()
        {
            _movieServices = new List<IMovieService>()
            {
                Substitute.For<IMovieService>()
            };

            _imp = new InMemoryRepository(_movieServices);
            
        }

        [Fact]
        public async void EachIMovieServices_ShouldGetAllMovie_WhenInMemoryRepositoryCallGetAll()
        {
            //Arrange
            _movieServices = Substitute.For<IEnumerable<IMovieService>>();

            //Act   
            await _imp.GetAll();

            //Assert
            foreach (var movieService in _movieServices)
            {
                await movieService.Received(1).GetAllAsync();
            }
        }

        [Fact]
        public void GetLowerPriceMove_ShouldReturn_CorrectResult()
        {

            var result = _imp.GetLowerPriceMovieDetails(_movieDetailsSet);

            Assert.Equal("filmworld", result?.DatabaseName);
        }
    }
}
