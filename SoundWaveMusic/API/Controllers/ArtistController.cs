using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;
                            

namespace SoundWaveMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: api/artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        // GET: api/artist
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
                
            return Ok(artist);
        }

        // POST: api/artist
        public async Task<ActionResult> AddArtist([FromBody] Artist artist)
        {
            await _artistService.AddArtistAsync(artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = artist.ArtistId }, artist);
        }

        // PUT: api/artist
        [HttpPut]
        public async Task<ActionResult> UpdateArtist(int id, [FromBody] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest("Artist ID does not match.");
            }

            await _artistService.UpdatAsync(artist);
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
