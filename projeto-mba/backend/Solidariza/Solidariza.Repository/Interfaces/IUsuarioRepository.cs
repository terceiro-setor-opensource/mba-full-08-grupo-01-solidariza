using Solidariza.Domain.Models;

namespace Solidariza.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<Usuario> GetByEmail(string email);
        Task<List<Usuario>> GetUsuarios();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario user);
        Task DeleteAsync(Usuario user);
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetByCpfOuCnpjAsync(string cpfOuCnpj);
    }
}
