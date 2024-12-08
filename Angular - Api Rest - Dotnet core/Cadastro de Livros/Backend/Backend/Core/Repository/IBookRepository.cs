using Domain.Model;

namespace Core.Repository
{
    public interface IBookRepository
    {
        Task<Book?> GetAsync(int bookId);

        Task<Book> AddAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task RemoveAsync(int bookId);

        Task<IEnumerable<Book>> GetAsync();
    }
}
