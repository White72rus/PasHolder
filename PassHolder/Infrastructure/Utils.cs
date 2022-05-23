using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassHolder.Infrastructure
{
    internal class Utils
    {
        internal static string GetHash(ref string data)
        {
            using (MD5 sha = MD5.Create())
            {
                byte[] temp = Encoding.UTF8.GetBytes(data);
                var has = sha.ComputeHash(temp, 0, temp.Length);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in has)
                    stringBuilder.Append(item.ToString("X2"));
                return stringBuilder.ToString();
            }
        }
    }
}
