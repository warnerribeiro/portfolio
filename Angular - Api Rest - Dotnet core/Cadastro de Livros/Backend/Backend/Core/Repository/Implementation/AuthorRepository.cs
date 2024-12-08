using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Author> _dbSet;

        public AuthorRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.Author;
        }

        public IQueryable<Author> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<Author?> Get(int authorId)
        {
            return await _dbSet.FindAsync(authorId);
        }

        public async Task<Author> AddAsync(Author author)
        {
            await _dbSet.AddAsync(author);
            await _dataContext.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _dbSet.Update(author);
            await _dataContext.SaveChangesAsync();

            return author;
        }

        public async Task RemoveAsync(int authorId)
        {
            var author = await Get(authorId);

            if (author != null)
            {
                _dbSet.Remove(author);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
