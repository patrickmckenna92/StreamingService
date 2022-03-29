using StreamingService.Models;

namespace StreamingService.Repositories
{
    public interface ISubscriptionRepository : IRepository
    {
        Subscription GetById(Guid id);
    }

}