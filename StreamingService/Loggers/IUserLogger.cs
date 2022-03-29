using StreamingService.Models;

namespace StreamingService.Loggers
{
    public interface IUserLogger
    {
        void EndSubscribeMessage(User user);
        void StartSubscribeMessage(User user);
    }
}