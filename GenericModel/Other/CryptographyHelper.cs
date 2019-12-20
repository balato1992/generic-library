using System;
using System.Security.Cryptography;
using System.Text;

namespace GenericModel.Other
{
    // 參考網站 http://no2don.blogspot.com/2013/03/c-android-aes-c.html
    public class CryptographyHelper
    {
        private static RijndaelManaged GetAES(string key, string iv)
        {

            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);

            // 32 * 8 = 256
            if (bKey.Length != 32)
            {
                throw new Exception("AES key bit length in bytes should be 256.");
            }

            // 16 * 8 = 128
            if (bIV.Length != 16)
            {
                throw new Exception("AES IV bit length in bytes should be 128.");
            }

            var aes = new RijndaelManaged();
            aes.Key = bKey;
            aes.IV = bIV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            return aes;
        }

        /// <summary>
        /// Encrypt with AES256
        /// </summary>
        /// <param name="source">本文</param>
        /// <param name="key">256 bits as key, i.g.: "12345678901234567890123456789012"</param>
        /// <param name="iv">128 bits as initialization vector, i.g.: "1234567890abcdef"</param>
        /// <returns></returns>
        public static string EncryptAES256(string source, string key, string iv)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            var aes = CryptographyHelper.GetAES(key, iv);

            ICryptoTransform transform = aes.CreateEncryptor();

            return Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));
        }

        /// <summary>
        /// Decrypt with AES256
        /// </summary>
        /// <param name="encryptData">Encrypt string in base64</param>
        /// <param name="key">256 bits as key, i.g.: "1234567890abcdef"</param>
        /// <param name="iv">128 bits as initialization vector</param>
        /// <returns></returns>
        public static string DecryptAES256(string encryptData, string key, string iv)
        {
            var encryptBytes = Convert.FromBase64String(encryptData);
            var aes = CryptographyHelper.GetAES(key, iv);

            ICryptoTransform transform = aes.CreateDecryptor();

            return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
