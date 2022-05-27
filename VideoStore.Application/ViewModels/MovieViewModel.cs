using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public int VoteCount { get; set; }
        public double VoteAvarage { get; set; }
        public double Popularity { get; set; }
        public List<Genre> Genres { get; set; }
        public List<People> Actors { get; set; }
        public List<People> Directors { get; set; }
        public List<ProductionCompany> ProductionComapanies { get; set; }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Overview = movie.Overview;
            VoteCount = movie.VoteCount;
            VoteAvarage = movie.VoteAvarage;
            Popularity = movie.Popularity;

            Genres = new List<Genre>();
            Directors = new List<People>();
            Actors = new List<People>();
            ProductionComapanies = new List<ProductionCompany>();

            movie.Genres.ForEach(g => { Genres.Add(g.Genre); });
            movie.Actors.ForEach(a => { Actors.Add(a.People); });
            movie.Directors.ForEach(d => { Directors.Add(d.People); });
            movie.ProductionComapanies.ForEach(p => { ProductionComapanies.Add(p.ProductionCompany); });
        }

        public MovieViewModel(int id, string title, string overview, int voteCount, double voteAvarage, double popularity, List<MovieGenre> genres, List<MovieActor> actors, List<MovieDirector> directors, List<MovieProductionCompany> productionComapanies)
        {
            Id = id;
            Title = title;
            Overview = overview;
            VoteCount = voteCount;
            VoteAvarage = voteAvarage;
            Popularity = popularity;

            Genres = new List<Genre>();
            Directors = new List<People>();
            Actors = new List<People>();
            ProductionComapanies = new List<ProductionCompany>();

            genres.ForEach(g => { Genres.Add(g.Genre); });
            actors.ForEach(a => { Actors.Add(a.People); });
            directors.ForEach(d => { Directors.Add(d.People); });
            productionComapanies.ForEach(p => { ProductionComapanies.Add(p.ProductionCompany); });

        }

    }
}
