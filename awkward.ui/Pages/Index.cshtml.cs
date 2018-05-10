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

        public Entity EntityA { get; set; }

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
            EntityA = await Client.GetEntityAsync(1);
            EntityB = await Client.GetEntityAsync(2);

            var exchange = Elo.PointsExchanged(EntityA.Rating, EntityB.Rating);

            EntityA.Rating += exchange;
            EntityB.Rating -= exchange;

            await Client.PutEntityAsync(EntityA);
            await Client.PutEntityAsync(EntityB);

            return RedirectToPage("./Index");
        }
    }
}
