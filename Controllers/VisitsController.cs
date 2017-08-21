using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using highload_travels.Models;

namespace highload_travels.Controllers
{
    [Route("[controller]")]
    public class VisitsController : BaseController<Visit>
    {
        public VisitsController(ILoggerFactory logger, TravelsContext context) : base(logger, context)
        {       
        }  

        public override DbSet<Visit> getDbSet(){
            return context.Visits;
        }

        public override void update(Visit source, Visit target){
            target.Location = source.Location;
            target.User = source.User;
            target.VisitedAt = source.VisitedAt;
            target.Mark = source.Mark;
        }
        
        [HttpGet]
        [Route("test")]
        public IEnumerable<Visit> Get2()
        {
            logger.LogInformation($"Getting all items 2.");

            var entities = getDbSet().Include(i => i.User).ToList();
            return entities;
        }
    }
}
