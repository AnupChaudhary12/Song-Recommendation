using System.Linq.Expressions;

namespace SongRecommendation.Application.Contracts.Persistence
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
		Task<List<T>> GetAllAsync(string? includeProperties = null);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task DeleteRangeAsync(IEnumerable<T> entities);
	}
}
