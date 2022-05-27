using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using Xunit;

namespace VideoStore.Tests.Core.Enitites
{
    public class MovieTests
    {
        [Fact]
        public void TestCalculateVoteWorksAndVoteAvarage()
        {
            var movie = new Movie(1, "Movie Test", "", 0, 0, 3);

            var vote1 = 4;
            var vote2 = 2;
            var vote3 = 1;

            var espectAvarage = 2.3333333333333335;
            var espectCountVote = 3;

            movie.CalculateVoteAvarage(vote1);
            movie.CalculateVoteAvarage(vote2);
            movie.CalculateVoteAvarage(vote3);

            Assert.Equal(espectAvarage, movie.VoteAvarage);
            Assert.Equal(espectCountVote, movie.VoteCount);
        }
    }
}
