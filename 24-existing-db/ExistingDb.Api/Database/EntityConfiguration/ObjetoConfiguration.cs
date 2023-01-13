using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExistingDb.Api.Database.EntityConfiguration;

public class ObjetoConfiguration : IEntityTypeConfiguration<Objeto>
{
    public void Configure(EntityTypeBuilder<Objeto> builder)
    {
        builder.ToTable("Objeto");
        builder.HasKey(e => e.Codigo);
        
        builder.Property(e => e.Codigo)
            .HasColumnName("cdobjeto");
        builder.Property(e => e.Descricao)
            .HasColumnName("deobjeto");

        // builder.HasMany(e => e.Etiquetas)
        //     .WithMany()
        //     .UsingEntity<ObjetoEtiqueta>(b =>
        //     {
        //         b.ToTable("ObjetoEtiqueta").HasKey(e => new { e.CodigoObjeto, e.IdEtiqueta });
        //         b.HasOne(e => e.Objeto)
        //             .WithMany()
        //             .HasForeignKey(x => x.CodigoObjeto);
        //         b.HasOne(e => e.Etiqueta)
        //             .WithMany()
        //             .HasForeignKey(x => x.IdEtiqueta);
        //     });

        // builder.HasMany(e => e.ObjetoEtiquetas)
        //     .WithOne(e => e.Objeto);

        // builder.HasMany(e => e.Etiquetas);
    }
}