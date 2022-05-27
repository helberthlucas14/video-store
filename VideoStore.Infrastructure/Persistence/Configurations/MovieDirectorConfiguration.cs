using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Infrastructure.Persistence.Seeds;

namespace VideoStore.Infrastructure.Persistence.Configurations
{
    public class MovieDirectorConfiguration : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder.HasKey(p => new { p.MovieId, p.PeopleId });
            builder.HasData(MovieDirectorSeed.Seed());
        }
    }
}
