using OrderManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Repositories.Abstracts
{
    internal interface IUserRepository
    {
        User AuthenticateUser(string username, string password);
        SqlDataReader GetAllUsers(out SqlConnection connection, string filter = "");
        User GetUserById(int id);
        void AddUsers(User user);
        void EditUser(User user);
        void DeleteUsers(List<int> userIds);
        void ChangePassword(int userId, string password, bool changePassword = true);
    }
}
