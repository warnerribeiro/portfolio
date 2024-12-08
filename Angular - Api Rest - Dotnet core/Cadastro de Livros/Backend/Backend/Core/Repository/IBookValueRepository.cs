using Domain.Model;

namespace Core.Repository
{
    public interface IBookValueRepository
    {
        Task<IEnumerable<BookValue>> GetAsync();

        BookValue? Get(int bookValueId);

        Task<BookValue> AddAsync(BookValue bookValue);

        Task AddAsync(IEnumerable<BookValue> bookValue);

        Task<BookValue> UpdateAsync(BookValue bookValue);

        Task RemoveAsync(int bookValueId);

        Task RemoveAsync(BookValue bookValue);

        Task RemoveAsync(IEnumerable<BookValue> bookValue);
    }
}
