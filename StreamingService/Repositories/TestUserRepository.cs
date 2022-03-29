using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Models;

namespace StreamingService.Repositories
{
    public class TestUserRepository : IUserRepository
    {

        private List<User> users;

        public TestUserRepository()
        {
            users = GetMockUsers();
        }


        public void Add(User user)
        {
            users.Add(user);
        }

        public global::System.Boolean Exists(global::System.String emailAddress)
        {
            var result = users.Any(x => x.EmailAddress == emailAddress);
            return result;
        }


        public IEnumerable<User> GetAll()
        {
            return users;
        }


        private List<User> GetMockUsers()
        {
            List<User> users = new List<User>();
            
            
            User user1 = new User();
            user1.EmailAddress = "patrick@gmail.com";
            user1.FreeSongs = 5;
            user1.RemainingSongsThisMonth = 5;

            User user2 = new User();
            user2.EmailAddress = "lilly@gmail.com";
            user2.FreeSongs = 15;
            user2.RemainingSongsThisMonth = 0;

            User user3 = new User();
            user3.EmailAddress = "nigel@gmail.com";
            user3.FreeSongs = 5;
            user3.RemainingSongsThisMonth = 1;


            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            return users;
        }


    }
}
