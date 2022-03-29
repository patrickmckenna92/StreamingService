using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamingService.Loggers;

namespace StreamingService.Loggers
{
    public class UserLoggerMessages : IUserLogger
    {

        public void StartSubscribeMessage(User user)
        {
            Console.WriteLine(string.Format("Log: Start add user with email '{0}'", user.EmailAddress));
        }

        public void EndSubscribeMessage(User user)
        {
            Console.WriteLine(string.Format("Log: End add user with email '{0}'", user.EmailAddress));
        }
    }
}
