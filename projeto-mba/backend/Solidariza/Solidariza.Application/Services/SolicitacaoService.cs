using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Solidariza.Domain.DTO;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;
using Solidariza.Domain.Models.Pagination;
using Solidariza.Repository.Interfaces;

namespace Solidariza.Application.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solitacaoRepository;
        private readonly IMapper _mapper;

        public SolicitacaoService(ISolicitacaoRepository solitacaoRepository, IMapper mapper)
        {
            _solitacaoRepository = solitacaoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SolitacaoDTO>> GetListFiltered(FilterKeywordDTO filter)
        {
            var keyword = _mapper.Map<FilterKeywordDTO, KeywordFilter>(filter);

            var solicitacoes = await _solitacaoRepository.GetListFiltered(keyword);

            var solicitacoesMapper = PreencherListaSolicitacoes(solicitacoes.Items);

            return new PagedResult<SolitacaoDTO>()
            {
                Items = solicitacoesMapper.ToList(),
                TotalItems = solicitacoes.TotalItems,
                Page = solicitacoes.Page,
                PageSize = solicitacoes.PageSize
            };
        }

        #region Métodos Auxiliares
        private List<SolitacaoDTO> PreencherListaSolicitacoes(IEnumerable<Domain.Models.Solicitacao> solicitacoes)
        {
            List<SolitacaoDTO> solitacaoMapper = new();
            foreach (var solitacao in solicitacoes)
            {
                solitacaoMapper.Add(new SolitacaoDTO
                {
                    Id = solitacao.Id,
                    RazaoSocial = solitacao.Abrigo.RazaoSocial,
                    CnpjCpf = solitacao.Abrigo.Usuario.CnpjCpf,
                    Endereco = solitacao.Abrigo.Endereco,
                    CidadeEstado = solitacao.Abrigo.CidadeEstado,
                    DescricaoProduto = solitacao.DescricaoProduto,
                    PrioridadeProduto = solitacao.PrioridadeProduto,
                    QuantidadeProduto = solitacao.QuantidadeProduto,
                    DateCreated = solitacao.DateCreated
                });
            }

            return solitacaoMapper;
        }
        #endregion
    }
}
