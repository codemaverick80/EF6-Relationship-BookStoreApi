using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class AuthorConfig : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> entity)
    {
        entity.ToTable("authors");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.AuthorName).HasColumnName("author_name").HasMaxLength(400);

        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
    }
}