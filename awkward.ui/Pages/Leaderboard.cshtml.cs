using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using awkward.api.Models;
using awkward.ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static awkward.api.Models.Enumerations;

namespace awkward.ui.Pages
{
    public class LeaderboardModel : PageModel
    {
        public LeaderboardModel(IApiClient<ApplicationContent> client)
        {
            Client = client;
        }

        public IList<ApplicationContent> Entities { get; set; }

        [BindProperty]
        public Grade Grade { get; set; }

        [BindProperty]
        public Category Category { get; set; }

        [BindProperty]
        public Medium Medium { get; set; }

        private IApiClient<ApplicationContent> Client { get; }

        public async Task OnGetAsync()
        {
            Entities = await Client.GetAsync();

            Entities = Entities.OrderByDescending(e => e.Rating).Take(20).ToList();
        }

        public async Task OnPostAsync()
        {
            Entities = await Client.GetAsync();

            Entities = Entities.OrderByDescending(e => e.Rating).Where(e => 
                e.Category.Equals(Category) && 
                e.Medium.Equals(Medium) && 
                e.Grade.Equals(Grade)).ToList();
        }
    }
}