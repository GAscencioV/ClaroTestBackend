using ClaroTestBackend.Core.Application.Dto.Authors;
using ClaroTestBackend.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaroTestBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll(CancellationToken cancellationToken)
        {
            var authors = await _authorService.GetAllAsync(cancellationToken);
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var author = await _authorService.GetByIdAsync(id, cancellationToken);
            if (author is null)
                return NotFound(new { message = $"Author with ID {id} not found." });

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] CreateAuthorDto dto, CancellationToken cancellationToken)
        {
            var created = await _authorService.CreateAsync(dto, cancellationToken);
            if (created is null)
                return BadRequest(new { message = "Could not create the author." });

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] UpdateAuthorDto dto, CancellationToken cancellationToken)
        {
            var updated = await _authorService.UpdateAsync(id, dto, cancellationToken);
            if (updated is null)
                return NotFound(new { message = $"Author with ID {id} not found." });

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _authorService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound(new { message = $"Author with ID {id} not found." });

            return NoContent();
        }
    }
}
