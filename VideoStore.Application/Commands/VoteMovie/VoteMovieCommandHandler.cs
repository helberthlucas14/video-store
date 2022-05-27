using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.VoteMovie
{
    public class VoteMovieCommandHandler : IRequestHandler<VoteMovieCommand, MovieViewModel>
    {
        private readonly IMovieRepository _movieRepository;

        public VoteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieViewModel> Handle(VoteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new InvalidOperationException("Filme não encontrado!");

            movie.CalculateVoteAvarage(request.Vote);

            movie.Update(movie.VoteAvarage, movie.VoteCount);

            await _movieRepository.SaveChangesAsync();

            return new MovieViewModel(movie);
        }
    }
}
