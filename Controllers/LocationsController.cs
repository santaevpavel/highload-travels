using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using highload_travels.Models;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;

namespace highload_travels.Controllers
{     

    [Route("[controller]")]
    public class LocationsController : Controller
    {
        private readonly TravelsContext context;

        public LocationsController(TravelsContext context)
        {
            this.context = context;
        }  

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            var locations = this.context.Locations.ToList();
            return locations;
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult Get(int id)
        {
            var item = this.context.Locations.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Location item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var location = this.context.Locations.FirstOrDefault(t => t.Id == item.Id);

            if (location == null)
            {
                return NotFound();
            }

            location.Place = item.Place;
            location.City = item.City;
            location.Country = item.Country;
            location.Distance = item.Distance;

            this.context.Locations.Update(location);
            this.context.SaveChanges();
            return new OkResult();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult Create([FromBody] Location item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            this.context.Locations.Add(item);
            this.context.SaveChanges();

            return new OkResult();
        }
    }
}
