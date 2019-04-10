using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCore.Models;

namespace MovieCore.Services.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(string id);
        Task<MovieDetails> GetDetailsById(string id);
    }
}
