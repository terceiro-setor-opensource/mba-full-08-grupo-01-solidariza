using Microsoft.EntityFrameworkCore;
using Solidariza.Domain.Models;
using Solidariza.Repository.Context;
using Solidariza.Repository.Interfaces;
using Solidariza.Repository.Extensions;
using Solidariza.Domain.Models.Pagination;
using LinqKit;

namespace Solidariza.Repository.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly SolidarizadbContext _context;
        private readonly DbSet<Doador> DbSet;

        public DoadorRepository(SolidarizadbContext context)
        {
            _context = context;
            DbSet = _context.Set<Doador>();
        }

        public async Task AddAsync(Doador doador)
        {
            await _context.Doadores.AddAsync(doador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doador doador)
        {
            _context.Doadores.Update(doador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doador doador)
        {
            _context.Doadores.Remove(doador);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Doador>> GetDoadores(KeywordFilter filter)
        {
            var doadoresResult = new PagedResult<Doador>();

            var predicate = PredicateBuilder.New<Doador>(true);
            predicate = GetPredicateFiltros(filter, predicate);

            var doadores = await DbSet
                .AsNoTracking()
                .Where(predicate)
                .ApplyPaging(filter.Page, filter.PageSize)
                .ToListAsync();

            doadoresResult.Items = doadores;
            doadoresResult.Page = filter.Page;
            doadoresResult.PageSize = filter.PageSize;
            doadoresResult.TotalItems = doadores.Count();

            return doadoresResult;
        }

        private ExpressionStarter<Doador> GetPredicateFiltros(KeywordFilter filter, ExpressionStarter<Doador> predicate)
        {
            if (filter.Nome is not null)
                predicate = predicate.And(p => p.Nome.Contains(filter.Nome));

            if (filter.DataInicio is not null)
                predicate = predicate.And(p => p.DateCreated.Date >= filter.DataInicio);

            if (filter.CpfOuCNPJ is not null)
                predicate = predicate.And(p => p.Usuario.CnpjCpf == filter.CpfOuCNPJ);

            return predicate;
        }

        public async Task<Doador> GetByIdAsync(Guid id)
        {
            return await DbSet
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}