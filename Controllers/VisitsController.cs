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
    public class VisitsController : BaseController<Visit>
    {
        public VisitsController(TravelsContext context) : base(context)
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
    }
}
