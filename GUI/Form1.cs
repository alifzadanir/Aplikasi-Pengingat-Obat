using DataSeluruh;
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
            tambahObat tb = new tambahObat();
            this.Hide();
            tb.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Obat> obatList = Data.Instance.LoadObat();
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
            tambahjd t = new tambahjd();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (IsRowSelected(dataGridView1))
            {
                // Ambil data obat yang dipilih
                Obat selectedObat = GetSelectedObat();

                // Muat data obat dari singleton Data
                List<Obat> obatList = Data.Instance.LoadObat();

                // Hapus data obat yang dipilih dari list
                RemoveSelectedObat(obatList, selectedObat);

                // Simpan kembali list ke file JSON
                Data.Instance.SaveObat(obatList);

                // Refresh DataGridView
                RefreshDataGridView(obatList);

                ShowMessage("Data obat berhasil dihapus!", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Pilih data obat yang ingin dihapus.");
            }
        }

        public bool IsRowSelected(DataGridView dataGridView)
        {
            return dataGridView.SelectedRows.Count > 0;
        }

        public Obat GetSelectedObat()
        {
            int selectedIndex = dataGridView1.SelectedRows[0].Index;
            return (Obat)dataGridView1.Rows[selectedIndex].DataBoundItem;
        }

        public void RemoveSelectedObat(List<Obat> obatList, Obat selectedObat)
        {
            obatList.RemoveAll(o => o.NamaObat == selectedObat.NamaObat && o.Satuan == selectedObat.Satuan && o.Jenis == selectedObat.Jenis);
        }

        public void RefreshDataGridView(List<Obat> obatList)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = obatList;
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
