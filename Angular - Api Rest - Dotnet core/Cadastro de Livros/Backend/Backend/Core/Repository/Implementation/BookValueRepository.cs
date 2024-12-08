using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookValueRepository : IBookValueRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<BookValue> _dbSet;

        public BookValueRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.BookValue;
        }

        public async Task<BookValue> AddAsync(BookValue bookValue)
        {
            await _dbSet.AddAsync(bookValue);
            await _dataContext.SaveChangesAsync();

            return bookValue;
        }

        public async Task AddAsync(IEnumerable<BookValue> bookValue)
        {
            await _dbSet.AddRangeAsync(bookValue);
            await _dataContext.SaveChangesAsync();
        }

        public BookValue? Get(int bookValueId)
        {
            return _dbSet.Find(bookValueId);
        }

        public async Task<IEnumerable<BookValue>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task RemoveAsync(int bookValueId)
        {
            var bookValue = Get(bookValueId);

            await RemoveAsync(bookValue);
        }

        public async Task RemoveAsync(IEnumerable<BookValue> bookValue)
        {
            _dbSet.RemoveRange(bookValue);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(BookValue bookValue)
        {
            if (bookValue != null)
            {
                _dbSet.Remove(bookValue);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<BookValue> UpdateAsync(BookValue bookValue)
        {
            _dbSet.Update(bookValue);
            await _dataContext.SaveChangesAsync();

            return bookValue;

        }
    }
}
