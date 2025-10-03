using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.Models;
using AutoMapper;
using SoundWaveMusic.Entities;
using BusinessLayer.Interfaces;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        // GET: api/artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(_mapper.Map<List<ArtistModel>>(artists));
        }

        // GET: api/artist/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
                return NotFound();
            
            return Ok(_mapper.Map<ArtistModel>(artist));
        }

        //GET: api/artist/genre/{genreId}
        [HttpGet("genre/{genreId}")]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetArtistsByGenreId(int genreId)
        {
            var artists = await _artistService.GetGenreByIdAsync(genreId);
            return Ok(_mapper.Map<List<ArtistModel>>(artists));
        }

        // POST: api/artist
        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistModel artistModel)
        {
            var artist = _mapper.Map<Artist>(artistModel);
            await _artistService.AddArtistAsync(artist);

            var createdModel = _mapper.Map<ArtistModel>(artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = createdModel.ArtistId }, createdModel);
        }

        // PUT: api/artist
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] ArtistModel artistModel)
        {
            if (id != artistModel.ArtistId)
                return BadRequest("Artist ID does not match.");

            var artist = _mapper.Map<Artist>(artistModel);
            await _artistService.UpdateAsync(artist);
            return NoContent();
        }

        // DELETE: api/artist
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            await _artistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
