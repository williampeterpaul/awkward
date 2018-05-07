using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Models
{
    public static class Enumerations
    {
        public enum Category
        {
            Clutch = 0,
            Spray = 1,
            Ninja = 2,
            Comic = 3
        }

        public enum Medium
        {
            Sniper = 0,
            Rifle = 1,
            Pistol = 2,
            Knife = 3
        }

        public enum Merit
        {
            Best = 0,
            Worst = 1,
        }
    }
}
