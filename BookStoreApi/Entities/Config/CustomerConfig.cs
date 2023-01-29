using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable("customers");

        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(200);
        entity.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(200);
        entity.Property(x => x.Email).HasColumnName("email").HasMaxLength(350);
        
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

        
        entity.HasMany(x => x.Orders)
            .WithOne()
            .HasForeignKey(x => x.CustomerId);
    }
}