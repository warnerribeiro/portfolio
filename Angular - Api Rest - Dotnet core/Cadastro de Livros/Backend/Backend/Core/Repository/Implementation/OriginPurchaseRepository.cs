using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class OriginPurchaseRepository : IOriginPurchaseRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<OriginPurchase> _dbSet;

        public OriginPurchaseRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.OriginPurchase;
        }

        public async Task<IEnumerable<OriginPurchase>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public OriginPurchase? Get(int originPurchaseId)
        {
            return _dbSet.Find(originPurchaseId);
        }

        public async Task<OriginPurchase> AddAsync(OriginPurchase originPurchase)
        {
            await _dbSet.AddAsync(originPurchase);
            await _dataContext.SaveChangesAsync();

            return originPurchase;
        }

        public async Task<OriginPurchase> UpdateAsync(OriginPurchase originPurchase)
        {
            _dbSet.Update(originPurchase);
            await _dataContext.SaveChangesAsync();

            return originPurchase;
        }

        public async Task RemoveAsync(int originPurchaseId)
        {
            var originPurchase = Get(originPurchaseId);

            if (originPurchase != null)
            {
                _dbSet.Remove(originPurchase);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
