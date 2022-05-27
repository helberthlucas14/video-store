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
    public class MovieProductionCompanyConfiguration : IEntityTypeConfiguration<MovieProductionCompany>
    {
        public void Configure(EntityTypeBuilder<MovieProductionCompany> builder)
        {
            builder.HasKey(p => new { p.MovieId, p.ProductionCompanyId });
            builder.HasData(MovieProductionCompanySeed.Seed());
        }
    }
}
