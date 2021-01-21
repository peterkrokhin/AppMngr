using System;
using System.Security.Cryptography;
using System.Text;

namespace AppMngr.Application
{
    public class Utils
    {
        public static string GetHashOrEmpty(string str)
        {
            string hash = String.Empty;
            using (var sha256 = new SHA256Managed())
            {
                hash = BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
            }
            return hash;
        }

    }
}