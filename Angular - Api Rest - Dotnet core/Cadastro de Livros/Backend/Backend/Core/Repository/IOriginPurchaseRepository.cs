using Domain.Model;

namespace Core.Repository
{
    public interface IOriginPurchaseRepository
    {
        OriginPurchase? Get(int originPurchaseId);

        Task<OriginPurchase> AddAsync(OriginPurchase originPurchase);

        Task<OriginPurchase> UpdateAsync(OriginPurchase originPurchase);

        Task RemoveAsync(int originPurchaseId);

        Task<IEnumerable<OriginPurchase>> GetAsync();
    }
}
