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
    public class CompareRandomModel : PageModel
    {
        public CompareRandomModel(IApiClient client)
        {
            Client = client;
        }

        public Entity EntityA { get; set; }

        public Entity EntityB { get; set; }

        private IApiClient Client { get; }

        public async Task OnGetAsync()
        {
            EntityA = await Client.GetEntityAsync(1);
            EntityB = await Client.GetEntityAsync(2);

            var exchange = EloRating.PointsExchanged(EntityA.Rating, EntityB.Rating);

            EntityA.Rating += exchange;
            EntityB.Rating -= exchange;

            EntityA.Modified = DateTime.Now;
            EntityB.Modified = DateTime.Now;

            await Client.PutEntityAsync(EntityA);
            await Client.PutEntityAsync(EntityB);
        }
    }
}