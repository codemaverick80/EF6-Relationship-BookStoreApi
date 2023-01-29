namespace BookStoreApi.Entities;



public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public int CustomerId { get; set; }
    
    public int AddressId { get; set; }

    
    public int ShippingMethodId { get; set; }

    
    public ICollection<OrderHistory> OrderStatuses { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    
}