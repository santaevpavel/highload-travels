using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using highload_travels.Models;

namespace highload_travels.Controllers
{     

    [Route("[controller]")]
    public abstract class BaseController<TEntity> : Controller where TEntity: Entity
    {
        protected readonly TravelsContext context;
        protected readonly ILogger logger;

        public BaseController(ILoggerFactory logger, TravelsContext context)
        {
            this.context = context;

            var resourceName = this.GetType().FullName.Split('.').Last().Replace("Controller", string.Empty);
            this.logger = logger.CreateLogger(resourceName);
        }  

        public abstract DbSet<TEntity> getDbSet();

        public abstract void update(TEntity source, TEntity target);

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            logger.LogInformation($"Getting all items.");

            var entities = getDbSet().ToList();
            return entities;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            logger.LogInformation($"Getting item with id = {id}.");

            var item = getDbSet().FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            logger.LogDebug($"Item: {item}.");

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Update([FromBody] TEntity item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            
            logger.LogInformation($"Updating item with id = {item.Id}.");

            var entity = getDbSet().FirstOrDefault(t => t.Id == item.Id);

            if (entity == null)
            {
                return NotFound();
            }

            update(item, entity);

            getDbSet().Update(entity);
            this.context.SaveChanges();
            return new OkResult();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult Create([FromBody] TEntity item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            logger.LogInformation($"Creating item with id = {item.Id}.");

            getDbSet().Add(item);
            this.context.SaveChanges();

            return new OkResult();
        }
    }
}
