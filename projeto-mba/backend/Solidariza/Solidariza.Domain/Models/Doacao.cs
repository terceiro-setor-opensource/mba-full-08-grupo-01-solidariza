using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDevPack.Domain;

namespace Solidariza.Domain.Models
{
    public class Doacao : Entity, IAggregateRoot
    {
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
        public Abrigo Abrigo { get; set; }
        public Guid AbrigoId { get; set; }
        public Solicitacao Solicitacao { get; set; }
        public Guid SolicitacaoId { get; set; }
        public Doador Doador { get; set; }
        public Guid DoadorId { get; set; }
    }
}
