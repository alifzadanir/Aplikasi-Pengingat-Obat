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
    public partial class Form4 : Form
    {
        PasienSingleton loginPasien = PasienSingleton.GetDataSingleton();
        public Form4()
        {
            InitializeComponent();
            panel2.MouseClick += panel2_Clicked;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 navigasiDaftar = new Form3();
            navigasiDaftar.Tag = this;
            navigasiDaftar.Show();
            Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Clicked(object sender, MouseEventArgs e)
        {
            try
            {

                if (loginPasien.SearchDataPasien(textBox1.Text, textBox2.Text))
                {
                    //Login ke halaman baru
                }
                else
                {
                    throw new Exception("Password atau Username salah!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
