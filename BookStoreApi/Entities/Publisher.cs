namespace BookStoreApi.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string PublisherName { get; set; }

    public bool IsDeleted { get; set; }
    //Navigation Property
    public ICollection<Book> Books { get; set; } // One-to-Many Publisher:1 => M:Book
}