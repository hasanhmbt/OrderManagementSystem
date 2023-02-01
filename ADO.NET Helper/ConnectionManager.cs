using System.Data.SqlClient;

using System.Configuration;


namespace ADO.NET_Helper
{
    public class ConnectionManager
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static string ConnectionString => _connectionString;


        public SqlConnection Openconnection()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }
    }
}