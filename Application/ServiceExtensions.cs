using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IDepartmentsAndRolesServices, DepartmentsAndRolesServices>();
        }
    }
}