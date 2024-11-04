using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDevPack.Domain;

namespace Solidariza.Domain.Models
{
    public class Abrigo : Entity, IAggregateRoot
    {
        public Abrigo(Guid usuarioId, string endereco, string razaoSocial, string cidadeEstado)
        {
            DateCreated = DateTime.Now;
            UsuarioId = usuarioId;
            Endereco = endereco;
            RazaoSocial = razaoSocial;
            CidadeEstado = cidadeEstado;
        }

        public DateTime DateCreated { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string CidadeEstado { get; set; }
    }
}
