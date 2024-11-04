using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDevPack.Domain;
using Solidariza.Domain.Enums;

namespace Solidariza.Domain.Models
{
    public class Solicitacao : Entity, IAggregateRoot
    {
        public string DescricaoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public TipoPrioridadeProduto PrioridadeProduto { get; set; }
        public Abrigo Abrigo { get; set; }
        public Guid AbrigoId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
