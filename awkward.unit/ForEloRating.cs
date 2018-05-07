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
            var playerARating = 1000;
            var playerBRating = 1000;

            var exchanged = EloRating.PointsExchanged(playerARating, playerBRating);

            playerARating += exchanged;
            playerBRating -= exchanged; 

            Assert.True(playerARating > playerBRating);
        }
    }
}
