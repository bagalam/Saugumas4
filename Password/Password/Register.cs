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
            
            using (var writer = File.AppendText("text.txt"))
            {

                string ss = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
                writer.WriteLine(ss);
                MessageBox.Show("Sekmingai uzsiregistravote, spauskite EXIT");

            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            File.Create("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt").Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new FileInfo("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt").Length == 0)
            {
                File.Delete("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt");
                System.Windows.Forms.Application.ExitThread();
            }
            else
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

                            writer.WriteLine(Form1.AesOperation.EncryptString(key, ln));

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
        }
    }
}
