using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SoundWaveMusic.Entities;
using BusinessLayer.Interfaces;
using SoundWaveMusic.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        // GET: api/genre

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreModel>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(_mapper.Map<List<GenreModel>>(genres));
        }

        // GET: api/genre/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreModel>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
                return NotFound();

            return Ok(_mapper.Map<GenreModel>(genre));
        }

        // POST: api/genre

        [HttpPost]
        public async Task<ActionResult<GenreModel>> AddGenre([FromBody] GenreModel genreModel)
        {
            var genre = _mapper.Map<Genre> (genreModel);
            await _genreService.AddGenreAsync(genre);

            var createdModel = _mapper.Map<GenreModel>(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = createdModel.GenreId }, createdModel);
        }

        // PUT: api/genre/{id}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreModel genreModel)
        {
            if (id != genreModel.GenreId)
                return BadRequest("Genre ID does not match");

            var genre = _mapper.Map<Genre>(genreModel);
            await _genreService.UpdateGenreAsync(genre);
            return NoContent();
        }

        // DELETE: api/genre
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}
