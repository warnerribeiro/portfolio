using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    internal class Repository<TEntity>(DataContext dataContext) : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly DbSet<TEntity> _dbSet = dataContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
