using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Models;
using StreamingService.Repositories;

namespace StreamingService.Services
{
    public class SubscriptionService : ISubscriptionService
    {

        private ISubscriptionRepository _subscriptionRepo;
        public SubscriptionService(ISubscriptionRepository _subscriptionRepository)
        {
            //Inject in the repository so it can be swapped out for other datasources. 
            this.subscriptionRepo = _subscriptionRepository;
        }

        public Subscription GetById(Guid Id)
        {
            return _subscriptionRepo.GetById(id);
        }

    }
}
