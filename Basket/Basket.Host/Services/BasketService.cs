using Basket.Host.Models;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;
    private readonly IBus _bus;

    public BasketService(
        ICacheService cacheService,
        IBus bus)
    {
        _cacheService = cacheService;
        _bus = bus;
    }
    
    public async Task TestAdd(string userId, string data)
    {
       await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<TestGetResponse> TestGet(string userId)
    {
        var result = await _cacheService.GetAsync<string>(userId);
        return new TestGetResponse() { Data = result };
    }

    public Task TestRemove(string userId)
    {
        throw new NotImplementedException();
    }
}