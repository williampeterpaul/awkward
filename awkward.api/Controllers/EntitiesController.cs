using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awkward.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace awkward.api.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        public EntitiesController(Repository repository)
        {
            Repository = repository;
        }

        private Repository Repository { get; set; }

        // GET api/entities
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return Repository.Get();
        }

        // GET api/entities/5
        [HttpGet("{id}")]
        public Entity Get(int id)
        {
            return Repository.Get(id);
        }

        // POST api/entities
        [HttpPost]
        public void Post([FromBody]Entity value)
        {
            Repository.Add(value);
        }

        // PUT api/entities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Entity value)
        {
            Repository.Update(value);
        }

        // DELETE api/entities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.Remove(id);
        }
    }
}
