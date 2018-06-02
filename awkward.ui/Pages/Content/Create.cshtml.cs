using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Content
{
    public class CreateModel : PageModel
    {
        public CreateModel(IApiClient client)
        {
            Client = client;
        }

        [BindProperty]
        public Media Media { get; set; }

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

            await Client.AddEntityAsync(Media);

            return RedirectToPage("./Index");
        }
    }
}