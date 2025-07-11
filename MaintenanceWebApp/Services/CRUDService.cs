using MaintenanceWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceWebApp.Services
{
    public class CRUDService
    {
        private readonly IDbContextFactory<DataContext> _dbFactory;

        public string? CRUDErrorMessage { get; private set; }

        public CRUDService(IDbContextFactory<DataContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        //Create
        public async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                CRUDErrorMessage = $"Objek entitas kosong/null.";
                return;
            }

            using var context = _dbFactory.CreateDbContext();
            try
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateException DBex)
            {
                CRUDErrorMessage = $"DB Exception: {DBex.Message}";
                return;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Exception: {ex.Message}";
                return;
            }
        }

        //Read (Single)
        public async Task<TEntity?> ReadSingleAsync<TEntity, TKey>(TKey id) where TEntity : class
        {
            using var context = _dbFactory.CreateDbContext();
            try
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
            catch (DbUpdateException DBex)
            {
                CRUDErrorMessage = $"DB Exception: {DBex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Exception: {ex.Message}";
                return null;
            }

        }

        //Read (All)
        public async Task<List<TEntity>> ReadAllAsync<TEntity>(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool tracking = false)
        where TEntity : class
        {
            using var context = _dbFactory.CreateDbContext();

            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                // Filter
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                // Order
                if (orderBy != null)
                {
                    query = orderBy(query);
                }
                // Tracking
                if (!tracking)
                {
                    query = query.AsNoTracking();
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Exception: {ex.Message}";
                throw;
            }
        }

        //Update
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                CRUDErrorMessage = $"Objek entitas kosong/null.";
                return;
            }

            using var context = _dbFactory.CreateDbContext();
            try
            {
                context.Update(entity);
                await context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateException DBex)
            {
                CRUDErrorMessage = $"DB Exception: {DBex.Message}";
                return;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Exception: {ex.Message}";
                return;
            }
        }

        //Delete
        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                CRUDErrorMessage = $"Objek entitas kosong/null.";
                return;
            }

            using var context = _dbFactory.CreateDbContext();
            try
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateException DBex)
            {
                CRUDErrorMessage = $"DB Exception: {DBex.Message}";
                return;
            }
            catch (Exception ex)
            {
                CRUDErrorMessage = $"Exception: {ex.Message}";
                return;
            }
        }
    }
}