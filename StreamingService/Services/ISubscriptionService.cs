using StreamingService.Models;

namespace StreamingService.Services
{
    public interface ISubscriptionService
    {
        Subscription GetById(Guid Id);
    }
}