using Microsoft.Extensions.DependencyInjection;
using Presentation.Menus;
using Presentation.Interfaces;
using Presentation.Manager;
using Presentation.Enums;
using Application;
using Infrastructure;

namespace Presentation
{
    public class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            IServiceCollection services = new ServiceCollection();
            
            // Presentation Layer classes added into service container
            services.AddKeyedScoped<IMenu, EmployeeMenu>(MenuType.EmployeeMenu);
            services.AddKeyedScoped<IMenu, RolesMenu>(MenuType.RolesMenu);
            services.AddKeyedScoped<IMenu, MainMenu>(MenuType.MainMenu);
            services.AddScoped<IRolesMenu, RolesManager>();
            services.AddScoped<IEmployeeMenu, EmployeeManager>();

            // Application Layer classes added into service container
            services.ConfigureApplication();

            // Infrastructure Layer classes added into service container
            services.ConfigureInfrastructure();

            var serviceProvider = services.BuildServiceProvider();

            var MainMenuObj = serviceProvider.GetRequiredKeyedService<IMenu>(MenuType.MainMenu);
            MainMenuObj.DisplayMenu();
        }
    }
}