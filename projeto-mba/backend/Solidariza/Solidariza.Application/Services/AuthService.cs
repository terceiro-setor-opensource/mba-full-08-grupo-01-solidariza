using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;

namespace Solidariza.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // Buscar usuário no banco de dados
            var usuario = await _usuarioRepository.GetByEmail(username);

            if (usuario == null || !VerifyPasswordHash(password, usuario.Senha))
            {
                return null; // Retornar null se a autenticação falhar
            }

            // Se a autenticação for bem-sucedida, gerar token JWT
            return GenerateJwtToken(usuario);
        }

        public bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        private string GenerateJwtToken(Usuario user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            // Implementar hash da senha (exemplo simples, use uma abordagem mais segura em produção)
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }

}
