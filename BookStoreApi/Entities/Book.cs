namespace BookStoreApi.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public int NumberOfPages { get; set; }
    public DateOnly PublicationDate { get; set; }

    public bool IsDeleted { get; set; }
    //Navigation Property
    public int LanguageId { get; set; } // Foreign Key
    public int PublisherId { get; set; } // Foreign Key

    public ICollection<BookAuthor> Authors { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; }
    
}