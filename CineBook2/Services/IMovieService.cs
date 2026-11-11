using CineBook2.Models;

namespace CineBook2.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync(string? search, int page, int limit);
        Task<Movie?> GetByIdAsync(long id);
    }
}
