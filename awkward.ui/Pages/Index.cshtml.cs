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

        private IApiClient Client { get; }
    }
}
