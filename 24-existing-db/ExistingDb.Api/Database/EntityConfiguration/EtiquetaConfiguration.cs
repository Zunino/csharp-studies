using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExistingDb.Api.Database.EntityConfiguration;

public class EtiquetaConfiguration : IEntityTypeConfiguration<Etiqueta>
{
    public void Configure(EntityTypeBuilder<Etiqueta> builder)
    {
        builder.ToTable("Etiqueta");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");
        builder.Property(e => e.Rotulo)
            .HasColumnName("deetiqueta");

        // builder.HasMany(e => e.ObjetosLink);

        // builder.HasMany(e => e.Objetos)
        //     .WithMany(e => e.Etiquetas)
        //     .UsingEntity<ObjetoEtiqueta>(objetq =>
        //     {
        //         objetq.Property(e => e.CodigoObjeto)
        //             .HasColumnName("cdobjeto");
        //         objetq.Property(e => e.IdEtiqueta)
        //             .HasColumnName("idetiqueta");
        //     });
        // builder.HasMany(e => e.ObjetoEtiquetas)
        //     .WithOne(e => e.Etiqueta);
    }
}