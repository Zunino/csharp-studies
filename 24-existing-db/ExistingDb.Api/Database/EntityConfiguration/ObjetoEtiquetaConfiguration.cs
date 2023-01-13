using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExistingDb.Api.Database.EntityConfiguration;

public class ObjetoEtiquetaConfiguration : IEntityTypeConfiguration<ObjetoEtiqueta>
{
    public void Configure(EntityTypeBuilder<ObjetoEtiqueta> builder)
    {
        builder.ToTable("ObjetoEtiqueta");
        builder.HasKey(e => new { e.CodigoObjeto, e.IdEtiqueta });

        builder.Property(e => e.CodigoObjeto)
            .HasColumnName("cdobjeto");
        
        builder.Property(e => e.IdEtiqueta)
            .HasColumnName("idetiqueta");

        builder.HasOne(e => e.Objeto)
            .WithMany(e => e.Etiquetas)
            .HasForeignKey(e => e.CodigoObjeto);

        builder.HasOne(e => e.Etiqueta)
            .WithMany()
            .HasForeignKey(e => e.IdEtiqueta);

        // builder.HasOne(e => e.Objeto)
        //     .WithMany(e => e.Etiquetas);
        // builder.HasOne(e => e.Etiqueta)
        //     .WithMany(e => e.Objetos);
    }
}