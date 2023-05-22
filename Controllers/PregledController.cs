using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Service;
using klinika.Data.Dto.Pregled;
using Microsoft.AspNetCore.Mvc;

namespace klinika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PregledController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PregledController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPreglede()
        {
            var response = await _serviceManager.PregledService.GetAllPreglede();
            return Ok(response);
        }

        [HttpGet("{pregledId}")]
        public async Task<IActionResult> GetPregledById(int pregledId)
        {
            var response = await _serviceManager.PregledService.GetPregledById(pregledId);
            if(response is not null)
                return Ok(response);
            return NotFound("Pregled nije pronadjen");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePregled(PregledCreateDto pregledCreateDto)
        {
            var response = await _serviceManager.PregledService.CreatePregled(pregledCreateDto);

            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{pregledId}")]
        public async Task<IActionResult> UpdatePregled(PregledUpdateDto pregledUpdateDto, int pregledId)
        {
            if(!pregledId.Equals(pregledUpdateDto.PregledID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.PregledService.UpdatePregled(pregledId,pregledUpdateDto);
            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{pregledId}")]
        public async Task<IActionResult> DeletePregled(int pregledId)
        {
            var response = await _serviceManager.PregledService.DeletePregled(pregledId);
            if(response) return Ok("Pregled izbrisan");

            return BadRequest("Neuspelo brisanje pregleda");
        }
    }
}