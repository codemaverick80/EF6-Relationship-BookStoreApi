namespace BookStoreApi.Entities;

public class OrderStatus
{
    public int Id { get; set; }
    public string Status { get; set; }
    public bool IsDeleted { get; set; }
    
    public ICollection<OrderHistory> CustomerOrders { get; set; }
    
}