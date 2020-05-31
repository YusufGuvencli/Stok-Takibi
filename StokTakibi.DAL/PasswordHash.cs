using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StokTakibi.DAL
{
    public sealed class PasswordHash
    {
        public string Hash(string inputText)
        {
           return EasyEncryption.MD5.ComputeMD5Hash(inputText);

        }
        public void Validate(string inputText)
        {
            var validateHash = EasyEncryption.MD5.IsValidMD5(inputText);
        }
    }
}
