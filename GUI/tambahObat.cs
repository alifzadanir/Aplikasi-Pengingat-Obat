using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataSeluruh;

namespace GUI
{
    public partial class tambahObat : Form
    {
        public tambahObat()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tambahObat_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string jenisObat = "";
                if (radioButton3.Checked)
                {
                    jenisObat = radioButton3.Text;
                }
                else if (radioButton4.Checked)
                {
                    jenisObat = radioButton4.Text;
                }

                if (string.IsNullOrEmpty(jenisObat))
                {
                    MessageBox.Show("Pilih jenis obat terlebih dahulu!");
                    return;
                }

                string namaObat = textBox1.Text;
                if (string.IsNullOrEmpty(namaObat))
                {
                    MessageBox.Show("Masukkan nama obat terlebih dahulu!");
                    return;
                }

                string satuan = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(satuan))
                {
                    MessageBox.Show("Pilih satuan obat terlebih dahulu!");
                    return;
                }

                Obat obat = new Obat
                {
                    NamaObat = namaObat,
                    Jenis = jenisObat,
                    Satuan = satuan
                };
                obat.Validate();

                List<Obat> obatList = Data.Instance.LoadObat();
                obatList.Add(obat);
                Data.Instance.SaveObat(obatList);

                MessageBox.Show("Data obat berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void OpenMainForm()
        {
            Form1 tb = new Form1();
            Hide();
            tb.ShowDialog();
            Show();
        }
    }
}
