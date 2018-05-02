using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using awkward.api.Models;
using awkward.ui.Data;

namespace awkward.ui.Pages.Entities
{
    public class DeleteModel : PageModel
    {
        private readonly awkward.ui.Data.ApplicationDbContext _context;

        public DeleteModel(awkward.ui.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entity.SingleOrDefaultAsync(m => m.Id == id);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await _context.Entity.FindAsync(id);

            if (Entity != null)
            {
                _context.Entity.Remove(Entity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
