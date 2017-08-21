using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using highload_travels.Models;

namespace highload_travels.Controllers
{
    [Route("[controller]")]
    public class LocationsController : BaseController<Location>
    {

        public LocationsController(ILoggerFactory logger, TravelsContext context) : base (logger, context)
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
