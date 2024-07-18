using Microsoft.Extensions.DependencyInjection;
using Presentation.Enums;
using Presentation.Interfaces;
using Presentation.Utils.UserInputManagement;

namespace Presentation.Menus
{
    public class MainMenu : IMenu
    {
        private readonly IMenu _employeeMenu ;

        private readonly IMenu _rolesMenu ;

        public MainMenu( [FromKeyedServices(MenuType.EmployeeMenu)] IMenu employeeMenu, [FromKeyedServices(MenuType.RolesMenu)] IMenu rolesMenu)
        {
            _employeeMenu = employeeMenu;
            _rolesMenu = rolesMenu;
        }

        private List<string> _mainMenuOptions = ["Employee Management","Roles Management","Exit"];

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("==============MainMenu=================");
                for( int index = 0; index < _mainMenuOptions.Count; index++)
                {
                    Console.WriteLine($"{index+1}) {_mainMenuOptions[index]}");
                }
                Console.Write("> ");
                int selectedInput = InputReader.GetOption(_mainMenuOptions.Count);

                switch (selectedInput)
                {
                    case 1:
                        _employeeMenu.DisplayMenu();
                        break;
                    case 2:
                        _rolesMenu.DisplayMenu();
                        break;
                    case 3:
                        // Interactions.Exit();
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}