using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using Solidariza.Domain.Models;

namespace Solidariza.Repository.Context;

public partial class SolidarizadbContext : DbContext
{
    public SolidarizadbContext() { }
    public SolidarizadbContext(DbContextOptions<SolidarizadbContext> options)
       : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Abrigo> Abrigos { get; set; }
    public DbSet<Doador> Doadores { get; set; }
    public DbSet<Solicitacao> Solicitacoes { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<Event>();
    }
}