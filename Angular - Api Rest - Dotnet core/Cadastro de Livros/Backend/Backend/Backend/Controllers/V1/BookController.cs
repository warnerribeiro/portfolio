using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAsync()
        {
            return Ok(await _bookRepository.GetAsync());
        }

        [HttpGet("{bookId:int}")]
        public async Task<ActionResult<Book>> GetAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);

            if (book == null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostAsync(Book book)
        {
            return Created("", await _bookRepository.AddAsync(book));
        }

        [HttpPut("{bookId:int}")]
        public async Task<ActionResult<Book>> PutAsync(int bookId, Book book)
        {
            if (book == null || bookId != book.BookId)
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }

            return Ok(await _bookRepository.UpdateAsync(book));
        }

        [HttpDelete("{bookId:int}")]
        public async Task<ActionResult> DeleteAsync(int bookId)
        {
            await _bookRepository.RemoveAsync(bookId);
            return Ok();
        }
    }
}
