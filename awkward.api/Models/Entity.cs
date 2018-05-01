using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public object Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
