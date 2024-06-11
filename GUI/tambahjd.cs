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
            OpenTambahForm();
        }

        private void tambahjd_Load(object sender, EventArgs e)
        {
            LoadJadwalData();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (IsRowSelected(dataGridView1))
            {
                // Ambil data jadwal yang dipilih
                Jadwal selectedJadwal = GetSelectedJadwal();

                // Muat data jadwal dari singleton Data
                List<Jadwal> jadwalList = Data.Instance.LoadJadwal();

                // Hapus data jadwal yang dipilih dari list
                RemoveSelectedJadwal(jadwalList, selectedJadwal);

                // Simpan kembali list ke file JSON
                Data.Instance.SaveJadwal(jadwalList);

                // Refresh DataGridView
                RefreshDataGridView(jadwalList);

                ShowMessage("Data jadwal berhasil dihapus!", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Pilih data jadwal yang ingin dihapus.");
            }
        }

        public void LoadJadwalData()
        {
            List<Jadwal> jadwalList = Data.Instance.LoadJadwal();
            dataGridView1.DataSource = jadwalList;
        }

        public void OpenTambahForm()
        {
            tambah tb = new tambah();
            Hide();
            tb.ShowDialog();
            Show();
            LoadJadwalData();
        }

        public void OpenMainForm()
        {
            Form1 tb = new Form1();
            Hide();
            tb.ShowDialog();
            Show();
        }

        public bool IsRowSelected(DataGridView dataGridView)
        {
            return dataGridView.SelectedRows.Count > 0;
        }

        public Jadwal GetSelectedJadwal()
        {
            int selectedIndex = dataGridView1.SelectedRows[0].Index;
            return (Jadwal)dataGridView1.Rows[selectedIndex].DataBoundItem;
        }

        public void RemoveSelectedJadwal(List<Jadwal> jadwalList, Jadwal selectedJadwal)
        {
            jadwalList.RemoveAll(j => j.NamaPenyakit == selectedJadwal.NamaPenyakit &&
                                       j.NamaObat == selectedJadwal.NamaObat &&
                                       j.JumlahObat == selectedJadwal.JumlahObat &&
                                       j.Frekuensi == selectedJadwal.Frekuensi &&
                                       j.WaktuKonsumsi == selectedJadwal.WaktuKonsumsi);
        }

        public void RefreshDataGridView(List<Jadwal> jadwalList)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = jadwalList;
        }

        public void ShowMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(message, "Informasi", MessageBoxButtons.OK, icon);
        }

        public DataGridView DataGridView1
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
    }
}
