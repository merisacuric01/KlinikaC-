using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Contracts.Service;
using klinika.Data.Dto.Pacijent;
using Microsoft.AspNetCore.Mvc;

namespace klinika.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacijentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PacijentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPacijente()
        {
            var response = await _serviceManager.PacijentService.GetAllPacijente();
            return Ok(response);
        }

        [HttpGet("{pacijentId}")]
        public async Task<IActionResult> GetPacijentById(int pacijentId)
        {
            var response = await _serviceManager.PacijentService.GetPacijentById(pacijentId);
            if(response is not null)
                return Ok(response);
            return NotFound("Pacijent nije pronadjen.");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePacijent(PacijentCreateDto pacijentCreateDto)
        {
            var response = await _serviceManager.PacijentService.CreatePacijent(pacijentCreateDto);

            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{pacijentId}")]
        public async Task<IActionResult> UpdatePacijent(PacijentUpdateDto pacijentUpdateDto, int pacijentId)
        {
            if(!pacijentId.Equals(pacijentUpdateDto.PacijentID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.PacijentService.UpdatePacijent(pacijentId,pacijentUpdateDto);
            if(response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{pacijentId}")]
        public async Task<IActionResult> DeletePacijent(int pacijentId)
        {
            var response = await _serviceManager.PacijentService.DeletePacijent(pacijentId);
            if(response) return Ok("Pacijent izbrisan");

            return BadRequest("Nuespelo brisanje pacijenta");
        }
    }
}