using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using highload_travels.Models;

namespace highload_travels.Controllers
{
    [Route("[controller]")]
    public class UsersController : BaseController<User>
    {
        public UsersController(TravelsContext context) : base(context)
        {       
        }  

        public override DbSet<User> getDbSet(){
            return context.Users;
        }

        public override void update(User source, User target){
            target.Email = source.Email;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Gender = source.Gender;
            target.BirthDate = source.BirthDate;
        }
    }
}
