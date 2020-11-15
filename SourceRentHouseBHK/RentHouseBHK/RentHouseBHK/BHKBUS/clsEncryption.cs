using RentHouseBHK.BHKUtilities.BHKMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKBUS
{
    class clsEncryption
    {
        public static string CreateKey(string _Key)
        {
            StringBuilder builder = new StringBuilder();
            int length = _Key.Length;
            for (int i = 1; i <= length; i++)
            {
                int start = (_Key.Length - i);
                builder.Append(_Key.Substring(start, 1));
            }
            string str2 = builder.ToString();
            return builder.ToString();
        }

        public static string EncryptText(string _In)
        {
            try
            {
                string sKey = "";
                if (_In == "")
                {
                    return _In;
                }

                sKey = CreateKey("PASSWORD");


                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(_In);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
                return "";
            }
        }

        public static string DecryptText(string _Out)
        {
            try
            {
                if (_Out == "")
                {
                    return _Out;
                }
                string sKey = "";
                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                sKey = CreateKey("PASSWORD");
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(_Out);
                return System.Text.ASCIIEncoding.ASCII.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                clsMessages.ShowErrorException(ex);
                return "";
            }
        }

        public static string MD5Hash(string _Text)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(_Text));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
