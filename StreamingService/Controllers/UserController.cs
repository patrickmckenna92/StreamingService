using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Models;
using StreamingService.Services;
using System;
using System.Collections.Generic;

namespace StreamingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void Subscribe([FromBody] SubscribeModel model)
        {
            var userService = new UserService();
            userService.Subscribe(model.EmailAddress, model.SubscriptionId);
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
