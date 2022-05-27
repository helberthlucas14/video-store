using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VideoStore.Application.Commands.CreateUser;
using VideoStore.Application.Filter;
using VideoStore.Application.Validators;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Infrastructure;
using VideoStore.Infrastructure.Persistence;
using VideoStore.Infrastructure.Persistence.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VideoStore.Infrastructure.Auth;
using VideoStore.Infrastructure.CrossCutting.Commons;

namespace VideoStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("VideoStoreDB");
            connectionString = connectionString
                                .DbStringFormat(Configuration["DATABASE_HOST"],
                                                Configuration["DATABASE_USER"],
                                                Configuration["DATABASE_PASSWORD"]);

            services.AddDbContext<VideoStoreDbContext>(op => op.UseSqlServer(connectionString));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IProductionCompanyRepository, ProductionCompanyRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IMovieProductionCompanyRepository, MovieProductionCompanyRepository>();
            services.AddScoped<IMovieDirectorRepository, MovieDirectorRepository>();


            services.AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)))
                          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>())
                          .AddNewtonsoftJson(o =>
                          {
                              o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                          });

            services.AddMediatR(typeof(CreateUserCommand));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoStore.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando o esquema Bearer."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var Issuer = Configuration["JWTISSUER"];
            var Audience = Configuration["JWTAUDIENCE"];
            
            services
                .AddAuthentication("Bearer")
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Issuer,
                        ValidAudience = Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices
             .GetService<IServiceScopeFactory>()?
             .CreateScope();

            using var context = serviceScope?.ServiceProvider.GetService<VideoStoreDbContext>();
            context?.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoStore v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoStore v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
