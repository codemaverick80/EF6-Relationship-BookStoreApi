namespace BookStoreApi.Entities;

public class ShippingMethod
{
    public int Id { get; set; }
    public string MethodName { get; set; }
    public double Cost { get; set; }
    public bool  IsDeleted { get; set; }
    
    public ICollection<Order> Orders { get; set; }

  
    
}