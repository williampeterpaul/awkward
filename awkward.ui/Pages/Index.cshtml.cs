using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awkward.api.Models;
using awkward.ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace awkward.ui.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IApiClient client)
        {
            Client = client;
        }

        [BindProperty]
        public Entity EntityA { get; set; }

        [BindProperty]
        public Entity EntityB { get; set; }

        private IApiClient Client { get; }

        public async Task<IActionResult> OnGetAsync()
        {
            EntityA = await Client.GetEntityAsync(1);
            EntityB = await Client.GetEntityAsync(2);

            if (EntityA == null || EntityB == null)
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

            var delta = Elo.PointsExchanged(EntityA.Rating, EntityB.Rating);

            EntityA.Rating += delta;
            EntityB.Rating -= delta;

            await Client.PutEntityAsync(EntityA);
            await Client.PutEntityAsync(EntityB);

            return RedirectToPage("./Index");
        }
    }
}
