namespace BookStoreApi.Entities;

public class Language
{
    public int Id { get; set; }
    public string LanguageCode { get; set; }
    public string LanguageName { get; set; }

    public bool IsDeleted { get; set; }
    //Navigation Property
    public ICollection<Book> Books { get; set; } // One-to-Many BookLanguage:1 => M:Book
}