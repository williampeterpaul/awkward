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
    public class UsersController : Controller
    {
        public UsersController(Context context)
        {
            Context = context;
        }

        private Context Context { get; }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await Context.Users.AsNoTracking().ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await Context.Users.FindAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]User value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Context.Users.AddAsync(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]User value)
        {
            if (!Context.Users.Any(user => user.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            value.Modified = DateTime.Now;

            Context.Users.Update(value);
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await Context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
