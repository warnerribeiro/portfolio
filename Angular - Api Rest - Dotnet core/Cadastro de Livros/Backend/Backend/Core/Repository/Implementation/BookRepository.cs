using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookSubjectRepository _bookSubjectRepository;
        private readonly IBookAutorRepository _bookAutorRepository;
        private readonly IBookValueRepository _bookValueRepository;
        private readonly DataContext _dataContext;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(DataContext datacontext,
            IBookSubjectRepository bookSubjectRepository,
            IBookAutorRepository bookAutorRepository,
            IBookValueRepository bookValueRepository)
        {
            _dataContext = datacontext;
            _bookAutorRepository = bookAutorRepository;
            _bookSubjectRepository = bookSubjectRepository;
            _bookValueRepository = bookValueRepository;
            _dbSet = _dataContext.Book;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetAsync(int bookId)
        {
            return await _dbSet
                .Include(a => a.BookAuthor)
                .Include(a => a.BookSubject)
                .Include(a => a.BookValue)
                .SingleAsync(a => a.BookId == bookId);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbSet.AddAsync(book);
            await _dataContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateAsync(Book bookView)
        {
            var bookModel = await GetAsync(bookView.BookId);

            _dataContext.Entry(bookModel).CurrentValues.SetValues(bookView);

            await _bookAutorRepository.RemoveAsync(bookModel.BookAuthor);
            await _bookAutorRepository.AddAsync(bookView.BookAuthor);

            await _bookSubjectRepository.RemoveAsync(bookModel.BookSubject);
            await _bookSubjectRepository.AddAsync(bookView.BookSubject);

            await _bookValueRepository.RemoveAsync(bookModel.BookValue);
            await _bookValueRepository.AddAsync(bookView.BookValue);

            await _dataContext.SaveChangesAsync();

            return bookModel;
        }

        public async Task RemoveAsync(int bookId)
        {
            var book = await GetAsync(bookId);

            if (book != null)
            {
                _dbSet.Remove(book);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
