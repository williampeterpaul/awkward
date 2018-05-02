using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using awkward.api.Models;
using awkward.ui.Data;

namespace awkward.ui.Pages.Entities
{
    public class CreateModel : PageModel
    {
        private readonly awkward.ui.Data.ApplicationDbContext _context;

        public CreateModel(awkward.ui.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entity.Add(Entity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}