using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookSubjectRepository : IBookSubjectRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<BookSubject> _dbSet;

        public BookSubjectRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.BookSubject;
        }

        public async Task<BookSubject> AddAsync(BookSubject bookSubject)
        {
            await _dbSet.AddAsync(bookSubject);
            await _dataContext.SaveChangesAsync();

            return bookSubject;
        }

        public async Task AddAsync(IEnumerable<BookSubject> bookSubject)
        {
            await _dbSet.AddRangeAsync(bookSubject);
            await _dataContext.SaveChangesAsync();
        }

        public BookSubject? Get(int bookSubjectId)
        {
            return _dbSet.Find(bookSubjectId);
        }

        public async Task<IEnumerable<BookSubject>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task RemoveAsync(int bookSubjectId)
        {
            var bookSubject = Get(bookSubjectId);

            await RemoveAsync(bookSubject);
        }

        public async Task RemoveAsync(IEnumerable<BookSubject> bookSubject)
        {
            _dbSet.RemoveRange(bookSubject);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(BookSubject bookSubject)
        {
            if (bookSubject != null)
            {
                _dbSet.Remove(bookSubject);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<BookSubject> UpdateAsync(BookSubject bookSubject)
        {
            _dbSet.Update(bookSubject);
            await _dataContext.SaveChangesAsync();

            return bookSubject;

        }
    }
}
