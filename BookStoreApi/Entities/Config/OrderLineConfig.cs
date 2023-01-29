using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> entity)
    {
        entity.ToTable("order_line");
        
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        
        entity.Property(x => x.Price).HasColumnName("price");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        
        entity.Property(x => x.BookId).HasColumnName("book_id");
        entity.Property(x => x.OrderId).HasColumnName("order_id");
        
        entity.HasKey(x => new { x.BookId, x.OrderId });

        entity.HasOne(x => x.Book)
            .WithMany(x => x.OrderLines)
            .HasForeignKey(x => x.BookId);
        // .OnDelete(DeleteBehavior.Cascade)
        // .IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation

        entity.HasOne(x => x.Order)
            .WithMany(x => x.OrderLines)
            .HasForeignKey(x => x.OrderId);
        //.OnDelete(DeleteBehavior.Cascade)
        //.IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation

    }
}