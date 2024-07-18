namespace Application.Interfaces
{
    public interface IDepartmentsAndRolesServices 
    {
        public bool AddRole(string newRole, string department);

        public List<string> GetAllRoles();

        public List<string> GetDepartments();

        public List<string> GetDepartmentRoles(string department);
        
        public int GetJobId(string department, string role);
    }
}
