using StreamingService.Models;
using StreamingService.Services;




namespace StreamingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void Subscribe([FromBody] SubscribeModel model)
        {
            //Initial Test!

            var userService = Factory.GetUserService();
            User user = new User();
            user.EmailAddress = model.EmailAddress;

            ISubscriptionService ss = Factory.GetSubscriptionService();
            user.Subscription = ss.GetById(model.SubscriptionId);


            
            


            user.EmailAddress = model.EmailAddress;
                     
            var result = userService.Subscribe(user);
            return result;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var userService = new UserService();
            var result = userService.GetUsers();
            return result;
        }

        [HttpGet]
        [Route("withRemainingSongs")]
        public IEnumerable<User> GetUsersWithRemainingSongsThisMonth()
        {
            var userService = new UserService();
            var result = userService.GetUsersWithRemainingSongsThisMonth();
            return result;
        }

        [HttpPost]
        [Route("reset")]
        public void ResetRemainingSongsThisMonth()
        {
            var userService = new UserService();
            userService.ResetRemainingSongsThisMonth();
        }

        public class SubscribeModel
        {
            public string EmailAddress { get; set; }

            public Guid SubscriptionId { get; set; }
        }
    }
}
