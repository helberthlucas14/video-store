using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoStore.Application.Commands.CreateUser;
using VideoStore.Application.Filter;
using VideoStore.Application.Validators;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Infrastructure.Persistence;
using VideoStore.Infrastructure.Persistence.Repositories;
using VideoStore.Infrastructure.Auth;
using VideoStore.API.Configurations.Swagger;
using VideoStore.Infrastructure.CrossCutting.Commons;
using VideoStore.API.Configurations.Api;
using VideoStore.Infrastructure.Persistence.Configurations;

namespace VideoStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.LoadConfiguration(Configuration);
            services.RegisterServices();

            services.AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)))
                          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>())
                          .AddNewtonsoftJson(o =>
                          {
                              o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                          });

            services.AddMediatR(typeof(CreateUserCommand));
            services.AddSwaggerDocumentation(Configuration);

            services.AddMvc().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UpdateDatabase();

            app.UseSwaggerDocumentation(env);

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
