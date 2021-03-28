using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Infrastructure.Persistence;

namespace SportsManagement.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddDbContext<SportsManagementDbContext>(options => 
                options.UseInMemoryDatabase(databaseName: "SportsManagement"));

            services.AddScoped<ISportsManagementDbContext>(provider => provider.GetService<SportsManagementDbContext>());

            return services;
        }
    }
}
