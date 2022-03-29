using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class TestSubscriptionRepository : ISubscriptionRepository
    {


        private List<Subscription> subscriptions;

        public TestSubscriptionRepository()
        {
            subscriptions = GetMockSubscriptions();
        }


        public Subscription GetById(Guid id)
        {
            return subscriptions.Where(s => id == s.Id ).FirstOrDefault();
        }



        private List<Subscription> GetMockSubscriptions()
        {

            List<Subscription> subs = new List<Subscription>();

            Subscription sub1 = new Subscription();
            sub1.Id = "11111";
            sub1.Package = Packages.Freemium;

            Subscription sub2 = new Subscription();
            sub2.Id = "22222";
            sub2.Package = Packages.Premium;

            Subscription sub3= new Subscription();
            sub3.Id = "33333";
            sub3.Package = Packages.Unlimitted;


            subs.Add(sub1);
            subs.Add(sub2);
            subs.Add(sub3);
            return subs;          
        }

    }
}
