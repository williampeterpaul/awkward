using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using awkward.api.Models;
using awkward.ui.Services;

namespace awkward.ui.Pages.Content
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(IApiClient client)
        {
            Client = client;
        }

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
    }
}
