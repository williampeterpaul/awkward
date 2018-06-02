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

namespace awkward.ui.Pages.Content
{
    public class EditModel : PageModel
    {
        public EditModel(IApiClient client)
        {
            Client = client;
        }

        [BindProperty]
        public Media Media { get; set; }

        private IApiClient Client { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Media = await Client.GetEntityAsync(id.Value);

            if (Media == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Client.PutEntityAsync(Media);

            return RedirectToPage("./Index");
        }

        private async Task<bool> EntityExists(int id)
        {
            return await Client.GetEntityAsync(id) != null;
        }
    }
}
