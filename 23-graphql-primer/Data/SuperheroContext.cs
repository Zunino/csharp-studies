using GraphQLPrimer.Data.ContextConfiguration;
using GraphQLPrimer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPrimer.Data;

public class SuperheroContext : DbContext
{
    public SuperheroContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Generate three GUIDS and place them in an arrays
        var ids = new Guid[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

        // Apply configuration for the three contexts in our application
        // This will create the demo data for our GraphQL endpoint.
        builder.ApplyConfiguration(new SuperheroContextConfig(ids));
        builder.ApplyConfiguration(new SuperPowerContextConfig(ids));
        builder.ApplyConfiguration(new MovieContextConfig(ids));
    }
    
    public DbSet<Superhero> Superheroes { get; set; }
    public DbSet<SuperPower> SuperPowers { get; set; }
    public DbSet<Movie> Movies { get; set; }
}