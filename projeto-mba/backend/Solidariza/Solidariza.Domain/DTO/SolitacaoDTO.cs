using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidariza.Domain.Enums;
using Solidariza.Domain.Models;

namespace Solidariza.Domain.DTO
{
    public class SolitacaoDTO
    {
        public Guid Id { get; set; }
        public string DescricaoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public TipoPrioridadeProduto PrioridadeProduto { get; set; }
        public DateTime DateCreated { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string CidadeEstado { get; set; }
        public string CnpjCpf { get; set; }

    }
}
