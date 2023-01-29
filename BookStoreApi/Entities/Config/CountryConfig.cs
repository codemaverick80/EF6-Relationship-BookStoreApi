using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.ToTable("country");

        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

        entity.Property(x => x.CountryName).HasColumnName("country_name");
        
        entity.HasMany(x => x.Addresses)
            .WithOne()
            .HasForeignKey(x => x.CountryId);


    }
}