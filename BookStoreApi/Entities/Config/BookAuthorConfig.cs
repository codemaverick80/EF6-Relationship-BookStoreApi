using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Entities.Config;

public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> entity)
    {
        entity.ToTable("book_author");

        entity.Property(x => x.BookId).HasColumnName("book_id");
        entity.Property(x => x.AuthorId).HasColumnName("author_id");
        entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        
        entity.HasKey(x => new { x.AuthorId, x.BookId });

        entity.HasOne(x => x.Book)
            .WithMany(x => x.Authors)
            .HasForeignKey(x => x.BookId);
           // .OnDelete(DeleteBehavior.Cascade)
           // .IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation

        entity.HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
        //.OnDelete(DeleteBehavior.Cascade)
        //.IsRequired(false);
        ////https://learn.microsoft.com/en-us/ef/core/querying/filters#accessing-entity-with-query-filter-using-required-navigation
    }
}