using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Service;
using Microsoft.AspNetCore.Mvc;
using klinika.Data.Dto.Doktor;

namespace klinika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoktorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DoktorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoktori()
        {
            var response = await _serviceManager.DoktorService.GetAllDoktore();
            return Ok(response);
        }

        [HttpGet("{doktorId}")]
        public async Task<IActionResult> GetDoktorById(int doktorId)
        {
            var response = await _serviceManager.DoktorService.GetDoktorById(doktorId);
            if(response is not null)
                return Ok(response);
            return NotFound("Doktor nije pronadjen");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoktor(DoktorCreateDto doktorCreateDto)
        {
            var response = await _serviceManager.DoktorService.CreateDoktor(doktorCreateDto);

            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{doktorId}")]
        public async Task<IActionResult> UpdateDoktor(DoktorUpdateDto doktorUpdateDto, int doktorId)
        {
            if(!doktorId.Equals(doktorUpdateDto.DoktorID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.DoktorService.UpdateDoktor(doktorId,doktorUpdateDto);
            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{doktorId}")]
        public async Task<IActionResult> DeleteDoktor(int doktorId)
        {
            var response = await _serviceManager.DoktorService.DeleteDoktor(doktorId);
            if(response) return Ok("Doktor izbrisan");

            return BadRequest("Neuspelo brisanje doktora.");
        }
    }
}