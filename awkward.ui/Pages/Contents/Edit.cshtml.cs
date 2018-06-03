using awkward.api.Models;
using awkward.ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace awkward.ui.Pages.Contents
{
    public class EditModel : PageModel
    {
        public EditModel(IApiClient<ApplicationContent> client)
        {
            Client = client;
        }

        [BindProperty]
        public new ApplicationContent Content { get; set; }

        private IApiClient<ApplicationContent> Client { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content = await Client.GetAsync(id.Value);

            if (Content == null)
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

            await Client.PutAsync(Content);

            return RedirectToPage("./Index");
        }
    }
}
