using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awkward.api.Data;
using awkward.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awkward.api.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        public EntitiesController(Context context)
        {
            Context = context;
        }

        private Context Context { get; }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entities = await Context.Entities.AsNoTracking().ToListAsync();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var entity = await Context.Entities.FindAsync(id);

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Entity value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Context.Entities.AddAsync(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Entity value)
        {
            if (!Context.Entities.Any(entity => entity.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            value.Modified = DateTime.Now;

            Context.Entities.Update(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await Context.Entities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            Context.Entities.Remove(entity);
            await Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
