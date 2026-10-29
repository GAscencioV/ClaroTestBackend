using ClaroTestBackend.Core.Application.Dto.Books;
using ClaroTestBackend.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaroTestBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll(CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllAsync(cancellationToken);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetByIdAsync(id, cancellationToken);
            if (book is null)
                return NotFound(new { message = $"Book with ID {id} not found." });

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto dto, CancellationToken cancellationToken)
        {
            var created = await _bookService.CreateAsync(dto, cancellationToken);
            if (created is null)
                return BadRequest(new { message = "Could not create the book." });

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] UpdateBookDto dto, CancellationToken cancellationToken)
        {
            var updated = await _bookService.UpdateAsync(id, dto, cancellationToken);
            if (updated is null)
                return NotFound(new { message = $"Book with ID {id} not found." });

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _bookService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound(new { message = $"Book with ID {id} not found." });

            return NoContent();
        }
    }
}
