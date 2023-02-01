using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Tools
{
    internal class CryptographyManager
    {

        public static string GetSha256(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.Unicode.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);

                foreach (byte b in hash)
                {
                    stringBuilder.Append(b.ToString("X2"));
                }
            }
            return stringBuilder.ToString();
        }


        public static string GetMD5(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.Unicode.GetBytes(value);
                byte[] hash = md5.ComputeHash(bytes);

                foreach (byte b in hash)
                {
                    stringBuilder.Append(b.ToString("X2"));
                }
            }
            return stringBuilder.ToString();
        }
        public static string GetEncrypt(string code)
        {
            return GetSha256(GetMD5(code));
        }
    }
}
