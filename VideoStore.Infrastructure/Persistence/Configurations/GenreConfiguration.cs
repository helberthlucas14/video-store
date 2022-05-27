using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoStore.Application.Entities;
using VideoStore.Infrastructure.Persistence.Seeds;

namespace VideoStore.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(GenreSeed.Seed());
        }
    }
}
