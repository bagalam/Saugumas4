using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password
{
    public class AESFileEncryptor
    {
        public static void Cipher()
        {         
            using (RijndaelManaged AES = new RijndaelManaged())              
            {
                    string password = "password";

                string fileEncrypted = FileInfo.filePath + FileInfo.fileName;
                        byte[] bytesToBeEncrypted = File.ReadAllBytes(FileInfo.filePath + FileInfo.fileName);
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        passwordBytes = MD5.Create().ComputeHash(passwordBytes);

                        try
                        {
                            byte[] bytesEncrypted = AESEncrypt(bytesToBeEncrypted, passwordBytes);

                            File.WriteAllBytes(fileEncrypted, bytesEncrypted);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error: " + exc.Message);
                        }
            }

                //using (StreamWriter writer = new StreamWriter(@"C:\Users\bagal\Desktop\hash.txt"))
                //{
                //    foreach (FileInfo file in files)
                //    {

                //        string hash = MD5Hasher(file);

                //        writer.WriteLine(hash);
                //    }
                //}
        }

        public static void Decipher()
        {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    string password = "password";
                    string fileDecrypted = FileInfo.filePath + FileInfo.fileName;
                    byte[] bytesToBeDecrypted = File.ReadAllBytes(FileInfo.filePath + FileInfo.fileName);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    passwordBytes = MD5.Create().ComputeHash(passwordBytes);


                    try
                    {
                        byte[] bytesDecrypted = AESDecrypt(bytesToBeDecrypted, passwordBytes);
                        var fileName = Path.GetFileNameWithoutExtension(FileInfo.filePath + FileInfo.fileName);
                        File.WriteAllBytes(fileDecrypted, bytesDecrypted);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error: " + exc.Message);
                    }
                }
        }

        //private static string MD5Hasher(FileInfo file)
        //{
        //    using (MD5 md5 = MD5.Create())
        //    {
        //        byte[] inputBytes;
        //        byte[] hashBytes;

        //        inputBytes = System.Text.Encoding.ASCII.GetBytes(file.FullName);
        //        hashBytes = md5.ComputeHash(inputBytes);
        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i < hashBytes.Length; i++)
        //        {
        //            sb.Append(hashBytes[i].ToString("X2"));
        //        }
        //        return sb.ToString();
        //    }
        //}

        private static byte[] AESEncrypt(byte[] bytesToBeEncrypted, byte[] Key)
        {

            byte[] encryptedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.Key = Key;
                    AES.Padding = PaddingMode.PKCS7;
                    try
                    {
                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(AES.Key, AES.Key), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }
                        encryptedBytes = ms.ToArray();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error: " + exc.Message);
                    }
                }
            }
            return encryptedBytes;
        }

        private static byte[] AESDecrypt(byte[] bytesToBeDecrypted, byte[] Key)
        {
            byte[] decryptedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.Key = Key;
                    AES.Padding = PaddingMode.PKCS7;

                    try
                    {
                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(AES.Key, AES.Key), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error: " + exc.Message);
                    }
                }
            }
            return decryptedBytes;
        }
    }
}
