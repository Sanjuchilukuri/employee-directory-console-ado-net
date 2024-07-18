using Presentation.Interfaces;
using Presentation.Utils.UserInputManagement;

namespace Presentation.Menus
{
    public class EmployeeMenu : IMenu
    {
        private readonly IEmployeeMenu _employeeManager;

        public EmployeeMenu(IEmployeeMenu employeeManager)
        {
            _employeeManager = employeeManager;
        }

        private List<string> _employeeMenuOptions = ["Add Employee", "Edit Employee", "View Employee", "Delete Employee", "Display All Employees", "Back"];

        public void DisplayMenu()
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                Console.WriteLine("==============Employee Management=============");
                for (int index = 0; index < _employeeMenuOptions.Count; index++)
                {
                    Console.WriteLine($"{index + 1}) {_employeeMenuOptions[index]}");
                }
                Console.Write("> ");
                int selectedInput = InputReader.GetOption(_employeeMenuOptions.Count);

                switch (selectedInput)
                {
                    case 1:
                        _employeeManager.AddEmployee();
                        break;
                    case 2:
                        _employeeManager.EditEmployee();
                        break;
                    case 3:
                        _employeeManager.ViewEmployee();
                        break;
                    case 4:
                        _employeeManager.DeleteEmployee();
                        break;
                    case 5:
                        _employeeManager.DisplayEmployees();
                        break;
                    case 6:
                        displayMenu = false;
                        break;
                }
            }
        }
    }
}