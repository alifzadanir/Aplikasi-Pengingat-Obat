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
    public partial class tambahjd : Form
    {
        public tambahjd()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1 (sebelumnya Form2)
            tambah tb = new tambah();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            tb.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
        }

        private void tambahjd_Load(object sender, EventArgs e)
        {
            List<Jadwal> jadwalList = Data.LoadJadwal();
            dataGridView1.DataSource = jadwalList;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1 (sebelumnya Form2)
            Form1 tb = new Form1();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            tb.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ambil indeks baris yang dipilih
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Ambil data jadwal dari DataGridView
                Jadwal selectedJadwal = (Jadwal)dataGridView1.Rows[selectedIndex].DataBoundItem;

                // Muat data jadwal dari file JSON
                List<Jadwal> jadwalList = Data.LoadJadwal();

                // Hapus data jadwal yang dipilih dari list
                jadwalList.RemoveAll(j => j.NamaPenyakit == selectedJadwal.NamaPenyakit &&
                                          j.NamaObat == selectedJadwal.NamaObat &&
                                          j.JumlahObat == selectedJadwal.JumlahObat &&
                                          j.Frekuensi == selectedJadwal.Frekuensi &&
                                          j.WaktuKonsumsi == selectedJadwal.WaktuKonsumsi);

                // Simpan kembali list ke file JSON
                Data.SaveJadwal(jadwalList);

                // Refresh DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = jadwalList;

                MessageBox.Show("Data jadwal berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pilih data jadwal yang ingin dihapus.");
            }
        }
    }
}
