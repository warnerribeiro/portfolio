using Domain.Model;

namespace Core.Repository
{
    public interface IBookSubjectRepository
    {
        Task<IEnumerable<BookSubject>> GetAsync();

        BookSubject? Get(int bookSubjectId);

        Task<BookSubject> AddAsync(BookSubject bookSubject);

        Task AddAsync(IEnumerable<BookSubject> bookSubject);

        Task<BookSubject> UpdateAsync(BookSubject bookSubject);

        Task RemoveAsync(int bookSubjectId);

        Task RemoveAsync(BookSubject bookSubject);

        Task RemoveAsync(IEnumerable<BookSubject> bookSubject);
    }
}
