using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class CustomerAddressConfig: IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> entity)
    {
        
        entity.ToTable("customer_address");

        entity.Property(x => x.CustomerId).HasColumnName("customer_id");
        entity.Property(x => x.AddressId).HasColumnName("address_id");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        entity.Property(x => x.StatusId).HasColumnName("status_id");
        
        entity.HasKey(x => new { x.CustomerId, x.AddressId });

        entity.HasOne(x => x.Customer)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.CustomerId);
        // .OnDelete(DeleteBehavior.Cascade)
        // .IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation

        entity.HasOne(x => x.Address)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.AddressId);
        //.OnDelete(DeleteBehavior.Cascade)
        //.IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation

    }
}