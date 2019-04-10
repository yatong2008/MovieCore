using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using MovieCore.Models;

namespace MovieCore.ViewModels
{
    public class MovieDatabase
    {
        public IEnumerable<Movie> Movies;
    }
}
