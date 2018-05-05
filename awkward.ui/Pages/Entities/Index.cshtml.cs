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
    public class IndexModel : PageModel
    {
        public IndexModel(IApiClient client)
        {
            Client = client;
        }

        public IList<Entity> Entities { get; set; }

        private IApiClient Client { get; }

        public async Task OnGetAsync()
        {
            Entities = await Client.GetEntitiesAsync();
        }
    }
}
