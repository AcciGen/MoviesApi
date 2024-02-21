using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApi.DTOs;
using WebApi.Infrastructure;
using WebApi.Models;

namespace WebApi.Applications.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateMovieAsync(Movie model)
        {

            await _context.Movies.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Created a movie";
        }

        public async Task<string> DeleteMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return "Deleted completely";
            }
            return "404 Error";
        }

        public async Task<List<Movie>> GetAllMovieAsync()
        {
            var result = await _context.Movies.ToListAsync();

            return result;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            return result ?? new Movie() { };
        }

        public async Task<string> UpdateMovieAsync(int id, Movie model)
        {
            var result = await _context.Movies.FirstAsync(x => x.Id == id);

            if (result != null)
            {
                result.Id = model.Id;
                result.Title = model.Title;
                result.Category = model.Category;
                result.Budget = model.Budget;
                await _context.SaveChangesAsync();
                return "Updated successfully";
            }
            return "404 Error";
        }
    }
}
