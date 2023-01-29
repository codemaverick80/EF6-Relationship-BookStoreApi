namespace BookStoreApi.Entities;

public class AddressStatus
{
    public AddressStatus()
    {
        CustomerAddresses = new HashSet<CustomerAddress>();
    }
    public int Id { get; set; }
    public string Status { get; set; }

    public bool  IsDeleted { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    
    
    
}