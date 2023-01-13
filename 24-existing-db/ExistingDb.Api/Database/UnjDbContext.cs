using ExistingDb.Api.Database.EntityConfiguration;
using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExistingDb.Api.Database;

public class UnjDbContext : DbContext
{
    public UnjDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ObjetoConfiguration());
        modelBuilder.ApplyConfiguration(new EtiquetaConfiguration());
        modelBuilder.ApplyConfiguration(new ObjetoEtiquetaConfiguration());
    }

    public DbSet<Objeto> Objetos { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
}