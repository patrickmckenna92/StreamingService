using StreamingService.Models;
using StreamingService.Repositories;
using System;
using System.Collections.Generic;
using StreamingService.Loggers;
using StreamingService.Factory;
using StreamingService.Helper;

namespace StreamingService.Services
{
    public class UserService : IUserService
    {

        private IUserRepository userRepo;
        private ISubscriptionService subscriptionService;

        // Inject in the userRepo so that we can swap out the data source.
        // Creates a dependency inversion as lower module dependant on caller.
        //
        public UserService(IUserRepository userRepo, ISubscriptionService subscriptionService)
        {
            this.userRepo = userRepo;
            this.subscriptionService = subscriptionService;
        }


        // Having two parameters means if we want to pass more data to this method we will have to change it every time.
        // Also makes sense that if this is the user class, it should only really deal with User objects. SRP
        public bool Subscribe(User user)
        {
            //factory means we could easily change the messages displayed without making changes to the UserLogger class.
            IUserLogger userLogger = Factory.GetUserLogger();
            userLogger.StartSubscribeMessage(user);

            if (string.IsNullOrWhiteSpace(user.EmailAddress))
            {
                return false;
            }

            if (userRepo.Exists(user.EmailAddress))
            {
                return false;
            }


            user.Subscription = subscriptionService.GetById(user.Subscription.Id);

            // didn't really know what to do with unlimitted user.
            // I removed it from the program as it was violating lsp and I moved ResetRemainingSongsThisMonth to this class so  it was the same as User
            // It would make more sense for there to be a LimittedUser class that inherits which contains functionality for tracking listened to songs.

            //else if (subscrition.Package == Packages.Unlimitted)
            //{
            //    user = new UnlimittedUser
            //    {
            //        EmailAddress = emailAddress,
            //        SubscriptionId = subscriptionId,
            //    };
            //}


            //If we want to change the calculation for free songs we could swap this out for another implementation easily using factory
            IPackageHelper packageHelper = Factory.GetPackageHelper();
            user.FreeSongs = packageHelper.CalculateFreeSongs(user.Subscription.Package);
            ResetRemainingSongsThisMonthSingleUser(user);

            userRepo.Add(user);

            userLogger.EndSubscribeMessage(user);

            return true;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepo.GetAll();
        }

        public IEnumerable<User> GetUsersWithRemainingSongsThisMonth()
        {
            List<User> users = new List<User>();
            foreach (User u in userRepo.GetAll())
            {
                // could maybe do an "or" for if they have an unlimtted subscription as they will always have songs remaining.
                if (u.RemainingSongsThisMonth != 0)
                {
                    users.Add(u);
                }
            }
            return users;
        }

        /// <summary>
        /// To be called once per month at a fixed day/time to set every user's 
        ///  RemainingSongsThisMonth back to their FreeSongs limit.
        /// </summary>
        public void ResetRemainingSongsThisMonth()
        {
            foreach (User u in userRepo.GetAll())
            {
                ResetRemainingSongsThisMonthSingleUser(u);
            }
            userRepo.SaveChanges();
        }


        // Moved method that was in user to UserService.
        // As we have a UserService may as well keep functionality for user objects in one place.
        // That way if we want to change the way data is stored we can change the user class. If we want to change functionality we can change the UserService class. 
        public void ResetRemainingSongsThisMonthSingleUser(User user)
        {
            user.RemainingSongsThisMonth = user.FreeSongs;
        }
    }



}
