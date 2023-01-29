using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class ShippingMethodConfig : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> entity)
    {
        entity.ToTable("shipping_method");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        entity.Property(x => x.MethodName).HasColumnName("method_name");
        entity.Property(x => x.Cost).HasColumnName("cost");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

        entity.HasMany(x => x.Orders)
            .WithOne()
            .HasForeignKey(x => x.ShippingMethodId);

    }
}