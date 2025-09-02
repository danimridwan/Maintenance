using MaintenanceWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; // Tambahkan ini

namespace MaintenanceWebApp.Services
{
    public class CRUDService
    {
        // This is the only field you need now.
        private readonly DbContextOptions<DataContext> _options;
        public string CRUDErrorMessage { get; private set; } = string.Empty;

        // This is the only constructor you need now.
        // It receives the DbContextOptions instance from the dependency injection container.
        public CRUDService(DbContextOptions<DataContext> options)
        {
            _options = options;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            try
            {
                // Create a new DataContext for this operation.
                using (var context = new DataContext(_options))
                {
                    await context.Set<T>().AddAsync(entity);
                    await context.SaveChangesAsync();
                }
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
                // Create a new DataContext for this operation, as requested.
                using (var context = new DataContext(_options))
                {
                    var entity = await context.Set<T>().FindAsync(id);
                    CRUDErrorMessage = string.Empty;
                    return entity;
                }
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error reading single entity: {ex.Message}";
                return null;
            }
        }

        public async Task<IQueryable<T>> ReadAllAsync<T>(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool tracking = false) where T : class
        {
            try
            {
                // Create a new DataContext for this operation.
                var context = new DataContext(_options);
                IQueryable<T> query = context.Set<T>();

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
                return query;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error reading all entities: {ex.Message}";
                return Enumerable.Empty<T>().AsQueryable();
            }
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                // Create a new DataContext for this operation.
                using (var context = new DataContext(_options))
                {
                    context.Set<T>().Update(entity);
                    await context.SaveChangesAsync();
                }
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error updating entity: {ex.Message}";
            }
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                // Create a new DataContext for this operation.
                using (var context = new DataContext(_options))
                {
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();
                }
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error deleting entity: {ex.Message}";
            }
        }

        // --- CRUDServices.cs ---
        public async Task DeleteByConditionAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                using (var context = new DataContext(_options))
                {
                    // Temukan semua entitas yang cocok dengan kondisi (predicate)
                    var entities = await context.Set<T>().Where(predicate).ToListAsync();

                    // Jika ditemukan, hapus entitas-entitas tersebut
                    if (entities.Any())
                    {
                        context.Set<T>().RemoveRange(entities);
                        await context.SaveChangesAsync();
                    }
                }
                CRUDErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error deleting entities by condition: {ex.Message}";
            }
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>>? filter = null) where T : class
        {
            try
            {
                using (var context = new DataContext(_options))
                {
                    IQueryable<T> query = context.Set<T>();

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }
                    return await query.CountAsync();
                }
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Error counting entities: {ex.Message}";
                return 0;
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