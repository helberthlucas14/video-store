using Microsoft.Extensions.DependencyInjection;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Infrastructure.Auth;
using VideoStore.Infrastructure.Persistence.Repositories;

namespace VideoStore.API.Configurations.Api
{
    public static class ApiInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterApplicationServices();
            services.RegisterInfraServices();
            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection RegisterInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IProductionCompanyRepository, ProductionCompanyRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IMovieProductionCompanyRepository, MovieProductionCompanyRepository>();
            services.AddScoped<IMovieDirectorRepository, MovieDirectorRepository>();

            return services;
        }
    }
}
