using Presentation.Interfaces;
using Presentation.Utils.UserInputManagement;

namespace Presentation.Menus
{
    public class RolesMenu : IMenu
    {
        private readonly IRolesMenu _rolesMenuManager;

        public RolesMenu(IRolesMenu rolesManager)
        {
            _rolesMenuManager = rolesManager;
        }

        private List<string> _rolesMenuOptions = ["Add Role", "Display All Roles", "Back"];
        
        public void DisplayMenu()
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                Console.WriteLine("=================Roles Management=================");
                for (int index = 0; index < _rolesMenuOptions.Count; index++)
                {
                    Console.WriteLine($"{index + 1}) {_rolesMenuOptions[index]}");
                }
                Console.Write("> ");
                int selectedInput = InputReader.GetOption(_rolesMenuOptions.Count);

                switch (selectedInput)
                {
                    case 1:
                        _rolesMenuManager.AddRole();
                        break;
                    case 2:
                        _rolesMenuManager.DisplayRoles();
                        break;
                    case 3:
                        displayMenu = false;
                        break;
                }
            }
        }
    }
}