using System.Numerics;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Applications.MovieServices
{
    public interface IMovieService
    {
        public Task<string> CreateMovieAsync(Movie model);
        public Task<List<Movie>> GetAllMovieAsync();
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<string> UpdateMovieAsync(int id, Movie model);
        public Task<string> DeleteMovieByIdAsync(int id);
    }
}
