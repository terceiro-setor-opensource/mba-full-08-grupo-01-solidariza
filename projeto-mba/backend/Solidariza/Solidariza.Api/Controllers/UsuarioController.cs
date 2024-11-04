using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.DTO.Usuario;

namespace Solidariza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _usuarioService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("listAll")]
        public async Task<List<UserDTO>> GetUsuarios()
        {
            return await _usuarioService.GetUsuarios();
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            await _usuarioService.CreateUserAsync(userCreateDTO);
            return CreatedAtAction(nameof(CreateUser),null, null);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDTO userUpdateDTO)
        {
            await _usuarioService.UpdateUserAsync(userUpdateDTO);
            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("remove/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usuarioService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
