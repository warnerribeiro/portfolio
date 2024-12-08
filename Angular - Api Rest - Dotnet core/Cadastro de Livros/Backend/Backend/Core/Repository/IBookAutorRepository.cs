using Domain.Model;

namespace Core.Repository
{
    public interface IBookAutorRepository
    {
        Task<IEnumerable<BookAuthor>> GetAsync();

        BookAuthor? Get(int bookAuthorId);

        Task<BookAuthor> AddAsync(BookAuthor bookAuthor);

        Task AddAsync(IEnumerable<BookAuthor> bookAuthor);

        Task<BookAuthor> UpdateAsync(BookAuthor bookAuthor);

        Task RemoveAsync(int bookAuthorId);

        Task RemoveAsync(BookAuthor bookAuthor);

        Task RemoveAsync(IEnumerable<BookAuthor> bookAuthor);
    }
}
