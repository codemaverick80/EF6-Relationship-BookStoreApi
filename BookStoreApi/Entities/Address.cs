namespace BookStoreApi.Entities;

public class Address
{
    public int Id { get; set; }
    public string StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    
    public bool IsDeleted { get; set; }
    
    
    public int CountryId { get; set; } //Foreign Key

    public ICollection<CustomerAddress> Customers { get; set; }
    
    public ICollection<Order> Orders { get; set; }

}