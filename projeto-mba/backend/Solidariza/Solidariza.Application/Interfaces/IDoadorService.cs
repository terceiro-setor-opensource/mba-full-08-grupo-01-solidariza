using Solidariza.Domain.DTO;
using Solidariza.Domain.Models.Pagination;

namespace Solidariza.Application.Interfaces
{
    public interface IDoadorService
    {
        Task AddAsync(DoadorDTO doador);
        Task<PagedResult<DoadorDTO>> GetDoadores(FilterKeywordDTO filter);
        Task<DoadorDTO> GetByIdAsync(Guid id);
        Task UpdateAsync(DoadorDTO doador);
        Task DeleteAsync(Guid id);
    }
}
