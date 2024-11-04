using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidariza.Domain.DTO
{
    public class FilterKeywordDTO
    {
        public string? Nome { get; set; }
        public string? Produto { get; set; }
        public int Quantidade { get; set; }
        public string? Status { get; set; }
        public string? Prioridade { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Sort { get; set; }

    }
}
