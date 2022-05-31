using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password
{
    public partial class Form2 : Form
    {
        public string password { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string decryptedPassword = AESTextEncryptor.DecryptString(key, password);
            textBox3.Text = decryptedPassword;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = password;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
