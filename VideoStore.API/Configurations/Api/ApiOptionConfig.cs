using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStore.Infrastructure.CrossCutting.Commons;
using VideoStore.Infrastructure.Persistence;

namespace VideoStore.API.Configurations.Api
{
    internal static class ApiOptionConfig
    {
        public static void LoadConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VideoStoreDB");
            connectionString = connectionString
                                .DbStringFormat(configuration["DATABASE_HOST"],
                                                configuration["DATABASE_USER"],
                                                configuration["DATABASE_PASSWORD"]);

            services.AddDbContext<VideoStoreDbContext>(op => op.UseSqlServer(connectionString));
        }
    }
}
