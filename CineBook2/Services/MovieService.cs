using CineBook2.Models;
using CineBook2.Repositories;
namespace CineBook2.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllAsync(string? search, int page, int limit)
        {
            List<Movie> movies = await _movieRepository.GetAlllAsync();
            if (!string.IsNullOrEmpty(search))
            {
                movies = movies.Where(m => m.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            }

            return movies
                .Skip((page-1) * limit) //offset
                .Take(limit) //limit
                .ToList();
        }

        public async Task<Movie?> GetByIdAsync(long id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }
    }
}
