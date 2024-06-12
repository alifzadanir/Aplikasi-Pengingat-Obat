using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Mendapatkan nilai dari radio button yang dipilih
            string jenisObat = "";

            if (radioButton3.Checked)
            {
                jenisObat = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                jenisObat = radioButton4.Text;
            }
            // Anda bisa menambahkan logika serupa untuk radio button lainnya

            // Memeriksa apakah pengguna telah memilih jenis obat
            if (string.IsNullOrEmpty(jenisObat))
            {
                MessageBox.Show("Pilih jenis obat terlebih dahulu!");
                return;
            }

            // Mendapatkan nilai dari textbox (nama obat)
            string namaObat = textBox1.Text;

            // Memeriksa apakah pengguna telah mengisi nama obat
            if (string.IsNullOrEmpty(namaObat))
            {
                MessageBox.Show("Masukkan nama obat terlebih dahulu!");
                return;
            }

            // Mendapatkan nilai dari combobox (satuan)
            string satuan = comboBox1.SelectedItem?.ToString();

            // Memeriksa apakah pengguna telah memilih satuan
            if (string.IsNullOrEmpty(satuan))
            {
                MessageBox.Show("Pilih satuan obat terlebih dahulu!");
                return;
            }

            // Buat objek Obat dengan nilai dari radio button dan textbox
            Obat obat = new Obat
            {
                NamaObat = namaObat,
                Jenis = jenisObat,
                Satuan = satuan
            };

            // Muat data obat yang sudah ada dari file JSON
            List<Obat> obatList = Data.LoadObat();

            // Tambahkan objek Obat baru ke dalam daftar yang sudah ada
            obatList.Add(obat);

            // Simpan kembali daftar Obat ke dalam file JSON
            Data.SaveObat(obatList);

            MessageBox.Show("Data obat berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Buat instance Tambah1 (sebelumnya Form2)
            Form1 f = new Form1();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            f.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1 (sebelumnya Form2)
            Form1 f = new Form1();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            f.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
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
    }
}
