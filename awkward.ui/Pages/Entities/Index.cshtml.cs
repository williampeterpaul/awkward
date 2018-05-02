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
    public class IndexModel : PageModel
    {
        private readonly awkward.ui.Data.ApplicationDbContext _context;

        public IndexModel(awkward.ui.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Entity> Entity { get;set; }

        public async Task OnGetAsync()
        {
            Entity = await _context.Entity.ToListAsync();
        }
    }
}
