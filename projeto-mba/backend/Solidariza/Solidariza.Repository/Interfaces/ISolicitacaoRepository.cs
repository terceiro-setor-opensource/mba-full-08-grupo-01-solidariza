using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidariza.Domain.Models;
using Solidariza.Domain.Models.Pagination;

namespace Solidariza.Repository.Interfaces
{
    public interface ISolicitacaoRepository
    {
        Task<PagedResult<Solicitacao>> GetListFiltered(KeywordFilter filter);
    }
}
