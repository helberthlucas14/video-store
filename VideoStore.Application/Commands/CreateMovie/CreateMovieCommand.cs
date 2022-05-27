using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.InputModels;

namespace VideoStore.Application.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<int>
    {

        public string Title { get; set; }
        public string Overview { get; set; }
        public int VoteCount { get; set; }
        public double VoteAvarage { get; set; }
        public double Popularity { get; set; }
        public List<GenreInputModel> Genres { get; set; }
        public List<ActorInputModel> Actors { get; set; }
        public List<ProductionCompanyInputModel> ProductionCompanies { get; set; }
        public List<DirectorInputModel> Directors { get; set; }

        public CreateMovieCommand(string title, string overview, int voteCount, double voteAvarage, double popularity)
        {
            Title = title;
            Overview = overview;
            VoteCount = voteCount;
            VoteAvarage = voteAvarage;
            Popularity = popularity;
            Genres = new List<GenreInputModel>();
            Actors = new List<ActorInputModel>();
            ProductionCompanies = new List<ProductionCompanyInputModel>();
            Directors = new List<DirectorInputModel>();
        }

    }
}
