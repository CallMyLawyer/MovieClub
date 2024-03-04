using FluentMigrator;

namespace MovieClub.Migrations.Migrations;

public class _202404031719_AddMoviesTable : Migration
{
    public override void Up()
    {
        Create.Table("Movies")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CategoryId").AsInt32().ForeignKey("Fk_Movies_Categories" , "Categories" , "Id")
            .
    }

    public override void Down()
    {
        
    }
}