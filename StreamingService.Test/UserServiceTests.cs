using StreamingService.Services;
using System;
using Xunit;

namespace StreamingService.Test
{
    /// <summary>
    /// Test suite for <see cref="UserService"/>.
    /// </summary>
    public class UserServiceTests
    {
        public readonly UserService SUT = new();

        // I've not really done any unit tests before and my visual studio isn't reacting well with this program so
        // this will be a little bit pseudo-codey. 
        // If you look at test factory class you can see how I injected SubscriptionService and UserService with mock data.
        // If you look at TestUserRepository and TestSubscriptionRepository you can see the mock data used in testing.

        [Fact]
        public void SubscribeFreemium()
        {
            IUserService userService = TestFactory.GetTestUserService();

            User user = new User();
            user.Email = "freemium@gmail.com";

            Subscription subscription = new Subscription();
            // matches freemium subscription in mock data list
            subscription.Id = "11111";

            user.Subscription = subscription;

            bool success  = userService.Subscribe(user);

            List<User> users = userService.GetAll();

            // Assert success
            // Assert users[4] != null
            // Assert users[4].subscription is freemium
            // Assert users[4].FreeSongs is 5
            // Assert users[4].RemainingSongs is 5

            // should test that a user has been added, the songs have been set correctly
        }

        [Fact]
        public void SubscribePremium()
        {
            IUserService userService = TestFactory.GetTestUserService();

            User user = new User();
            user.Email = "premium@gmail.com";

            Subscription subscription = new Subscription();
            // matches premium subscription in mock data list
            subscription.Id = "22222";

            user.Subscription = subscription;

            bool success = userService.Subscribe(user);


            List<User> users = userService.GetAll();

            // Asset success
            // Assert users[4] != null
            // Assert users[4].subscription is premium
            // Assert users[4].FreeSongs is 15
            // Assert users[4].RemainingSongs is 15

            // should test that a user has been added, the songs have been set correctly
        }


        [Fact]
        public void SubscribeUnlimitted()
        {
            IUserService userService = TestFactory.GetTestUserService();

            User user = new User();
            user.Email = "unlimitted@gmail.com";

            Subscription subscription = new Subscription();
            // matches unlimited subscription in mock data list
            subscription.Id = "33333";

            user.Subscription = subscription;

            bool success = userService.Subscribe(user);


            List<User> users = userService.GetAll();

            // Asset success
            // Assert users[4] != null
            // Assert users[4].subscription is unlimitted
            // Assert users[4].FreeSongs is 0
            // Assert users[4].RemainingSongs is 0

            // should test that a user has been added, the songs have been set correctly
        }

        [Fact]
        public void TestGetAll()
        {
            IUserService userService = TestFactory.GetTestUserService();

            userService.GetAll();
            // Assert that data matches what can be found in the mock user repository
        }


        public void TestGetUsersWithRemainingSongs()
        {
            IUserService userService = TestFactory.GetTestUserService();
            List<User> users = userService.GetUsersWithRemainingSongsThisMonth();

            // assert users[0].Email ==  patrick@gmail.com
            // assert users[1].Email == nigel@gmail.com
            // (the two customers in the mock data with remaining songs)
        }


        public void TestResetRemainingSongsThisMonth()
        {
            IUserService userService = TestFactory.GetTestUserService();
            userService.ResetRemainingSongsThisMonth();
            List<Users> users = userService.GetAll();

            // assert user[0].FreeSongs == user[0].RemainingSongs
            // assert user[1].FreeSongs == user[1].RemainingSongs
            // assert user[2].FreeSongs == user[2].RemainingSongs


        }


    }
}
