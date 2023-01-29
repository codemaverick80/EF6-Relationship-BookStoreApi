namespace BookStoreApi.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<CustomerAddress> Addresses { get; set; }
    public ICollection<Order> Orders { get; set; }
}