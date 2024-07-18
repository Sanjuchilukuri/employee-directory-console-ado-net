using System.Data.SqlClient;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly IConnectionManager _connectionManager;

        public EmployeeRepo(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public string GetEmployeeSequenceID()
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT TOP 1 EmpId FROM Employee ORDER BY EmpId DESC", sqlConnection);
                sqlConnection.Open();
                Object obj = sqlCommand.ExecuteScalar();
                string empID = obj == null ? "TZ1000" : (string)obj;
                return empID;
            }
        }

        public bool SaveEmployee(Employee newEmployee)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Employee VALUES(@EmpId, @FirstName, @LastName, @Email, @DOB, @JoiningDate, @PhoneNumber, @JobId, @Location, @Manager, @Project)", sqlConnection);   
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@EmpId", newEmployee.EmpId);
                sqlCommand.Parameters.AddWithValue("@FirstName", newEmployee.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", newEmployee.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", newEmployee.Email);
                sqlCommand.Parameters.AddWithValue("@DOB", newEmployee.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@JoiningDate", newEmployee.JoiningDate);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", newEmployee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@JobId", newEmployee.JobId);
                sqlCommand.Parameters.AddWithValue("@Location", newEmployee.Location);
                sqlCommand.Parameters.AddWithValue("@Manager", newEmployee.AssignManager);
                sqlCommand.Parameters.AddWithValue("@Project", newEmployee.Project);

                if (sqlCommand.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
        }

        public Employee GetEmployeeById(string id)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT emp.EmpId, emp.FirstName, emp.LastName, emp.DateofBirth, emp.PhoneNumber, emp.Email, emp.JoiningDate, d.DeptName, r.RoleName, emp.Location, emp.AssignedManager, emp.Project, j.JobId FROM Employee emp JOIN Jobs j ON emp.JobId = j.JobId JOIN Roles r ON r.RoleId = j.RoleId JOIN Dept d ON d.DeptId = r.DeptId WHERE emp.EmpId = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlConnection.Open();

                Employee emp = null!;

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        emp = new Employee()
                        {
                            EmpId = reader["EmpId"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = reader["DateofBirth"] != DBNull.Value ? ((DateTime)reader["DateofBirth"]).ToString("yyyy-MM-dd") : null,
                            PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                            Email = reader["Email"].ToString(),
                            JoiningDate = ((DateTime)reader["JoiningDate"]).ToString("yyyy-MM-dd"),
                            Department = reader["DeptName"].ToString(),
                            Role = reader["RoleName"].ToString(),
                            Location = reader["Location"].ToString(),
                            AssignManager = reader["AssignedManager"] != DBNull.Value ? reader["AssignedManager"].ToString() : null,
                            Project = reader["Project"] != DBNull.Value ? reader["Project"].ToString() : null,
                            JobId = Convert.ToInt32(reader["JobId"].ToString())
                        };
                    }
                };
                return emp;
            }
        }

        public bool deleteEmployee(string empId)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Employee WHERE EmpId = @empId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@empId", empId);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                List<Employee> allEmployees = new List<Employee>();
                SqlCommand sqlCommand = new SqlCommand($"SELECT emp.EmpId, emp.FirstName, emp.LastName, emp.JoiningDate, d.DeptName, r.RoleName, emp.Location, emp.AssignedManager, emp.Project FROM Employee emp JOIN Jobs j ON emp.JobId = j.JobId JOIN Roles r ON r.RoleId = j.RoleId JOIN dept d ON d.DeptId = r.DeptId; ", sqlConnection);
                sqlConnection.Open();
                
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmpId = reader["EmpId"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            JoiningDate = ((DateTime)reader["JoiningDate"]).ToString("yyyy-MM-dd"),
                            Department = reader["DeptName"].ToString(),
                            Role = reader["RoleName"].ToString(),
                            Location = reader["Location"].ToString(),
                            AssignManager = reader["AssignedManager"] != DBNull.Value ? reader["AssignedManager"].ToString() : null,
                            Project = reader["Project"] != DBNull.Value ? reader["Project"].ToString() : null
                        };
                        allEmployees.Add(emp);
                    };
                    return allEmployees;
                }
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand($"UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, DateofBirth = @DOB, PhoneNumber = @PhoneNumber, Email = @Email, JoiningDate = @JoiningDate, JobId = @JobId ,Location = @Location, AssignedManager = @Manager, Project = @Project Where EmpId = @EmpId ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@EmpId", employee.EmpId);
                sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@DOB", employee.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@JobId", employee.JobId);
                sqlCommand.Parameters.AddWithValue("@Location", employee.Location);
                sqlCommand.Parameters.AddWithValue("@Manager", employee.AssignManager);
                sqlCommand.Parameters.AddWithValue("@Project", employee.Project);
                sqlConnection.Open();
        
                if (sqlCommand.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}