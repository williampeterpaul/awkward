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
        private readonly IApiClient _Client;

        public IndexModel(IApiClient client)
        {
            _Client = client;
        }

        public IList<Entity> Entities { get;set; }

        public async Task OnGetAsync()
        {
            Entities = await _Client.GetEntitiesAsync();
        }
    }
}
