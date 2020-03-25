using FluentMigrator;

namespace _16_ef_core_3
{
    [Migration(202003242154)]
    public class AddTranscriptionTable : Migration
    {
        public override void Up()
        {
            Create.Table("transcriptions")
                .WithColumn("video_id").AsInt64().PrimaryKey()
                .WithColumn("text").AsString();

            Create.ForeignKey("fk_video_transcription")
                .FromTable("transcriptions")
                .ForeignColumn("video_id")
                .ToTable("videos")
                .PrimaryColumn("id");
        }
        public override void Down()
        {
            Delete.Table("transcriptions");
        }
    }
}