using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Entities
{
    public class EditModel : PageModel
    {
        private readonly IApiClient _Client;

        public EditModel(IApiClient client)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _Client.PutEntityAsync(Entity);

            return RedirectToPage("./Index");
        }

        private async Task<bool> EntityExists(int id)
        {
            return await _Client.GetEntityAsync(id) != null;
        }
    }
}
