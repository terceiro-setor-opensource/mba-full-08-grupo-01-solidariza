using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.DTO;

namespace Solidariza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {
        private readonly IDoadorService _doadorService;
        
        public DoadorController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _doadorService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("listAll")]
        public async Task<IActionResult> GetDoadores([FromQuery] FilterKeywordDTO filter)
        {
            var result = await _doadorService.GetDoadores(filter);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] DoadorDTO doadorDTO)
        {
            await _doadorService.AddAsync(doadorDTO);
            return CreatedAtAction(nameof(AddAsync),null, null);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] DoadorDTO doadorDTO)
        {
            await _doadorService.UpdateAsync(doadorDTO);
            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("remove/{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _doadorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
