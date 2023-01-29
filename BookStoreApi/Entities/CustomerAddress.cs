namespace BookStoreApi.Entities;

/// <summary>
/// Many-to-Many Link table between Customer and Address
/// </summary>
public class CustomerAddress
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int AddressId { get; set; }
    public Address Address { get; set; }


    public bool IsDeleted { get; set; }

    public int StatusId { get; set; } //Foreign Key (One-to-Many AddressStatus:1 => CustomerAddress:M
    
}