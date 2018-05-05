using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Entities
{
    public class CreateModel : PageModel
    {
        public CreateModel(IApiClient client)
        {
            Client = client;
        }

        [BindProperty]
        public Entity Entity { get; set; }

        private IApiClient Client { get; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Client.AddEntityAsync(Entity);

            return RedirectToPage("./Index");
        }
    }
}