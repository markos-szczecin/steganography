using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Encryptor
    {
        //text to encrypt or already decrypted
        private String decryptedText = "";
        //text to decrypt or already encrypted
        private String encryptedText = "";
        private String key = "";

        public Encryptor setDecryptedText(String text)
        {
            decryptedText = text;

            return this;
        }

        public Encryptor setEncryptedText(String text)
        {
            encryptedText = text;

            return this;
        }
        public Encryptor setKey(String text)
        {
            key = text;

            return this;
        }

        Byte[] getHash(Byte[] hash)
        {
            Byte[] newHash = new Byte[32];
            for (int i = 0; i < 32; i++)
            {
                newHash[i] = hash[i];
            }

            return newHash;
        }

        Byte[] getIV(Byte[] hash)
        {
            Byte[] newHash = new Byte[16];
            int j = 0;
            for (int i = 32; i < 48; i++)
            {
                newHash[j++] = hash[i];
            }

            return newHash;
        }

        String EncryptAesManaged()
        {
            SHA512 shaM = new SHA512Managed();
            
            Byte[] data = Encoding.UTF8.GetBytes(key);
            Byte[] hash = shaM.ComputeHash(data);
            
            try
            {
                return Encrypt(decryptedText, getHash(hash), getIV(hash));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        String DecryptAesManaged()
        {
            SHA512 shaM = new SHA512Managed();
            var data = Encoding.UTF8.GetBytes(key);
            Byte[] hash = shaM.ComputeHash(data);
            try
            {
                return Decrypt(Convert.FromBase64String(encryptedText), getHash(hash), getIV(hash));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        static String Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            Byte[] encrypted;
            using (var aes = new RijndaelManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.BlockSize = 128;
                aes.KeySize = 256;
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    encrypted = ms.ToArray();
                }
                aes.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.BlockSize = 128;
                aes.KeySize = 256;
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                try
                {
                    using (MemoryStream ms = new MemoryStream(cipherText))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        plaintext = reader.ReadToEnd();
                    }
                        
                    aes.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return plaintext;
        }

        public String getEncrypted()
        {
             return EncryptAesManaged();
           
        }

        public String getDecrypted()
        {
             return DecryptAesManaged();

        }
    }
}
