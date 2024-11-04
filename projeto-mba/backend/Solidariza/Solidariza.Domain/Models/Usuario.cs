using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Domain;
using Solidariza.Domain.Enums;

namespace Solidariza.Domain.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : Entity, IAggregateRoot
    {
        public string CnpjCpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Doador? Doador { get; set; }
        public Abrigo? Abrigo { get; set; }
    }
}
