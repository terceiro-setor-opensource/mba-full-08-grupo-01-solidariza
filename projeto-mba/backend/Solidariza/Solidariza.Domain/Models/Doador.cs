using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDevPack.Domain;
using Solidariza.Domain.Enums;

namespace Solidariza.Domain.Models
{
    public class Doador : Entity, IAggregateRoot
    {
        public Doador(Guid doadorId, Guid userId, TipoGenero genero, string nome, string cidadeEstado)
        {
            DateCreated = DateTime.Now;
            Id = doadorId;
            UsuarioId = userId;
            Genero = genero;
            Nome = nome;
            CidadeEstado = cidadeEstado;
        }

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public TipoGenero Genero { get; set; }
        public string Nome { get; set; }
        public string CidadeEstado { get; set; }
    }
}
