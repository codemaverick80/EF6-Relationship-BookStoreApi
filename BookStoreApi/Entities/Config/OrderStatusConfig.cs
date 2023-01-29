using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class OrderStatusConfig: IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> entity)
    {
        entity.ToTable("orderstatus");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        entity.Property(x => x.Status).HasColumnName("status");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

    }
}