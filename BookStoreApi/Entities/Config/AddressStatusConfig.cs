using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class AddressStatusConfig : IEntityTypeConfiguration<AddressStatus>
{
    public void Configure(EntityTypeBuilder<AddressStatus> entity)
    {
        entity.ToTable("address_status");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        entity.Property(x => x.Status).HasColumnName("status").HasMaxLength(30);

        entity.HasMany(x => x.CustomerAddresses)
            .WithOne()
            .HasForeignKey(x => x.StatusId);
    }
}