using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidariza.Domain.DTO;
using Solidariza.Domain.Models.Pagination;

namespace Solidariza.Domain.Interfaces
{
    public interface ISolicitacaoService
    {
        Task<PagedResult<SolitacaoDTO>> GetListFiltered(FilterKeywordDTO filter);
    }
}
