using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using MovieCore.Models;

namespace MovieCore.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public string DatabaseName { get; set; }
    }
}
