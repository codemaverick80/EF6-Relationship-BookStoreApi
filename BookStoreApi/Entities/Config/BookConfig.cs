using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> entity)
    {
        entity.ToTable("books");
        
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.Title).HasColumnName("title").HasMaxLength(400);
        entity.Property(x => x.Isbn).HasColumnName("isbn").HasMaxLength(13);
        entity.Property(x => x.NumberOfPages).HasColumnName("num_pages");
        entity.Property(x => x.PublicationDate).HasColumnName("publication_date");

        entity.Property(x => x.LanguageId).HasColumnName("language_id");
        entity.Property(x => x.PublisherId).HasColumnName("publisher_id");
        
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);


    }
}