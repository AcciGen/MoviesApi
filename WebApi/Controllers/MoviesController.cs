using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebApi.Applications.MovieServices;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<string> CreateMovie(Movie model)
        {
            var result = await _movieService.CreateMovieAsync(model);

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovieAsync()
        {
            try
            {
                var result = await _movieService.GetAllMovieAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            try
            {
                var result = await _movieService.GetMovieByIdAsync(id);

                if (result is null)
                {
                    return NotFound("404 Not Found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieAsync(int id, Movie model)
        {
            try
            {
                var _model = new Movie()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Category = model.Category,
                    Budget = model.Budget
                };

                await _movieService.UpdateMovieAsync(id, _model);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                await _movieService.DeleteMovieByIdAsync(id);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
