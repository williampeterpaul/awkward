using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Models.Static
{
    public static class EloRating
    {
        private const int Factor = 50;
        private const int Volatility = 400;

        // Taken from https://github.com/richardadalton/EloRate
        public static int PointsExchanged(int winnerRating, int loserRating)
        {
            var difference = (double) loserRating - winnerRating;
            var expected = 1 / (1 + (Math.Pow(10, (difference / Volatility))));

            var exchanged = (Int32) Math.Round((Factor * (1 - expected)), MidpointRounding.AwayFromZero);
            return exchanged;
        }
    }
}
