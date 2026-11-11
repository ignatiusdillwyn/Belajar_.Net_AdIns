using Microsoft.AspNetCore.Mvc;
using CineBook2.Services;

namespace CineBook2.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        public readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet] // GET /api/movies
        public async Task<IActionResult> GetAllovies(
            [FromQuery] string? search, 
            [FromQuery] int page = 1, 
            [FromQuery] int limit = 10

            )
        {
            var movies = await _movieService.GetAllAsync(search, page, limit);
            return Ok(movies);
        }

        /*[HttpGet("{id:long}")] //GET /api/movies/{id}
        public async Task<IActionResult> GetMovie(long id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }*/
    }
}
