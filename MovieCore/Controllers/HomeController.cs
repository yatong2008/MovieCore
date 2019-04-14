using Microsoft.AspNetCore.Mvc;
using MovieCore.Models;
using MovieCore.Services.Interfaces;
using MovieCore.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            var movies = await _repository.SearchMoviesByDigits(id);
            if (movies == null)
            {
                return Redirect("Index");
            }

            var movieDetails = _repository.GetLowerPriceMovieDetails(movies);
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
