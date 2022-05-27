using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movie;
        private readonly IMovieGenreRepository _movieGenre;
        private readonly IMovieProductionCompanyRepository _movieProduction;
        private readonly IMovieActorRepository _movieActor;
        private readonly IMovieDirectorRepository _movieDirector;

        public CreateMovieCommandHandler(IMovieRepository movie,
            IMovieGenreRepository movieGenre,
            IMovieProductionCompanyRepository movieProduction,
            IMovieActorRepository movieActor,
            IMovieDirectorRepository movieDirector)
        {
            _movie = movie;
            _movieGenre = movieGenre;
            _movieProduction = movieProduction;
            _movieDirector = movieDirector;
            _movieActor = movieActor;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie(request.Title, request.Overview, request.VoteCount, request.VoteAvarage, request.Popularity);

            foreach (var genre in request.Genres)
            {
                movie.Genres.Add(new MovieGenre(movie.Id, genre.Id));
            }

            foreach (var actor in request.Actors)
            {
                movie.Actors.Add(new MovieActor(movie.Id, actor.Id));
            }

            foreach (var productionCompany in request.ProductionCompanies)
            {
                movie.ProductionComapanies.Add(new MovieProductionCompany(movie.Id, productionCompany.Id));
            }

            foreach (var directory in request.Directors)
            {
                movie.Directors.Add(new MovieDirector(movie.Id, directory.Id));
            }

            await _movie.AddMovieAsync(movie);

            return movie.Id;
        }
    }
}
