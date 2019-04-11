using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCore.Models;
using MovieCore.Services.Interfaces;
using MovieCore.ViewModels;

namespace MovieCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<MovieViewModel> _repository;

        public HomeController(IRepository<MovieViewModel> repository)
        {
            _repository = repository;
        }

        public async Task<ViewResult> Index()
        {
            var movieList = await _repository.GetMovieSet(); 
            var vms = movieList.Select(x => new MovieViewModel
            {
                ID =  x.ID,
                Title = $"{x.Title}",
                Poster = x.Poster
            });
            return View(vms);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var movieDetails = await _repository.GetLowerPriceMovieDetailsById(id);
            if (movieDetails == null)
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                //return View("NotFound");
                return Redirect("Index");

            return View(movieDetails);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
