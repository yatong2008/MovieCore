using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using MovieCore.Helpers;
using MovieCore.Services;
using MovieCore.Services.Interfaces;
using NSubstitute;
using Xunit;

namespace MovieCore.Tests
{
    public class InMemoryRepositoryTest 
    {
        private readonly IEnumerable<IMovieService> _movieServices;
        private readonly InMemoryRepository _imp;


        public InMemoryRepositoryTest()
        {
            _movieServices = Substitute.For<IEnumerable<IMovieService>>();

            _imp = new InMemoryRepository(_movieServices);
        }

        [Fact]
        public async void EachIMovieServices_ShouldGetAllMovie_WhenInMemoryRepositoryCallGetAll()
        {
            //Arrange

            //Act   
            await _imp.GetAll();

            //Assert
            foreach (var movieService in _movieServices)
            {
                await movieService.Received(1).GetAllAsync();
            }
        }

    }
}
