using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence
{
    public class VideoStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<People> Person { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }
        public DbSet<MovieProductionCompany> MovieProductionCompany { get; set; }
        public DbSet<MovieDirector> MovieDirector { get; set; }

        public VideoStoreDbContext(DbContextOptions<VideoStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
