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
    public class VinylController : ControllerBase
    {
        private readonly IVinylService _vinylService;
        private readonly IMapper _mapper;

        public VinylController(IVinylService vinylService, IMapper mapper)
        {
            _vinylService = vinylService;
            _mapper = mapper;
        }

        // GET: api/Vinyl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VinylModel>>> GetAllVinyls()
        {
            var vinyls = await _vinylService.GetAllVinylsAsync();
            return Ok(_mapper.Map<IEnumerable<VinylModel>>(vinyls));
        }

        // GET: api/Vinyl/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VinylModel>> GetVinylById(int id)
        {
            var vinyl = await _vinylService.GetVinylByIdAsync(id);
            if (vinyl == null)
                return NotFound();

            return Ok(_mapper.Map<VinylModel>(vinyl));
        }

        // POST: api/Vinyl
        [HttpPost]
        public async Task<ActionResult> AddVinyl([FromBody] VinylModel model)
        {
            var vinyl = _mapper.Map<Vinyl>(model);
            await _vinylService.AddVinylAsync(vinyl);
            return CreatedAtAction(nameof(GetVinylById), new { id = vinyl.ProductId }, model);
        }

        // PUT: api/Vinly/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVinyl(int id, [FromBody] VinylModel model)
        {
            if (id != model.ProductId)
                return BadRequest("Product Id does not match.");

            var existing = await _vinylService.GetVinylByIdAsync(id);
            if (existing == null)
                return NotFound();

            var updatedVinyl = _mapper.Map<Vinyl>(model);
            await _vinylService.UpdateVinylAsync(updatedVinyl);

            return NoContent();
        }

        // DELETE: api/Vinyl/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVinyl(int id)
        {
            var vinyl = await _vinylService.GetVinylByIdAsync(id);
            if (vinyl == null)
                return NotFound();

            await _vinylService.DeleteVinylAsync(id);
            return NoContent();
        }
    }
}
