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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Title).IsUnique();

            builder.Property(p => p.Active)
                   .HasDefaultValue(true);

            builder.Property(p => p.Popularity)
                   .HasDefaultValue(0);

            builder.Property(p => p.VoteAvarage)
                   .HasDefaultValue(0);

            builder.Property(p => p.VoteCount)
                   .HasDefaultValue(0);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("getdate()");

            builder.HasData(MovieSeed.Seed());

        }
    }
}
