using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public static class SHA256Helper
    {
        public static string Encode(string input)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }

            return hash;
        }
    }
}
