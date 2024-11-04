using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidariza.Application.Interfaces;
using Solidariza.Application.Services;
using Solidariza.Domain.DTO;
using Solidariza.Domain.Interfaces;

namespace Solidariza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto.Username, loginDto.Password);

            if (token == null)
            {
                return Unauthorized("Login ou senha inválidos");
            }

            return Ok(new { Token = token });
        }
    }
}