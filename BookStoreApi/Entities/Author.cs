namespace BookStoreApi.Entities;

public class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public bool IsDeleted { get; set; }
    public ICollection<BookAuthor> Books { get; set; }
}