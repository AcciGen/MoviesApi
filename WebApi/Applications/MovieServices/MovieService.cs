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

        public async Task<string> CreateMovieAsync(Movie movie)
        {
            var model = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Category = movie.Category,
                Budget = movie.Budget
            };
            await _context.Movies.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Created a movie";
        }
    }
}
