using FluentMigrator;
using MovieClub.Entities.Movies;

namespace MovieClub.Migrations.Migrations;
[Migration(2024040331537)]
public class _202404031537_AddCategoriesTable : Migration
{
    public override void Up()
    {
        Create.Table("Categories")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Rate").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Categories");
    }
}