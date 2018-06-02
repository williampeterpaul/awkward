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
    public class IndexModel : PageModel
    {
        public IndexModel(IApiClient client)
        {
            Client = client;
        }

        public IList<Media> MediaList { get; set; }

        private IApiClient Client { get; }

        public async Task OnGetAsync()
        {
            MediaList = await Client.GetEntitiesAsync();
        }
    }
}
