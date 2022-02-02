namespace Infrastructure.MessageBus;

public class MessageOrderStatus
{
    public OrderStatus Status { get; set; }
    public string UserId { get; set; } = null !;
}