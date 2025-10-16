using Core.Entities;
using Core.ValueObjects.CategoryVO;
using Core.ValueObjects.TransactionsVO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(value => value!.Value,
                value => new CategoryId(value))
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(value => value.Value,
                value => new Name(value))
            .HasColumnName("Name")
            .HasColumnType("nvarchar")
            .HasMaxLength(200);
        
    }
}