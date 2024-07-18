using System.Configuration;
using Infrastructure.Interfaces;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Repos
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly string ConnectionString;

        public ConnectionManager()
        {
            // ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            ConnectionString = Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString));
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}