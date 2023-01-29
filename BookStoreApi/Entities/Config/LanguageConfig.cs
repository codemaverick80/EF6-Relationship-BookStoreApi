using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class LanguageConfig : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> entity)
    {
        entity.ToTable("languages");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.LanguageCode).HasColumnName("language_code").HasMaxLength(8);
        entity.Property(x => x.LanguageName).HasColumnName("language_name").HasMaxLength(50);
        
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        
        entity
            .HasMany(x => x.Books)
            .WithOne()
            .HasForeignKey(x => x.LanguageId);
        
    }
}