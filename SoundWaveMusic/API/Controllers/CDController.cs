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
    public class CDController : ControllerBase
    {
        private readonly ICDService _cdService;
        private readonly IMapper _mapper;

        public CDController(ICDService cdService, IMapper mapper)
        {
            _cdService = cdService;
            _mapper = mapper;
        }

        // GET: api/CD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CDModel>>> GetAllCDs()
        {
            var cds = await _cdService.GetAllCDsAsync();
            return Ok(_mapper.Map<IEnumerable<CDModel>>(cds));
        }

        // GET: api/CD/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CDModel>> GetCDById(int id)
        {
            var cd = await _cdService.GetCDByIdAsync(id);
            if (cd == null)
                return NotFound();

            return Ok(_mapper.Map<CDModel>(cd));
        }

        // POST: api/CD
        [HttpPost]
        public async Task<ActionResult<CDModel>> AddCD([FromBody] CDModel model)
        {
            var cd = _mapper.Map<CD>(model);
            await _cdService.AddCDAsync(cd);
            return CreatedAtAction(nameof(GetCDById), new { id = cd.ProductId }, model);
        }

        // PUT: api/CD/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCD(int id, [FromBody] CDModel model)
        {
            if (id != model.ProductId)
                return BadRequest("Product ID does not match");

            var existing = await _cdService.GetCDByIdAsync(id);
            if (existing == null)
                return NotFound();

            var updatedCD = _mapper.Map<CD>(model);
            await _cdService.UpdateCDAsync(updatedCD);

            return NoContent();
        }

        // DELETE: api/CD/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCD(int id)
        {
            var cd = await _cdService.GetCDByIdAsync(id);
            if (cd == null)
                    return NotFound();

            await _cdService.DeleteCDAsync(id);
            return NoContent();
        }

    }
}
