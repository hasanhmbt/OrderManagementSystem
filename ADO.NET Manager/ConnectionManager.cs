using System.Data.SqlClient;

namespace ADO.NET_Manager
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