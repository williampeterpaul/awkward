using awkward.api.Data;
using awkward.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        public ContentController(ApplicationContext context)
        {
            Context = context;
        }

        private ApplicationContext Context { get; }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var contents = await Context.Contents.AsNoTracking().ToListAsync();

            return Ok(contents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var content = await Context.Contents.FindAsync(id);

            return Ok(content);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ApplicationContent value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Context.Contents.AddAsync(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]ApplicationContent value)
        {
            if (!Context.Contents.Any(content => content.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            value.Modified = DateTime.Now;

            Context.Contents.Update(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var content = await Context.Contents.FindAsync(id);

            if (content == null)
            {
                return NotFound();
            }

            Context.Contents.Remove(content);
            await Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
