using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Contents
{
    public class CreateModel : PageModel
    {
        public CreateModel(IApiClient<ApplicationContent> client)
        {
            Client = client;
        }

        [BindProperty]
        public new ApplicationContent Content { get; set; }

        private IApiClient<ApplicationContent> Client { get; }

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

            await Client.AddEntityAsync(Content);

            return RedirectToPage("./Index");
        }
    }
}