using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;

namespace MovieClub.Persistance.EF.Movies;

public class MovieEntityMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasOne<Category>()
            .WithMany(_=>_.Movies)
            .HasForeignKey(_=>_.CategoryId);
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.Description).HasMaxLength(300);
        builder.Property(_ => _.DailyRentPrice).IsRequired();
        builder.Property(_ => _.PublishedDate);
        builder.Property(_ => _.AgeLimit).IsRequired();
        builder.Property(_ => _.PenaltyPrice).IsRequired();
        builder.Property(_ => _.Duration);
        builder.Property(_ => _.Rate).HasDefaultValue(0);
        builder.Property(_ => _.Count).HasDefaultValue(1);
        builder.Property(_ => _.Director).HasMaxLength(100);
        builder.Property(_ => _.CategoryId).IsRequired();

    }
}