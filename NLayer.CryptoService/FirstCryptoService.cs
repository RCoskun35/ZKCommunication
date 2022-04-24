using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.CryptoService
{
    public class FirstCryptoService
    {
        static RegistryKey BaseFolderPath = Registry.CurrentUser;
        static string subFolderParth = "ZKCommunication";
        static string KeyName = "ConnString";


        public static void Registry_Write()
        {
            //RegistryKey RegKey = BaseFolderPath;
            //RegistryKey subKey = RegKey.CreateSubKey(subFolderParth);
            //var key = "b14ca5898a4e4133aaxe2ea2315a1916";
            //var connString = "";
            //var encryptedString = cryptoService.EncryptString(key, connString);
            //subKey.SetValue(KeyName, encryptedString);
        }

        public static string Registry_Read()
        {
            RegistryKey RegKey = BaseFolderPath;
            RegistryKey subKey = RegKey.OpenSubKey(subFolderParth);
            var key = "b14ca5898a4e4133aaxe2ea2315a1916";
            var a = subKey.GetValue(KeyName).ToString();
            return cryptoService.DecryptString(key, a);
        }

        public static class cryptoService
        {
            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }

            public static string DecryptString(string key, string cipherText)
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

    }
}
