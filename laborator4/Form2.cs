using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laborator4
{
    public partial class Form2 : Form
    {
        public string CNP{ get; set; }
        public string Imagine { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = CNP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "*.jpg |*.jpg";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                string[] lines = dialog.FileName.Split('\\');
                textBox2.Text = lines[lines.Length-1];
                Imagine = lines[lines.Length - 1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
