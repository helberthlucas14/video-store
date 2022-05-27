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
    public class ProductionCompanyConfiguration : IEntityTypeConfiguration<ProductionCompany>
    {
        public void Configure(EntityTypeBuilder<ProductionCompany> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasData(ProductionCompanySeed.Seed());
        }
    }
}
