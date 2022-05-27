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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();

            builder.HasQueryFilter(p => p.Active);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("getdate()");

            builder.Property(p => p.Active)
            .HasDefaultValue(true);

            builder.HasData(UserSeed.Seed());

        }
    }
}
