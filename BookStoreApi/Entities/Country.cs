namespace BookStoreApi.Entities;

public class Country
{
    public Country()
    {
        Addresses = new HashSet<Address>();
    }
    public int Id { get; set; }
    public string CountryName { get; set; }
    public bool IsDeleted { get; set; }
    
    //Navigation property
    public ICollection<Address> Addresses { get; set; } //One-to-Many (Country:1 => Address:M)
}