using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsManagement.API.Context;
using SportsManagement.API.Filters;
using SportsManagement.API.IoC;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Application.Common.IoC;
using SportsManagement.Infrastructure.IoC;

namespace SportsManagement.API
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
            services.AddApplicationDependencies();
            services.AddInfrastructureDependencies();

            services.AddSingleton<IUserContext, UserContext>();

            services.AddHttpContextAccessor();

            services.AddControllers(options => options.Filters.Add<APIExceptionFilterAttribute>())
                    .AddFluentValidation();

            services.AddJwtTokenAuthentication(Configuration);

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerSetup();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
