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
            .HasConversion(value => value!.Value,
            value => new TransactionId(value))
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasConversion(value => value.Value,
                value => new Description(value))
            .HasMaxLength(500)
            .HasColumnType("Nvarchar");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAT")
            .HasColumnType("datetime()")
            .HasConversion(value => value.Value,
                value => new CreatedAt(value));

        builder.Property(x => x.SystemDate)
            .HasColumnName("SystemDate")
            .HasColumnType("datetime()")
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
            .HasColumnName("CategoryId")
            .HasColumnType("INTEGER")
            .HasConversion(value => value.Value,
                value => new CategoryId(value));

        builder.HasOne(x => x.Category)
            .WithOne(x => x.Transaction)
            .HasForeignKey<Transactions>(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}