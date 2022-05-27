using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; private set; }
        public string Overview { get; private set; }
        public int VoteCount { get; private set; }
        public double VoteAvarage { get; private set; }
        public double Popularity { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }

        public List<MovieGenre> Genres { get; private set; }
        public List<MovieActor> Actors { get; private set; }
        public List<MovieDirector> Directors { get; private set; }
        public List<MovieProductionCompany> ProductionComapanies { get; private set; }

        public Movie(string title, string overview, int voteCount, double voteAvarage, double popularity)
        {
            Title = title;
            Overview = overview;
            VoteCount = voteCount;
            VoteAvarage = voteAvarage;
            Popularity = popularity;

            Genres = new List<MovieGenre>();
            Actors = new List<MovieActor>();
            Directors = new List<MovieDirector>();
            ProductionComapanies = new List<MovieProductionCompany>();
        }

        public Movie(int id, string title, string overview, int voteCount, double voteAvarage, double popularity) : base(id)
        {
            Title = title;
            Overview = overview;
            VoteCount = voteCount;
            VoteAvarage = voteAvarage;
            Popularity = popularity;

            Genres = new List<MovieGenre>();
            Actors = new List<MovieActor>();
            Directors = new List<MovieDirector>();
            ProductionComapanies = new List<MovieProductionCompany>();
        }

        public void Update(double voteAvarage, int voteCount)
        {
            VoteAvarage = voteAvarage;
            VoteCount = voteCount;
        }

        public void CalculateVoteAvarage(int vote)
        {
            try
            {
                VoteAvarage = (VoteCount * VoteAvarage + vote) / (VoteCount += 1);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro no Calculo do Voto: " + e.Message);
            }
        }
    }
}
