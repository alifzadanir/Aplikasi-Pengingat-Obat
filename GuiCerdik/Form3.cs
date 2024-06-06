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
    public partial class Form3 : Form
    {
        string[] spesialChar = { "!","@","#","$","%","^","&","*" };
        bool isContainedSpecial;
        PasienSingleton DataPasien = PasienSingleton.GetDataSingleton();

        public Form3()
        {
            InitializeComponent();
            panel2.MouseClick += panel2_Clicked;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Clicked(object sender, MouseEventArgs e)
        {
            try
            {
                if (textBox2.Text.Length < 8)
                {
                    throw new Exception("Password Minimal 8 Karakter");
                }

                for (int i = 0; i < spesialChar.Length; i++)
                {
                    if (textBox2.Text.Contains(spesialChar[i]))
                    {
                        isContainedSpecial = true;
                        break;
                    }
                }

                if (!isContainedSpecial)
                {
                    throw new Exception("Password harus mengandung karakter spesial");
                }

                DataPasien.AddDataPasien(new Pasien(textBox1.Text, textBox4.Text, textBox2.Text, textBox3.Text, textBox5.Text,textBox6.Text));

                Form4 navigasiLogin = new Form4();
                navigasiLogin.Tag = this;
                navigasiLogin.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form4 navigasiLogin = new Form4();
            navigasiLogin.Tag = this;
            navigasiLogin.Show();
            Hide();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
