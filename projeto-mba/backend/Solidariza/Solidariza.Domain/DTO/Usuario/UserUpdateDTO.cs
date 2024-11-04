using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidariza.Domain.Enums;

namespace Solidariza.Domain.DTO.Usuario
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string? CnpjCpf { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        // Propriedades para Doador
        public TipoGenero? Genero { get; set; }
        public string? Nome { get; set; }
        public string? CidadeEstado { get; set; }

        // Propriedades para Abrigo
        public string? Endereco { get; set; }
        public string? RazaoSocial { get; set; }
    }
}
