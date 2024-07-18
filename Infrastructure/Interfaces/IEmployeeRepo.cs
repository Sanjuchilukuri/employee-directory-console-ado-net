using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepo 
    {
        public string GetEmployeeSequenceID();

        public Employee GetEmployeeById(string Id);

        public bool SaveEmployee(Employee newEmployee);

        public bool deleteEmployee(string empId);

        public List<Employee> GetAllEmployees();
        
        bool UpdateEmployee(Employee employee);
    }
}