using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;


namespace PriorityForProcess
{
    public partial class Form1 : Form
    {
        private int priority;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string extention = Path.GetExtension(textBox1.Text);
            if (comboBox1.SelectedIndex == 0)
                priority = 3;
            else if (comboBox1.SelectedIndex == 1)
                priority = 6;
            else if (comboBox1.SelectedIndex == 2)
                priority = 2;
            else if (comboBox1.SelectedIndex == 3)
                priority = 5;
            else if (comboBox1.SelectedIndex == 4)
                priority = 1;

            if (extention == ".exe")
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + textBox1.Text);
                key.Close();
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + textBox1.Text + @"\PerfOptions");
                key.SetValue("CpuPriorityClass", priority, RegistryValueKind.DWord);
                key.Close();
                MessageBox.Show("Priority was succesfully set for process: " + textBox1.Text);
            } else {
                MessageBox.Show("Your process don't contain .exe on end!");
            }
        }
    }
}
