namespace Infrastructure.Interfaces
{
    public interface IDepartmentsAndRolesRepo 
    {
        public bool AddRole(string newRole, string department);

        public List<string> GetDepartments();

        public List<string> GetAllRoles();

        public List<string> GetDeparmentRoles(string department);
        int GetJobId(string department, string role);
    }
}