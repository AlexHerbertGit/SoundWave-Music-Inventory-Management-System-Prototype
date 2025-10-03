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
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        // GET: api/album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumModel>>> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            return Ok(_mapper.Map<List<AlbumModel>>(albums));
        }

        // GET: api/album/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumModel>> GetAlbumById(int id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);
            if (album == null)
                return NotFound();
     
            return Ok(_mapper.Map<AlbumModel>(album));
        }

        // GET: api/album/artist/{artistId}
        [HttpGet("artist/{artistId}")]
        public async Task<ActionResult<IEnumerable<AlbumModel>>> GetAlbumsByArtist(int artistId)
        {
            var albums = await _albumService.GetAlbumsByArtistIdAsync(artistId);
            return Ok(_mapper.Map<List<AlbumModel>>(albums));
        }

        // GET: api/album/genre/{genreId}
        [HttpGet("genre/{genreId}")]
        public async Task<ActionResult<IEnumerable<AlbumModel>>> GetAlbumByGenre(int genreId)
        {
            var albums = await _albumService.GetAlbumsByGenreIdAsync(genreId);
            return Ok(_mapper.Map<List<AlbumModel>>(albums));
        }

        // POST: api/Album
        [HttpPost]
        public async Task<ActionResult<AlbumModel>> AddAlbum([FromBody] AlbumModel albumModel)
        {
            var album = _mapper.Map<Album>(albumModel);
            await _albumService.AddAlbumAsync(album);

            var createdModel = _mapper.Map<AlbumModel>(album);
            return CreatedAtAction(nameof(GetAlbumById), new { id = createdModel.AlbumId }, createdModel);
        }

        // PUT: api/album/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] AlbumModel albumModel)
        {
            if (id != albumModel.AlbumId)
                return BadRequest("Album ID does not match.");

            var albumEntity = _mapper.Map<Album>(albumModel);
            await _albumService.UpdateAsync(albumEntity);

            return NoContent();
        }

        //DELETE: api/album/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            await _albumService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
