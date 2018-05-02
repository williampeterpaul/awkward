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
        private readonly IApiClient _Client;

        public CreateModel(IApiClient client)
        {
            _Client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entity Entity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _Client.AddEntityAsync(Entity);

            return RedirectToPage("./Index");
        }
    }
}