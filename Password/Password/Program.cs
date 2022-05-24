using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Password
{

    public enum CryptoOperation
    {
        ENCRYPT,
        DECRYPT
    };
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              if (File.Exists("C:\\Users\\bagal\\Desktop\\Password\\Password\\bin\\Debug\\text.txt")) Application.Run(new Form1());
              else Application.Run(new Register());
            //Application.Run(new Form1());
        }
    }
}
