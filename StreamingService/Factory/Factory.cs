using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Repositories;
using StreamingService.Services;
using StreamingService.Loggers;
using StreamingService.Helper;


namespace StreamingService.Factory
{
    public static class Factory
    {
        // These are my classes that contain methods, a factory class means that I can quickly substitute out different implementations of interfaces.

        public static ISubscriptionRepository GetSubscriptionRepository()
        {
            return new SubscriptionRepository();
        }

        public static IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }

        public static IUserService GetUserService()
        {
            return new UserService(GetUserRepository(), GetSubscriptionService());
        }

        public static ISubscriptionService GetSubscriptionService()
        {
            return new SubscriptionService(GetSubscriptionRepository());
        }

        public static IUserLogger GetUserLogger()
        {
            return new UserLoggerMessages();
        }

        public static IPackageHelper GetPackageHelper()
        {
            return new PackageHelper();
        }
    }


    public static class TestFactory
    {

        public static ISubscriptionRepository GetTestSubscriptionRepository()
        {
            return new TestSubscriptionRepository();
        }

        public static IUserRepository GetTestUserRepository()
        {
            return new TestUserRepository();
        }

        public static ISubscriptionService GetTestSubscriptionService()
        {
            return new SubscriptionService(GetTestSubscriptionRepository());
        }


        //Build test user service which has been handed the test user repository and test subscription service (which has been injected with a mock subscription repository).
        public static IUserService GetTestUserService()
        {
            return new UserService(GetTestUserRepository(), GetTestSubscriptionService());
        }
    }
}
