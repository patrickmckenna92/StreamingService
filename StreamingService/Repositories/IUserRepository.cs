using StreamingService.Models;

namespace StreamingService.Repositories
{
    public interface IUserRepository : IRepository
    {
        void Add(User user);
        global::System.Boolean Exists(global::System.String emailAddress);
        IEnumerable<User> GetAll();

    }
}