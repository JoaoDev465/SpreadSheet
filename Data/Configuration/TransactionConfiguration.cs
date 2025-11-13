using Core.Entities;
using Core.ValueObjects.TransactionsVO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasConversion(value => value.Value,
                value => new Description(value))
            .HasMaxLength(500)
            .HasColumnType("Nvarchar");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAT")
            .HasColumnType("DATETIME")
            .HasConversion(value => value.Value,
                value => new CreatedAt(value));

        builder.Property(x => x.SystemDate)
            .HasColumnName("SystemDate")
            .HasColumnType("DATETIME")
            .HasConversion(value => value.Value,
                value => new SystemDate(value));

        builder.Property(x => x.TransactionValue)
            .HasColumnName("TransactionValue")
            .HasColumnType("decimal")
            .HasConversion(value => value.Value,
                value => new TransactionValue(value));

        builder.Property(x => x.TransactionType)
            .HasColumnName("transactionType")
            .HasConversion(value => (int)value,
                value => (TransactionType)value);

        builder.Property(x => x.CategoryId)
            .HasConversion(value => value.Value,
                value => new CategoryId(value))
            .HasColumnName("CategoryId")
            .HasColumnType("int");

    builder.HasOne(x => x.Category)
            .WithMany(x=>x.Transaction)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}