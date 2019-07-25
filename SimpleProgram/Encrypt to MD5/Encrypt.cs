using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SimpleProgram.Encrypt_to_MD5
{
    class Encrypt
    {

        public String StringPassword(String password)
        {
            return EncryptPassword(password);
        }
        private static String EncryptPassword(String original)
        {
            byte[] encodedbytes;

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var originalBytes = Encoding.Default.GetBytes(original);
                encodedbytes = md5.ComputeHash(originalBytes);
            }
            return Convert.ToBase64String(encodedbytes);
        }
    }
}
