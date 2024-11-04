using System.Runtime.CompilerServices;
using AutoMapper;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.DTO.Usuario;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;
using Solidariza.Repository.Interfaces;
using BCrypt.Net;
using Solidariza.Domain.DTO;


namespace Solidariza.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IAbrigoRepository _abrigoRepository;
        private readonly IDoadorRepository _doadorRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IAbrigoRepository abrigoRepository, IDoadorRepository doadorRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _abrigoRepository = abrigoRepository;
            _doadorRepository = doadorRepository;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _usuarioRepository.GetByIdAsync(id);
            if (user == null) return null;
            
            return new UserDTO
            {
                Id = user.Id,
                Senha = user.Senha,
                Email = user.Email,
                TipoUsuario = user.TipoUsuario,
                CnpjCpf = user.CnpjCpf,
                CidadeEstado = user.Doador != null ? user.Doador.CidadeEstado : null,
                Nome = user.Doador != null ? user.Doador.Nome : null,
                Genero = user.Doador != null ? user.Doador.Genero : null,
                Endereco = user.Abrigo != null ? user.Abrigo.Endereco : null,
                RazaoSocial = user.Abrigo != null ? user.Abrigo.RazaoSocial : null,
            };
        }

        public async Task<List<UserDTO>> GetUsuarios()
        {
            return _mapper.Map<List<UserDTO>>(await _usuarioRepository.GetUsuarios());
        }

        public async Task CreateUserAsync(UserCreateDTO userCreateDto)
        {
            var existingUser = await _usuarioRepository.GetByEmailAsync(userCreateDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email já cadastrado.");
            }

            var newUser = new Usuario
            {
                CnpjCpf = userCreateDto.CnpjCpf,
                Email = userCreateDto.Email,
                Id = new Guid(),
                Senha = CreatePasswordHash(userCreateDto.Senha),
                TipoUsuario = userCreateDto.TipoUsuario
            };

            await _usuarioRepository.AddAsync(newUser);

            if (userCreateDto.TipoUsuario == Domain.Enums.TipoUsuario.Doador)
            {
                var doador = new Doador(
                    new Guid(),
                    newUser.Id,
                    userCreateDto.Genero.Value,
                    userCreateDto.Nome,
                    userCreateDto.CidadeEstado
                );

                await _doadorRepository.AddAsync(doador);
            }
            else
            {
                var abrigo = new Abrigo(
                    newUser.Id,
                    userCreateDto.Endereco,
                    userCreateDto.RazaoSocial,
                    userCreateDto.CidadeEstado
                );

                await _abrigoRepository.AddAsync(abrigo);
            }
        }

        public async Task UpdateUserAsync(UserUpdateDTO userUpdateDto)
        {
            //esse get tem que ter include???
            var user = await _usuarioRepository.GetByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                user.CnpjCpf = userUpdateDto.CnpjCpf;
                user.Email = userUpdateDto.Email;

                await _usuarioRepository.UpdateAsync(user);
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _usuarioRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _usuarioRepository.DeleteAsync(user);
            }
        }

        #region MétodosAuxiliares
        public string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        #endregion
    }
}
