using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {

        entity.ToTable("address");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        entity.Property(x => x.StreetNumber).HasColumnName("street_number").HasMaxLength(10);
        entity.Property(x => x.StreetName).HasColumnName("street_name").HasMaxLength(200);
        entity.Property(x => x.City).HasColumnName("city").HasMaxLength(100);
        entity.Property(x => x.CountryId).HasColumnName("country_id");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

        entity.HasMany(x => x.Orders)
            .WithOne()
            .HasForeignKey(x => x.AddressId);

    }
}