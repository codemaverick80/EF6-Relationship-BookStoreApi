namespace BookStoreApi.Entities;

public class OrderLine
{
    public int Id { get; set; }
    public double Price { get; set; }

    public Order Order { get; set; }
    public int OrderId { get; set; }

    public Book Book { get; set; }
    public int BookId { get; set; }
    
    public bool  IsDeleted { get; set; }
    
}