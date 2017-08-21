using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using highload_travels.Models;

namespace highload_travels.Controllers
{
    [Route("[controller]")]
    public class UsersController : BaseController<User>
    {
        public UsersController(ILoggerFactory logger, TravelsContext context) : base(logger, context)
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
