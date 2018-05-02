using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Entities
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient _Client;

        public DeleteModel(IApiClient client)
        {
            _Client = client;
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Entity = await _Client.GetEntityAsync(id.Value);

            if (Entity == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Entity = await _Client.GetEntityAsync(id.Value);

            if (Entity != null) await _Client.RemoveTripAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
