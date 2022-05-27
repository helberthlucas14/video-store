using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;

namespace VideoStore.Application.Commands.VoteMovie
{
    public class VoteMovieCommand : IRequest<MovieViewModel>
    {
        public int MovieId { get; set; }
        public int Vote { get; set; }

        public VoteMovieCommand(int movieId, int vote)
        {
            MovieId = movieId;
            Vote = vote;
        }


    }
}
