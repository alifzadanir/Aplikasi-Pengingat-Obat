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
    public partial class tambah : Form
    {
        public tambah()
        {
            InitializeComponent();

            // Event handler untuk load form
            this.Load += new System.EventHandler(this.tambah_Load);

            // Event handler untuk comboBox1
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1 (sebelumnya Form2)
            tambahjd f = new tambahjd();

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

        private void tambah_Load(object sender, EventArgs e)
        {
            // Muat data obat dari file JSON
            List<Obat> obatList = Data.LoadObat();

            // Isi ComboBox dengan nama obat
            comboBox1.Items.Clear();
            foreach (var obat in obatList)
            {
                comboBox1.Items.Add(obat.NamaObat);
            }

            // Opsional: Anda dapat memilih item pertama secara default
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Dapatkan nama penyakit dari TextBox
            string namaPenyakit = textBox1.Text;

            // Pastikan ada teks yang diisi di TextBox
            if (string.IsNullOrWhiteSpace(namaPenyakit))
            {
                MessageBox.Show("Silakan masukkan nama penyakit.");
                return;
            }

            // Dapatkan nama obat yang dipilih dari ComboBox
            string namaObat = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(namaObat))
            {
                MessageBox.Show("Silakan pilih obat dari ComboBox.");
                return;
            }

            // Dapatkan frekuensi dari ComboBox
            string frekuensi = comboBox2.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(frekuensi))
            {
                MessageBox.Show("Silakan pilih frekuensi dari ComboBox.");
                return;
            }

            // Dapatkan waktu konsumsi dari ComboBox
            string waktuKonsumsi = comboBox3.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(waktuKonsumsi))
            {
                MessageBox.Show("Silakan pilih waktu konsumsi dari ComboBox.");
                return;
            }

            // Dapatkan jumlah obat dari NumericUpDown
            int jumlahObat = (int)numericUpDown1.Value;

            // Buat objek Jadwal
            Jadwal jadwal = new Jadwal
            {
                NamaPenyakit = namaPenyakit,
                NamaObat = namaObat,
                Frekuensi = frekuensi,
                JumlahObat = jumlahObat,
                WaktuKonsumsi = waktuKonsumsi
            };

            // Muat data jadwal dari file JSON
            List<Jadwal> jadwalList = Data.LoadJadwal();

            // Tambahkan jadwal baru ke dalam daftar
            jadwalList.Add(jadwal);

            // Simpan kembali daftar jadwal ke dalam file JSON
            Data.SaveJadwal(jadwalList);

            MessageBox.Show("Data Jadwal berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Buat instance Tambah1 (sebelumnya Form2)
            tambahjd f = new tambahjd();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            f.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

