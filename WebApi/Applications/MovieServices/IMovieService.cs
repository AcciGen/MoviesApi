using WebApi.Models;

namespace WebApi.Applications.MovieServices
{
    public interface IMovieService
    {
        public Task<string> CreateMovieAsync(Movie model);
    }
}
