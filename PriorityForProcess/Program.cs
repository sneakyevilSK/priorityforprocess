using System;
using System.Windows.Forms;
using Microsoft.Win32;


/*
Credits: sneakyevil 
*/
namespace PriorityForProcess
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
