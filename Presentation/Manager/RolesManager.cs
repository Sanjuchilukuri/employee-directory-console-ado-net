using Presentation.Utils.Error;
using Presentation.Interfaces;
using Presentation.Utils.UserInputManagement;
using Application.Interfaces;

namespace Presentation.Manager
{
    public class RolesManager : IRolesMenu
    {
        private readonly IDepartmentsAndRolesServices _rolesServices;

        public RolesManager(IDepartmentsAndRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public void AddRole()
        {
            bool displayAddRole = true;
            while (displayAddRole)
            {
                Console.Write($"\n In which department You want to add the role:* \n");
                List<string> departments = _rolesServices.GetDepartments();
                printList(departments);
                Console.Write("\n>");
                int departmentIndex = InputReader.GetOption(departments.Count);

                Console.Write("\nEnter The Role You Want* \n>");
                string newRole = InputReader.GetName("Mandatory")!;
                if (_rolesServices.AddRole(newRole, departments[departmentIndex - 1]))
                {

                    Console.Write("\nEnter the description \n>");
                    string descriprion = InputReader.GetName("NotMandatory")!;

                    Console.Write("\nEnter the Location* \n>");
                    string location = InputReader.GetName("Mandatory")!;

                    Console.WriteLine($"{newRole} was Added!\n");
                }
                else
                {
                    ErrorMessage.OperationFailed();
                }

                Console.Write("\nDo you want to Add Another Role(Y/N) \n>");
                char addAnotherRole = InputReader.GetCharInput();
                if (addAnotherRole == 'N')
                {
                    displayAddRole = false;
                }
            }
        }

        private void printList(List<string> optionsList)
        {
            for (int i = 0; i < optionsList.Count; i++)
            {
                Console.Write($" {i + 1}) {optionsList[i]}\t");
            }
        }

        public void DisplayRoles()
        {
            bool displayFields = true;
            while (displayFields)
            {
                Console.WriteLine("\nWhich department roles you want: ");
                List<string> departments = _rolesServices.GetDepartments();
                departments.Add("All Roles");
                printList(departments);
                Console.Write("\n>");
                int departmentIndex = InputReader.GetOption(departments.Count);
                
                if (departments[departmentIndex - 1] == "All Roles")
                {
                    List<string> allroles = _rolesServices.GetAllRoles();
                    PrintRoles(allroles);
                }
                else
                {
                    List<string> departmentRoles = _rolesServices.GetDepartmentRoles(departments[departmentIndex - 1]);
                    PrintRoles(departmentRoles);
                }

                Console.Write("\nDo you want to EXIT(Y/N) \n>");
                char addAnotherRole = InputReader.GetCharInput();
                if (addAnotherRole == 'Y')
                {
                    displayFields = false;
                }
            }
        }


        private void PrintRoles(List<string> allRoles)
        {
            if (allRoles.Count > 0)
            {
                for (int _ = 0; _ < 22; _++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                for (int i = 0; i < allRoles.Count; i++)
                {
                    string value = allRoles[i];
                    if (value.Length > 14)
                    {
                        value = value.Substring(0, 11) + "...";
                    }
                    Console.WriteLine($"|  {i + 1}) {value,-15}|");
                    for (int _ = 0; _ < 22; _++) Console.Write("-");
                    Console.WriteLine();
                }
                // Interactions.wait();
            }
            else
            {
                ErrorMessage.DataNotAvailable();
            }
        }

    }
}