using Solidariza.Domain.DTO.Usuario;
using Solidariza.Domain.Enums;

namespace Solidariza.Domain.DTO
{
    public class DoadorDTO
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid UsuarioId { get; set; }
        public UserDTO Usuario { get; set; }
        public TipoGenero Genero { get; set; }
        public string Nome { get; set; }
        public string CidadeEstado { get; set; }
    }
}
