using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Infrastructure.Persistence.Configurations
{
    public static class ContextConfiguration
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                 .GetService<IServiceScopeFactory>()?
                 .CreateScope();

            using var context = serviceScope?.ServiceProvider.GetService<VideoStoreDbContext>();
            context?.Database.Migrate();
        }
    }
}
