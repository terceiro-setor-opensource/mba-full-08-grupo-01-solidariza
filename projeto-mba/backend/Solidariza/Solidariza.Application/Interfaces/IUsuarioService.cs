using Solidariza.Domain.DTO.Usuario;

namespace Solidariza.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<List<UserDTO>> GetUsuarios();
        Task CreateUserAsync(UserCreateDTO userCreateDto);
        Task UpdateUserAsync(UserUpdateDTO userUpdateDto);
        Task DeleteUserAsync(Guid id);
    }
}
