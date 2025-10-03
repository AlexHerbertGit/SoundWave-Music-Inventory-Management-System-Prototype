using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET: api/album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            return Ok(albums);
        }

        // GET: api/album/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbumById(int id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            
            return Ok(album);
        }

        // GET: api/album/artist/{artistId}
        [HttpGet("artist/{artistId}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByArtist(int id)
        {
            var albums = await _albumService.GetAlbumsByArtistIdAsync(id);
            return Ok(albums);
        }

        // GET: api/album/genre/{genreId}
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumByGenre(int id)
        {
            var albums = await _albumService.GetAlbumsByGenreIdAsync(id);
            return Ok(albums);
        }

        //POST: api/album
        [HttpPost]
        public async Task<ActionResult<Album>> AddAlbum([FromBody]Album album)
        {
            await _albumService.AddAlbumAsync(album);
            return CreatedAtAction(nameof(GetAlbumById), new { id = album.AlbumId }, album);
        }

        // PUT: api/album/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbum(int id, [FromBody] Album album)
        {
            if (id != album.AlbumId)
            {
                return BadRequest("Album ID does not match.");
            }

            await _albumService.UpdateAsync(album);
            return NoContent();
        }

        //DELETE: api/album/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            await _albumService.DeleteAsync(id);
            return NoContent();
        }
    }
}
