using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Bowling.Tests
{
    public class GameFixture
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1", 20)]
        [InlineData("10,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1", 30)]
        [InlineData("5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1", 29)]
        public void CanCalculateScore(string rolls, int expected)
        {
            var game = new Game(rolls.Split(',').Select(int.Parse).ToList());
            game.Score().ShouldBe(expected);
        }
    }
}
