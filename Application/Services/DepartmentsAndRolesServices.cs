using Application.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class DepartmentsAndRolesServices : IDepartmentsAndRolesServices
    {
        private IDepartmentsAndRolesRepo _departmentsAndRolesRepo;

        public DepartmentsAndRolesServices(IDepartmentsAndRolesRepo departmentsAndRolesRepo)
        {
            _departmentsAndRolesRepo = departmentsAndRolesRepo;
        }

        public bool AddRole(string newRole, string department)
        {
            return _departmentsAndRolesRepo.AddRole(newRole, department);
        }

        public List<string> GetAllRoles()
        {
            return _departmentsAndRolesRepo.GetAllRoles();
        }

        public List<string> GetDepartments()
        {
            return _departmentsAndRolesRepo.GetDepartments();
        }

        public List<string> GetDepartmentRoles(string department)
        {
            return _departmentsAndRolesRepo.GetDeparmentRoles(department);
        }

        public int GetJobId(string department, string role)
        {
            return _departmentsAndRolesRepo.GetJobId(department, role);
        }
    }
}