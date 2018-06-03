using awkward.api.Models;
using awkward.ui.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

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
