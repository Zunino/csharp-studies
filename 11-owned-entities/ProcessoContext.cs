using _11_owned_entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace _11_owned_entities
{

    public class ProcessoContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, __) => true, true)});
        
        public DbSet<Processo> Processos { get; set; }
        public DbSet<DataReferencia> Datas { get; set; }
        public DbSet<Parte> Partes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=processos.db")
                ;//.UseLoggerFactory(MyLoggerFactory);
        }
    }
    
}