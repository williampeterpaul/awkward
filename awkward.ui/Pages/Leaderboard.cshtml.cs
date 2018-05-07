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
    public class LeaderboardModel : PageModel
    {
        public LeaderboardModel(IApiClient client)
        {
            Client = client;
        }

        public IList<Entity> Entities { get; set; }

        private IApiClient Client { get; }

        public async Task OnGetAsync()
        {
            Entities = await Client.GetEntitiesAsync();

            Entities = Entities.OrderByDescending(e => e.Rating).Take(20).ToList();
        }
    }
}