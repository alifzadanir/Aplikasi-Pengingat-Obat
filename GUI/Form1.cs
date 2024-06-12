namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1 (sebelumnya Form2)
            tambahObat tb = new tambahObat();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            tb.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Muat data obat dari file JSON
            List<Obat> obatList = Data.LoadObat();

            // Tampilkan data di DataGridView
            dataGridView1.DataSource = obatList;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Buat instance Tambah1(sebelumnya Form2)
            tambahjd t = new tambahjd();

            // Sembunyikan Form1
            this.Hide();

            // Tampilkan Tambah1 (sebelumnya Form2)
            t.ShowDialog();

            // Tampilkan kembali Form1 jika Tambah1 (sebelumnya Form2) ditutup
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ambil indeks baris yang dipilih
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Ambil data obat dari DataGridView
                Obat selectedObat = (Obat)dataGridView1.Rows[selectedIndex].DataBoundItem;

                // Muat data obat dari file JSON
                List<Obat> obatList = Data.LoadObat();

                // Hapus data obat yang dipilih dari list
                obatList.RemoveAll(o => o.NamaObat == selectedObat.NamaObat && o.Satuan == selectedObat.Satuan && o.Jenis == selectedObat.Jenis);

                // Simpan kembali list ke file JSON
                Data.SaveObat(obatList);

                // Refresh DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = obatList;

                MessageBox.Show("Data obat berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pilih data obat yang ingin dihapus.");
            }
        }
    }
}
