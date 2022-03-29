using StreamingService.Models;

namespace StreamingService.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersWithRemainingSongsThisMonth();
        void ResetRemainingSongsThisMonth();
        global::System.Boolean Subscribe(global::System.String emailAddress, Guid subscriptionId);
        void ResetRemainingSongsThisMonthSingleUser(User user);
    }
}