using awkward.api.Models;
using System;
using Xunit;

namespace awkward.unit
{
    public class ForEloRating
    {
        [Fact]
        public void Should_Assert_Winner_Rating_Greater_Than_Loser_Rating()
        {
            var playerARating = 1400;
            var playerBRating = 900;

            var exchanged = EloRating.PointsExchanged(playerARating, playerBRating);

            playerARating += exchanged;
            playerBRating -= exchanged; 

            Assert.True(playerARating > playerBRating);
        }
    }
}
