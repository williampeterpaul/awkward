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
    public class IndexModel : PageModel
    {
        public IndexModel(IApiClient<ApplicationContent> client)
        {
            Client = client;
        }

        public IList<ApplicationContent> Contents { get; set; }

        private IApiClient<ApplicationContent> Client { get; }

        public async Task OnGetAsync()
        {
            Contents = await Client.GetAsync();
        }
    }
}
