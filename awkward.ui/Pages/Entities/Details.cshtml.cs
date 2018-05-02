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
    public class DetailsModel : PageModel
    {
        private readonly IApiClient _Client;

        public DetailsModel(IApiClient client)
        {
            _Client = client;
        }

        public Entity Entity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Entity = await _Client.GetEntityAsync(id.Value);

            if (Entity == null) return NotFound();

            return Page();
        }
    }
}
