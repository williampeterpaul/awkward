using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static awkward.api.Models.Enumerations;

namespace awkward.api.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Grade Grade { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Medium Medium { get; set; }

        [Required]
        public int Rating { get; set; } = 1400;

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required]
        public string Description { get; set; } = "Default description";
    }
}
