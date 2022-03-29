using StreamingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreamingService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository()
        {

            //thought it would be a good idea to create the context within the classes implementation as it is
            // to do with entity framework. It's possible to implement a repository without a context so didn't make sense to have it as a parameter.
            _context = new Context();
        }

        public bool Exists(string emailAddress)
        {
            var result = this._context.Users.Any(x => x.EmailAddress == emailAddress);
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            var result = this._context.Users.ToList();
            return result;
        }

        public void Add(User user)
        {
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
