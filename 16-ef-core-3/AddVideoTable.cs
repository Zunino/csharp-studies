using FluentMigrator;

namespace _16_ef_core_3
{
    [Migration(202003251010)]
    public class AddVideoTable : Migration
    {
        public override void Up()
        {
            Create.Table("videos")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("description").AsString();
        }
        public override void Down()
        {
            Delete.Table("videos");
        }
    }
}