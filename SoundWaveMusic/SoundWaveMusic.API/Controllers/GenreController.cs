using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/genre

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // POST: api/genre

        [HttpPost]
        public async Task<ActionResult> AddGenre([FromBody] Genre genre)
        {
            await _genreService.AddGenreAsync(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.GenreId }, genre);
        }

        // PUT: api/genre

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGenre(int id, [FromBody] Genre genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest("Genre ID does not match");
            }
                
            await _genreService.UpdateGenreAsync(genre);
            return NoContent();
        }

        // DELETE: api/genre
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}
