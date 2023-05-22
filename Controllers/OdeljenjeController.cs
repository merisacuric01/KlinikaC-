using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Service;
using Microsoft.AspNetCore.Mvc;
using klinika.Data.Dto.Odeljenje;

namespace klinika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OdeljenjeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OdeljenjeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetOdeljenja()
        {
            var response = await _serviceManager.OdeljenjeService.GetAllOdeljenja();
            return Ok(response);
        }

        [HttpGet("{odeljenjeId}")]
        public async Task<IActionResult> GetOdeljenjeById(int odeljenjeId)
        {
            var response = await _serviceManager.OdeljenjeService.GetOdeljenjeById(odeljenjeId);
            if(response is not null)
                return Ok(response);
            return NotFound("Odeljenje nije pronadjeno");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOdeljenje(OdeljenjeCreateDto odeljenjeCreateDto)
        {
            var response = await _serviceManager.OdeljenjeService.CreateOdeljenje(odeljenjeCreateDto);

            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{odeljenjeId}")]
        public async Task<IActionResult> UpdateOdeljenje(OdeljenjeUpdateDto odeljenjeUpdateDto, int odeljenjeId)
        {
            if(!odeljenjeId.Equals(odeljenjeUpdateDto.OdeljenjeID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.OdeljenjeService.UpdateOdeljenje(odeljenjeId,odeljenjeUpdateDto);
            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{odeljenjeId}")]
        public async Task<IActionResult> DeleteOdeljenje(int odeljenjeId)
        {
            var response = await _serviceManager.OdeljenjeService.DeleteOdeljenje(odeljenjeId);
            if(response) return Ok("Odeljenje izbrisano");

            return BadRequest("Neuspelo brisanje odeljenja.");
        }
    }
}