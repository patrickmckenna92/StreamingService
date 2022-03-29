using System;
using System.ComponentModel.DataAnnotations;

namespace StreamingService.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }


        //No need for a subscription ID as it already 
        //Has an object of type subscription which contains that data.
        //public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public int FreeSongs { get; set; }
        public int RemainingSongsThisMonth { get; set; }


        // Removed this method as we have a user service. 

        //public virtual void ResetRemainingSongsThisMonth()
        //{
        //    this.RemainingSongsThisMonth = FreeSongs;
        //}
    }



    // Got rid of unlimtted user as it violates Liskov's substitution principle. 
    // If we were to use this as a substitute for type user then the program would break
    //

    //public class UnlimittedUser : User
    //{
    //    public override void ResetRemainingSongsThisMonth()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
