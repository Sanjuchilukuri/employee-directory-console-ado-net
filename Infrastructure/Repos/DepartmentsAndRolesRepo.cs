using System.Data.SqlClient;
using Infrastructure.Interfaces;

namespace Infrastructure.Repos
{
    public class DepartmentsAndRolesRepo : IDepartmentsAndRolesRepo
    {
        private readonly IConnectionManager _connectionManager;

        public DepartmentsAndRolesRepo(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public bool AddRole(string newRole, string department)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand command = new SqlCommand("sp_Add_Role",sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Department", department);
                command.Parameters.AddWithValue("@Role", newRole);
                sqlConnection.Open();
                if (command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<string> GetDepartments()
        {
            List<string> keyList = new List<string>();
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT DeptName FROM Dept", sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        keyList.Add(reader["DeptName"].ToString()!);
                    }
                }
                return keyList;
            }
        }

        public List<string> GetAllRoles()
        {
            List<string> allRoles = new List<string>();

            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Distinct r.RoleName FROM Roles r JOIN dept d ON r.DeptId = d.DeptId", sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRoles.Add(reader["RoleName"].ToString()!);
                    }
                }
                return allRoles;
            }
        }

        public List<string> GetDeparmentRoles(string department)
        {
            List<string> allDeparmentRoles = new List<string>();
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT r.RoleName FROM Roles r JOIN dept d ON r.DeptId = d.DeptId WHERE d.DeptName = @Department", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Department", department);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allDeparmentRoles.Add(reader["RoleName"].ToString()!);
                    }
                }
                return allDeparmentRoles;
            }
        }

        public int GetJobId(string department, string role)
        {
            using (SqlConnection sqlConnection = _connectionManager.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT j.JobId FROM Jobs j JOIN Roles r ON r.RoleId = j.RoleId JOIN Dept d ON d.DeptId = r.DeptId WHERE d.DeptName = @Department AND r.RoleName=@Role", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Department", department);
                sqlCommand.Parameters.AddWithValue("@Role", role);

                sqlConnection.Open();
                int JobId = (int)sqlCommand.ExecuteScalar();

                return JobId;
            }

        }
    }
}