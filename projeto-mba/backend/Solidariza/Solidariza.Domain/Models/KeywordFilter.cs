using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidariza.Domain.Models
{
    public class KeywordFilter
    {
        public KeywordFilter(string nome, string produto, int quantidade, string status, string prioridade, DateTime? dataInicio, DateTime? dataFim, int page, int pageSize, string sort)
        {
            Nome = nome;
            Produto = produto;
            Quantidade = quantidade;
            Status = status;
            Prioridade = prioridade;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Page = page <= 0 ? 1 : page;
            PageSize = pageSize <= 0 ? 10 : pageSize;
            Sort = sort;
        }

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
        public string CpfOuCNPJ { get; set; }
    }
}
