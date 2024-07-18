using System.Data.SqlClient;

namespace Infrastructure.Interfaces
{
    public interface IConnectionManager
    {
        public  SqlConnection CreateConnection();

        // public void OpenConnection(SqlConnection sqlConnection);

        // public void CloseConnection(SqlConnection sqlConnection);
    }
}