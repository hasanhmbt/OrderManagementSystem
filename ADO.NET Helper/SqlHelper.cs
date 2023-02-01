using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ADO.NET_Helper
{

    public class SqlHelper
    {
        public SqlDataReader ExecuteReader(string query, out SqlConnection connection, CommandType commandType = CommandType.Text, List<SqlParameter> parameters = null)
        {
            ConnectionManager connectionManager = new ConnectionManager();
            connection = connectionManager.Openconnection();
            SqlDataReader reader;

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = commandType;

                if (parameters != null)
                    foreach (SqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);

                reader = command.ExecuteReader();
            }

            return reader;
        }

        public object ExecuteScalar(string query, CommandType commandType = CommandType.Text, List<SqlParameter> parameters = null)
        {
            ConnectionManager connectionManager = new ConnectionManager();
            object result;

            using (SqlConnection connection = connectionManager.Openconnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;

                    if (parameters != null)
                        foreach (SqlParameter parameter in parameters)
                            command.Parameters.Add(parameter);

                    result = command.ExecuteScalar();
                }
            }

            return result;
        }


        public void ExecuteNonQuery(string query, CommandType commandType = CommandType.Text, List<SqlParameter> parameters = null)
        {
            ConnectionManager connectionManager = new ConnectionManager();

            using (SqlConnection connection = connectionManager.Openconnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;

                    if (parameters != null)
                        foreach (SqlParameter parameter in parameters)
                            command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
