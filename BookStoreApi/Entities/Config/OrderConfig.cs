using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("orders");

        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        entity.Property(x => x.CustomerId).HasColumnName("customer_id");
        entity.Property(x => x.OrderDate).HasColumnName("order_date");
        entity.Property(x => x.AddressId).HasColumnName("address_id");
        entity.Property(x => x.ShippingMethodId).HasColumnName("shipping_method_id");
        
        entity.Property(x => x.OrderDate).HasColumnName("order_date");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

      

    }
}