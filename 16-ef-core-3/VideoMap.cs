using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _16_ef_core_3
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(v => v.Id).HasColumnName("id").IsRequired();
            builder.Property(v => v.Description).HasColumnName("description").IsRequired();
            builder.ToTable("videos");

            builder.OwnsOne(v => v.Transcription, tbuilder => {
                tbuilder.WithOwner().HasForeignKey("VideoId");
                tbuilder.Property("VideoId").HasColumnName("video_id").IsRequired();
                tbuilder.Property("Text").HasColumnName("text").IsRequired();
                tbuilder.ToTable("transcriptions");
            });
        }
    }
}