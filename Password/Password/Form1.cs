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
//                using (StreamReader file = new StreamReader(FileInfo.filePath + FileInfo.fileName))
//                {
//                    int counter = 0;
//                    string ln;
//                    while ((ln = file.ReadLine()) != null)
//                    {
                       
//                        using (var writer = File.AppendText("temp.txt"))
//                        {

//                            //writer.WriteLine(AesOperation.DecryptString(key, ln));
//                            writer.WriteLine(ln);

//                        }
//                        counter++;
//                    }
//                }
               
//                try
//{
//                    File.Copy("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", FileInfo.filePath + FileInfo.fileName, true);
//                    //File.WriteAllText("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);
//                }
//                    catch (IOException ex)
//                {
//                    MessageBox.Show(ex.Message);
//                }
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            AESFileEncryptor.Cipher();

            System.Windows.Forms.Application.ExitThread();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string passwordEcrypted = AESTextEncryptor.EncryptString(key, textBox2.Text);

            using (var writer = File.AppendText(FileInfo.fileName))
            {

                string ss = textBox1.Text + " " + passwordEcrypted + " " + textBox3.Text + " " + textBox4.Text;
                writer.WriteLine(ss);
                MessageBox.Show("Sekmingai pridejote paskyra");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (string line in File.ReadAllLines(FileInfo.filePath + FileInfo.fileName))
            {
                if (line.Contains(textBox10.Text) && line.Contains(textBox5.Text))
                {
                    
                }
                else 
                {
                    using (var writer = File.AppendText(FileInfo.filePath + "temp.txt"))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            File.Copy(FileInfo.filePath + "temp.txt", FileInfo.filePath + FileInfo.fileName, true);
            File.WriteAllText(FileInfo.filePath + "temp.txt", String.Empty);
            MessageBox.Show("Slaptazodis istrintas");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            foreach (string line in File.ReadAllLines(FileInfo.filePath + FileInfo.fileName))
            {
                if (line.Contains(textBox6.Text) && line.Contains(textBox9.Text))
                {
                    string[] words = line.Split(' ');
                    f2.password = words[1];
                    f2.Show();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string newEncryptedPassword = AESTextEncryptor.EncryptString(key, textBox11.Text);
            foreach (string line in File.ReadAllLines(FileInfo.filePath + FileInfo.fileName))
            {
                if (line.Contains(textBox8.Text) && line.Contains(textBox7.Text))
                {
                    string[] words = line.Split(' ');

                    String strFile = File.ReadAllText(FileInfo.filePath + FileInfo.fileName);
                    strFile = strFile.Replace(words[1], newEncryptedPassword);
                    File.WriteAllText(FileInfo.filePath + FileInfo.fileName, strFile);
                    MessageBox.Show("Slaptazodis pakeistas");
                }
            }
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            int length = 9;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            textBox2.Text = res.ToString();
        }
    }
}
