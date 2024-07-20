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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pacient1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pacient1DataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.pacient1DataSet.Radiografii);
            // TODO: This line of code loads data into the 'pacient1DataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.pacient1DataSet.Pacienti);


        }

        private void pacientiBindingSource_PositionChanged(object sender, EventArgs e)
        {
            label1.Text = "Radiografii: ";
            foreach (DataRowView drv in radiografiiBindingSource.List)
            {
                string img = (string)drv["Imagine"];
                label1.Text += img;
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = Bitmap.FromFile("D:\\facultate\\MTP\\laborator4\\_IMG\\" + img);
                pictureBox.Width = 500;
                pictureBox.Height = 500;
                pictureBox.Tag = img;
                flowLayoutPanel2.Controls.Add(pictureBox);
                pictureBox.Click += PictureBox_Click;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            string img = (string)pic.Tag;
            pictureBox1.Image = Bitmap.FromFile("D:\\facultate\\MTP\\laborator4\\_IMG\\" + img);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            string CNP = (string)((DataRowView)pacientiBindingSource.Current)["CNP"];
            form.CNP = CNP;
            if(form.ShowDialog()==DialogResult.OK)
            {
                //ADAUGARE IN BAZA DE DATE
                radiografiiTableAdapter.Insert(CNP, form.Imagine, new DateTime(2020, 08, 10), "aaa", "bbb");
                tableAdapterManager.UpdateAll(pacient1DataSet);
                radiografiiTableAdapter.Fill(pacient1DataSet.Radiografii);
            }
        }
    }
}
