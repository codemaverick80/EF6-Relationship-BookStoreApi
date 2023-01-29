using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class OrderHistoryConfig: IEntityTypeConfiguration<OrderHistory>
{
    public void Configure(EntityTypeBuilder<OrderHistory> entity)
    {
        entity.ToTable("order_history");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        entity.Property(x => x.OrderId).HasColumnName("order_id");
        entity.Property(x => x.OrderStatusId).HasColumnName("order_status_id");
        
        entity.Property(x => x.StatusDate).HasColumnName("status_date");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        
        entity.HasKey(x => new { x.OrderId, x.OrderStatusId });
        entity.HasOne(x => x.Order)
            .WithMany(x => x.OrderStatuses)
            .HasForeignKey(x => x.OrderId);
        
        entity.HasOne(x => x.OrderStatus)
            .WithMany(x => x.CustomerOrders)
            .HasForeignKey(x => x.OrderStatusId);
        
        
    }
}