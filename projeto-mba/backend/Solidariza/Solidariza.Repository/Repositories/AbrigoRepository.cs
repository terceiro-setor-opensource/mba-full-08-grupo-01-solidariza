using Microsoft.EntityFrameworkCore;
using Solidariza.Domain.Models;
using Solidariza.Repository.Context;
using Solidariza.Repository.Interfaces;

namespace Solidariza.Repository.Repositories
{
    public class AbrigoRepository : IAbrigoRepository
    {
        private readonly SolidarizadbContext _context;
        private readonly DbSet<Abrigo> DbSet;

        public AbrigoRepository(SolidarizadbContext context)
        {
            _context = context;
            DbSet = _context.Set<Abrigo>();
        }

        public async Task AddAsync(Abrigo abrigo)
        {
            await _context.Abrigos.AddAsync(abrigo);
            await _context.SaveChangesAsync();
        }
    }
}
