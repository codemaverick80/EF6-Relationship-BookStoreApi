using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class PublisherConfig : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> entity)
    {
        entity.ToTable("publishers");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.PublisherName).HasColumnName("publisher_name").HasMaxLength(400);
        
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        
        entity
            .HasMany(x => x.Books)
            .WithOne()
            .HasForeignKey(x => x.PublisherId);
        
    }
}