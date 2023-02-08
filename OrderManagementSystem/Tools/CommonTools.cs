using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ADO.NET_Helper;
using System.Data.SqlClient;
using OrderManagementSystem.Entities;

namespace OrderManagementSystem.Tools
{
    internal class CommonTools
    {

        public static string GenerateRandomPassword(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        public static void SendEmail(string to, string subject, string body)
        {

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ordermanagemetsystem@gmail.com", "llcglgasuiyqqvkp");
                //password: l!br@ry!@#$%
                MailMessage message = new MailMessage();
                message.To.Add(to.Trim());
                message.From = new MailAddress("ordermanagemetsystem@gmail.com");
                message.Subject = subject.Trim();
                message.Body = body.Trim();

                client.Send(message);
            }

        }


        public static void LogException(Exception exception, int Id)
        {

            string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string newDirectory = Path.Combine(currentDirectory, "Logs");
            Directory.CreateDirectory(newDirectory + "\\Logs");
            StreamWriter streamWriter = new StreamWriter(newDirectory + "\\Logs\\Logs.txt", append: true);


            User user = new();
            SqlHelper sqlHelper = new();
            SqlDataReader sqlDataReader = sqlHelper.ExecuteReader(query: $"select Id, name from Users where Id={Id}", connection: out SqlConnection connection);
            if (sqlDataReader.Read())
            {
                user.Name = Convert.ToString(sqlDataReader["Name"]);
            }


            string seperator = new string('-', 150);
            streamWriter.Write($"{Environment.NewLine}User:{user.Name}{Environment.NewLine}Time:{DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss")}{Environment.NewLine}{seperator}{Environment.NewLine}{exception.ToString()}{Environment.NewLine}{seperator}{Environment.NewLine}{Environment.NewLine}");
            streamWriter.Close();

        }




    }
}
