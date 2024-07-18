using Infrastructure.Interfaces;
using Infrastructure.Repos;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IDepartmentsAndRolesRepo, DepartmentsAndRolesRepo>();
            services.AddScoped<IConnectionManager, ConnectionManager>();
        }
    }
}