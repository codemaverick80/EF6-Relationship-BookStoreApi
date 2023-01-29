namespace BookStoreApi.Entities;

/// <summary>
/// Many-to-Many Link table between Book and Author
/// </summary>
public class BookAuthor
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public bool IsDeleted { get; set; }
}