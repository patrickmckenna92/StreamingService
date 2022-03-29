using StreamingService.Models;
using System;
using System.Linq;

namespace StreamingService.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly Context _context;

        public SubscriptionRepository(Context context)
        {
            _context = new Context();
        }

        public Subscription GetById(Guid id)
        {
            var result = this._context.Subscriptions.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
