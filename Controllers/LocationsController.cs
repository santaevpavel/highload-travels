using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using highload_travels.Models;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;

namespace highload_travels.Controllers
{     
    [Route("[controller]")]
    public class LocationsController : BaseController<Location>
    {

        public LocationsController(TravelsContext context) : base (context)
        {
        }  

        public override DbSet<Location> getDbSet(){
            return context.Locations;
        }

        public override void update(Location source, Location target){
            target.Place = source.Place;
            target.Country = source.Country;
            target.City = source.City;
            target.Distance = source.Distance;
        }

    }
}
