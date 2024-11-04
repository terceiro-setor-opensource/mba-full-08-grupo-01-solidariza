using Solidariza.Domain.Models;
using Solidariza.Domain.Models.Pagination;

namespace Solidariza.Repository.Interfaces
{
    public interface IDoadorRepository
    {
        Task AddAsync(Doador doador);
        Task<PagedResult<Doador>> GetDoadores(KeywordFilter filter);
        Task<Doador> GetByIdAsync(Guid id);
        Task UpdateAsync(Doador doador);
        Task DeleteAsync(Doador doador);
    }
}
