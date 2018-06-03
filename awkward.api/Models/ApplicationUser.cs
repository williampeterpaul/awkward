using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace awkward.api.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Alias { get; set; }

        //public string Bio { get; set; } = "Describe yourself.";

        //public bool Administrator { get; set; } = false;

        //public DateTime Created { get; set; } = DateTime.Now;

        //public DateTime Modified { get; set; } = DateTime.Now;

        public List<ApplicationContent> Content { get; set; } = new List<ApplicationContent>();

        public List<ApplicationUser> Followers { get; set; } = new List<ApplicationUser>();

        public List<ApplicationUser> Following { get; set; } = new List<ApplicationUser>();
    }
}
