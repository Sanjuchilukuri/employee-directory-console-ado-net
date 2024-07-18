using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IEmployeeServices 
    {
        public bool AddEmployee(Employee emp);

        public bool DeleteEmployee(string empId);

        public List<Employee> GetEmployees();

        public Employee GetEmployee(string id);

        bool UpdateEmployee(Employee employee);
    }
}
