using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Contents
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(IApiClient<ApplicationContent> client)
        {
            Client = client;
        }

        public new ApplicationContent Content { get; set; }

        private IApiClient<ApplicationContent> Client { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content = await Client.GetAsync(id.Value);

            if (Content == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
