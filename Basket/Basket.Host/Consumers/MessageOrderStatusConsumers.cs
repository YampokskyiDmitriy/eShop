using Basket.Host.Services.Interfaces;
using EasyNetQ.AutoSubscribe;
using Infrastructure.MessageBus;

namespace Basket.Host.Consumers;

public class MessageOrderStatusConsumers: IConsumeAsync<MessageOrderStatus>
{
    private readonly ILogger<MessageOrderStatusConsumers> _logger;
    private readonly IBasketService _basketService;

    public MessageOrderStatusConsumers(
        ILogger<MessageOrderStatusConsumers> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }
    
    public async Task ConsumeAsync(MessageOrderStatus message, CancellationToken cancellationToken = new CancellationToken())
    {
        if (message.Status == OrderStatus.Created)
        {
            await _basketService.TestRemove(message.UserId);
            _logger.LogInformation($"Order was created for user with id {message.UserId}");
        }
    }
}