using Core.Entities;
using Core.ValueObjects.UserVO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("UserId")
            .HasColumnType("INTEGER")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Email)
            .HasConversion(value => value.UserEmail,
                value => new Email(value))
            .HasColumnName("UserEmail")
            .HasColumnType("TEXT")
            .HasMaxLength(150)
            .IsRequired();


        builder.HasMany(x => x.TransactionsList)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}