namespace CineBook2.Repositories
{
    public interface IRepository <T> where T : class
    {
        Task<T?> GetByIdAsync(long id);
        Task<T?> GetByIdAsync(long id, params string[] includeProperties);
        Task<List<T>> GetAlllAsync();
        Task<List<T>> GetAlllAsync(params string[] includeProperties);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
