using System.Data.SqlClient;
using System.Data;
using OrderManagementSystem.Entities;
using OrderManagementSystem.Tools;
using ADO.NET_Helper;
using OrderManagementSystem.Repositories.Abstracts;

namespace OrderManagementSystem.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User AuthenticateUser(string username, string password)
        {
            SqlHelper sqlHelper = new();

            User? user = new User();
            ConnectionManager connectionManager = new ConnectionManager();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Email", username),
                new SqlParameter("@Password", CryptographyManager.GetEncrypt(password))
            };

            SqlDataReader reader = sqlHelper.ExecuteReader(query: "SP_AuthenticateUser", connection: out SqlConnection connection, commandType: CommandType.StoredProcedure, parameters: parameters);

            if (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                user.ChangePassword = Convert.ToBoolean(reader["ChangePassword"]);

                connectionManager.CloseConnection(connection);
                return user;
            }
            else
                connectionManager.CloseConnection(connection);

            return null;


        }



        public User GetUserById(int id)
        {
            User? user = new User();
            SqlHelper sqlHelper = new SqlHelper();
            ConnectionManager connectionManager = new ConnectionManager();
            SqlDataReader reader = sqlHelper.ExecuteReader(query: $"select Id, Name, Email, IsAdmin from Users where Id={id}", connection: out SqlConnection connection);

            if (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                connectionManager.CloseConnection(connection);
                return user;
            }
            else
                connectionManager.CloseConnection(connection);

            return null;

        }


        public SqlDataReader GetAllUsers(out SqlConnection connection, string filter = "")
        {
            SqlHelper sqlHelper = new SqlHelper();

            SqlDataReader reader = sqlHelper.ExecuteReader(query: "select  Id, Name, Email, Password,IsAdmin,AddDate,Status  from Users ;", connection: out connection);
            return reader;
        }


        public void AddUsers(User user)
        {
            SqlHelper sqlHelper = new SqlHelper();

            List<SqlParameter> parameters = new List<SqlParameter>
            {

                new SqlParameter("@Name",user.Name),
                 new SqlParameter("@Email",user.Email),
                new SqlParameter($"@Password",CryptographyManager.GetEncrypt(user.Password)),
                new SqlParameter("@IsAdmin",user.IsAdmin),
            };

            sqlHelper.ExecuteNonQuery(query: $"insert into Users(Name,Email,Password,IsAdmin) values ( @Name, @Email, @Password, @IsAdmin)", parameters: parameters);
        }


        public void EditUser(User user)
        {
            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id",user.Id),
                new SqlParameter("@IsAdmin",user.IsAdmin),
                new SqlParameter("@Name",user.Name),
                 new SqlParameter("@Email",user.Email),
            };

            sqlHelper.ExecuteNonQuery(query: $"Update Users set  Name=@Name, Email=@Email, IsAdmin=@IsAdmin where Id=@Id", parameters: parameters);
        }

        public void DeleteUsers(List<int> userIds)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string deletedIdList = string.Join(",", userIds);

            sqlHelper.ExecuteNonQuery(query: $"Delete from Users where Id in ({deletedIdList})");
        }

        public void ChangePassword(int userId, string password, bool changePassword = true)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.ExecuteNonQuery(query: $"Update Users set ChangePassword={Convert.ToInt32(changePassword)}, Password='{password}' where Id={userId}");
        }

    }
}
