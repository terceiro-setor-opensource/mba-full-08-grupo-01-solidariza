using Microsoft.EntityFrameworkCore;
using Solidariza.Domain.DTO;
using Solidariza.Domain.Interfaces;
using Solidariza.Domain.Models;
using Solidariza.Repository.Context;

namespace Solidariza.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SolidarizadbContext _context;
        private readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(SolidarizadbContext context)
        {
            _context = context;
            DbSet = _context.Set<Usuario>();
        }
        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await DbSet
                .Include(x => x.Abrigo)
                .Include(x => x.Doador)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> GetByCpfOuCnpjAsync(string cpfOuCnpj)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.CnpjCpf == cpfOuCnpj);
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await DbSet
                .Include(x => x.Abrigo)
                .Include(x => x.Doador)
                .ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario user)
        {
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario user)
        {
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
