namespace BookStoreApi.Entities;

public class OrderHistory
{
    public int Id { get; set; }
    public DateTime StatusDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    
   
}