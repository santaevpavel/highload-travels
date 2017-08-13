using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using highload_travels.Models;

namespace highload_travels.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        // GET users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new User[] { new User(), new User() };
        }

        // GET users/{id}
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return new User();
        }

        // POST users/{id}
        [HttpPost("{id}")]
        public User Post([FromBody]User user, int id)
        {
            user.Id = id;
            return user;
        }

        // POST users/new
        [HttpPost("new")]
        public User PostNew([FromBody]User user)
        {
            return user;
        }
    }
}
