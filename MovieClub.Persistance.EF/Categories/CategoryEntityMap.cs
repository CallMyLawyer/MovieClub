using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieClub.Entities.Categories;

namespace MovieClub.Persistance.EF.Categories;

public class CategoryEntityMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(_ => _.Rate).HasDefaultValue(0).IsRequired();
        builder.Property(_ => _.Title).HasMaxLength(50).IsRequired();
    }
}