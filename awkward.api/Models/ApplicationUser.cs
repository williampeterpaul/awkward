using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public new int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Bio { get; set; } = "Describe yourself.";

        [Required]
        public bool Administrator { get; set; } = false;

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required]
        public List<ApplicationContent> Content { get; set; } = new List<ApplicationContent>();

        [Required]
        public List<ApplicationUser> Followers { get; set; } = new List<ApplicationUser>();

        [Required]
        public List<ApplicationUser> Following { get; set; } = new List<ApplicationUser>();
    }
}
