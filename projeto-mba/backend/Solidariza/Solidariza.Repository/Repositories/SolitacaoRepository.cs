using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;
using Solidariza.Repository.Context;
using Solidariza.Repository.Interfaces;
using Solidariza.Repository.Extensions;
using Solidariza.Domain.Models.Pagination;
using LinqKit;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solidariza.Domain.Enums;

namespace Solidariza.Repository.Repositories
{
    public class SolitacaoRepository : ISolicitacaoRepository
    {
        private readonly SolidarizadbContext _context;
        private readonly DbSet<Solicitacao> DbSet;

        public SolitacaoRepository(SolidarizadbContext context)
        {
            _context = context;
            DbSet = _context.Set<Solicitacao>();
        }

        public async Task<PagedResult<Solicitacao>> GetListFiltered(KeywordFilter filter)
        {
            var solitacoesPaginadas = new PagedResult<Solicitacao>();

            var predicate = PredicateBuilder.New<Solicitacao>(true);
            predicate = GetPredicateFiltros(filter, predicate);

            var solitacoes = await DbSet
                .Include(x => x.Abrigo).ThenInclude(x => x.Usuario).ThenInclude(x => x.Doador)
                .AsNoTracking()
                .Where(predicate)
                .ApplyPaging(filter.Page, filter.PageSize)
                .ToListAsync();

            solitacoesPaginadas.Items = solitacoes;
            solitacoesPaginadas.Page = filter.Page;
            solitacoesPaginadas.PageSize = filter.PageSize;
            solitacoesPaginadas.TotalItems = solitacoes.Count();

            return solitacoesPaginadas;
        }

        #region Métodos Auxiliares
        private ExpressionStarter<Solicitacao> GetPredicateFiltros(KeywordFilter filter, ExpressionStarter<Solicitacao> predicate)
        {
            if (filter.DataInicio is not null)
                predicate = predicate.And(p => p.DateCreated.Date >= filter.DataInicio);

            if (filter.DataFim is not null)
                predicate = predicate.And(p => p.DateCreated.Date <= filter.DataFim);

            if (!string.IsNullOrEmpty(filter.Produto))
                predicate = predicate.Or(p => p.DescricaoProduto.Contains(filter.Produto));

            if (!string.IsNullOrEmpty(filter.Nome))
                predicate = predicate.Or(p => p.Abrigo.Usuario.Doador.Nome.Contains(filter.Nome));

            if (!string.IsNullOrEmpty(filter.Prioridade))
                predicate = predicate.Or(p => p.PrioridadeProduto.Equals(Enum.Parse<TipoPrioridadeProduto>(filter.Prioridade)));

            return predicate;
        }
        #endregion
    }
}
