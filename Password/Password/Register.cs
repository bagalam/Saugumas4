using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Password
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            FileInfo.fileName = textBox1.Text + ".txt";
            if (File.Exists(FileInfo.filePath + FileInfo.fileName))
            {
                AESFileEncryptor.Decipher();
                string[] lines = File.ReadAllLines(FileInfo.filePath + FileInfo.fileName);
                string decryptedPassword = AESTextEncryptor.DecryptString(key, lines[0]); 
                if(decryptedPassword == textBox2.Text)
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Neteisingas slaptazodis");
                    AESFileEncryptor.Cipher();
                }           
            }
            else
            {
                File.Create(FileInfo.filePath + FileInfo.fileName).Close();
                string encryptedPassword = AESTextEncryptor.EncryptString(key, textBox2.Text);
                using (var writer = File.AppendText(FileInfo.fileName))
                {
                    writer.WriteLine(encryptedPassword);
                }
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
                this.Close();
            }              
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                System.Windows.Forms.Application.ExitThread();
        }
    }
}
