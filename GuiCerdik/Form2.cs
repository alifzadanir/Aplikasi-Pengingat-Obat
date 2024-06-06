using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiCerdik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.MouseClick += panel1_Clicked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void panel1_Clicked(object sender, MouseEventArgs e)
        {
            Form3 navigasi = new Form3();
            navigasi.Tag = this;
            navigasi.Show();
            Hide();
        }
    }
}
