using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace Password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);

            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            if (File.Exists("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt"))
            {
                using (StreamReader file = new StreamReader("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt"))
                {
                    int counter = 0;
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                       
                        using (var writer = File.AppendText("temp.txt"))
                        {

                            writer.WriteLine(AesOperation.DecryptString(key, ln));

                        }
                        counter++;
                    }
                }
               
                try
{
                    File.Copy("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", "C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt", true);
                    File.WriteAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);
                }
                    catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }



                }
            else
            {
                File.Create("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public class AesOperation
        {
            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
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
                    aes.Key = Encoding.UTF8.GetBytes(key);
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
    


    
        private void button3_Click(object sender, EventArgs e)
        {

            var key = "b14ca5898a4e4133bbce2ea2315a1916";
           
                using (StreamReader file = new StreamReader("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt"))
                {
                    int counter = 0;
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        using (var writer = File.AppendText("temp.txt"))
                        {

                            writer.WriteLine(AesOperation.EncryptString(key, ln));

                        }
                        counter++;
                    }
                }
               
                try
                {
                File.Copy("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", "C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt", true);
                File.WriteAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);
            }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }



           





            System.Windows.Forms.Application.ExitThread();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            using (var writer = File.AppendText("text.txt"))
            {

                string ss = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
                writer.WriteLine(ss);
                MessageBox.Show("Sekmingai uzsiregistravote");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var oldLines = System.IO.File.ReadAllLines("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt");
            var newLines = oldLines.Where(line => !line.Contains(textBox5.Text));
            System.IO.File.WriteAllLines("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt", newLines);
            MessageBox.Show("Ištrynėte paskyrą");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt");
            IEnumerable<string> selectLines = lines.Where(line => line.StartsWith(textBox6.Text));
            foreach (var item in selectLines)
            {
                MessageBox.Show(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String strFile = File.ReadAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt");
            strFile = strFile.Replace(textBox8.Text, textBox7.Text);
            File.WriteAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt", strFile);
            MessageBox.Show("Slaptazodis pakeistas");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
