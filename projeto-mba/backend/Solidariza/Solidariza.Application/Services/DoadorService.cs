using AutoMapper;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.DTO;
using Solidariza.Domain.DTO.Usuario;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;
using Solidariza.Domain.Models.Pagination;
using Solidariza.Repository.Interfaces;


namespace Solidariza.Application.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly IMapper _mapper;
        private readonly IDoadorRepository _doadorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DoadorService(IMapper mapper, IDoadorRepository doadorRepository, IUsuarioRepository userRepository)
        {
            _mapper = mapper;
            _doadorRepository = doadorRepository;
            _usuarioRepository = userRepository;
        }

        public async Task<DoadorDTO> GetByIdAsync(Guid id)
        {
            var doador = await _doadorRepository.GetByIdAsync(id);
            if (doador == null) return null;

            return new DoadorDTO
            {
                Id = doador.Id,
                UsuarioId = doador.UsuarioId,
                Nome = doador.Nome,
                Genero = doador.Genero,
                CidadeEstado = doador.CidadeEstado,
                DateCreated = doador.DateCreated,
                Usuario = new UserDTO()
                {
                    CnpjCpf = doador.Usuario.CnpjCpf,
                    Email = doador.Usuario.Email
                }
            };
        }

        public async Task<PagedResult<DoadorDTO>> GetDoadores(FilterKeywordDTO filter)
        {
            var keyword = _mapper.Map<FilterKeywordDTO, KeywordFilter>(filter);

            var doadores = await _doadorRepository.GetDoadores(keyword);

            var doadoresMapper = PreencherListaDoadores(doadores.Items);

            return new PagedResult<DoadorDTO>()
            {
                Items = doadoresMapper.ToList(),
                TotalItems = doadores.TotalItems,
                Page = doadores.Page,
                PageSize = doadores.PageSize
            };
        }

        private List<DoadorDTO> PreencherListaDoadores(IEnumerable<Domain.Models.Doador> doadores)
        {
            List<DoadorDTO> dadorMapper = new();
            foreach (var doador in doadores)
            {
                dadorMapper.Add(new DoadorDTO
                {
                    Id = doador.Id,
                    UsuarioId = doador.UsuarioId,
                    Nome = doador.Nome,
                    Genero = doador.Genero,
                    CidadeEstado = doador.CidadeEstado,
                    DateCreated = doador.DateCreated,
                    Usuario = new UserDTO()
                    {
                        CnpjCpf = doador.Usuario.CnpjCpf,
                        Email = doador.Usuario.Email
                    }
                });
            }

            return dadorMapper;
        }

        public async Task AddAsync(DoadorDTO doadorDTO)
        {
            var existingDoador = await _usuarioRepository.GetByCpfOuCnpjAsync(doadorDTO.Usuario.CnpjCpf);
            if (existingDoador != null)
            {
                throw new Exception("Doador já cadastrado.");
            }

            var newDoador = new Doador(new Guid(), doadorDTO.UsuarioId, doadorDTO.Genero, doadorDTO.Nome, doadorDTO.CidadeEstado);
            await _doadorRepository.AddAsync(newDoador);
        }

        public async Task UpdateAsync(DoadorDTO doadorDTO)
        {
            var doador = await _doadorRepository.GetByIdAsync(doadorDTO.Id);

            if (doador != null)
            {
                doador.Nome = doadorDTO.Nome;
                doador.CidadeEstado = doadorDTO.CidadeEstado;
                doador.Usuario.CnpjCpf = doadorDTO.Usuario.CnpjCpf;
                doador.Usuario.Email = doadorDTO.Usuario.Email;
                await _doadorRepository.UpdateAsync(doador);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var doador = await _doadorRepository.GetByIdAsync(id);
            if (doador != null)
            {
                await _doadorRepository.DeleteAsync(doador);
            }
        }
    }
}
