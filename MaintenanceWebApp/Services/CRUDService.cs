using MaintenanceWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; // Tambahkan ini

namespace MaintenanceWebApp.Services
{
    public class CRUDService
    {
        private readonly DataContext _dbContext;
        public string CRUDErrorMessage { get; private set; } = string.Empty;

        public CRUDService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error creating entity: {ex.Message}";
                // Log the exception details
            }
        }

        public async Task<T?> ReadSingleAsync<T, TId>(TId id) where T : class
        {
            try
            {
                var entity = await _dbContext.Set<T>().FindAsync(id);
                CRUDErrorMessage = string.Empty;
                return entity;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error reading single entity: {ex.Message}";
                // Log the exception details
                return null;
            }
        }

        // Modifikasi metode ReadAllAsync untuk menerima filter dan order by
        public async Task<IQueryable<T>> ReadAllAsync<T>(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool tracking = false) where T : class
        {
            try
            {
                IQueryable<T> query = _dbContext.Set<T>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                if (!tracking)
                {
                    query = query.AsNoTracking();
                }

                CRUDErrorMessage = string.Empty;
                return query; // Mengembalikan IQueryable, tidak dieksekusi di sini
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error reading all entities: {ex.Message}";
                // Log the exception details
                return Enumerable.Empty<T>().AsQueryable(); // Mengembalikan query kosong jika error
            }
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error updating entity: {ex.Message}";
                // Log the exception details
            }
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error deleting entity: {ex.Message}";
                // Log the exception details
            }
        }
    }

    // Perlu menambahkan PredicateBuilder untuk mendukung OrElse pada Expression<Func<T, bool>>
    // Anda bisa membuatnya sendiri atau menggunakan library seperti System.Linq.Expressions.PredicateBuilder
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = expr1.Parameters[0];
            var invokedExpr = Expression.Invoke(expr2, parameter);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), parameter);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = expr1.Parameters[0];
            var invokedExpr = Expression.Invoke(expr2, parameter);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), parameter);
        }
    }
}