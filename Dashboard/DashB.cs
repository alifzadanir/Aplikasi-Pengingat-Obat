using DataSeluruh;
using GUI;
using HelpCenter;
using System.Data;
namespace Dashboard
{
    public partial class DashB : Form
    {
        public DashB()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Memuat data jadwal dari sumber data
                List<Jadwal> daftarJadwal = Data.Instance.LoadJadwal();
                dataGridView1.DataSource = daftarJadwal;
            }
            catch (DataException ex)
            {
                // Log kesalahan terkait data
                LogError(ex);
                MessageBox.Show("Gagal memuat data jadwal. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Log kesalahan umum
                LogError(ex);
                MessageBox.Show("Terjadi kesalahan. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogError(Exception ex)
        {
            throw new NotImplementedException();
        }

        private void LogError(DataException ex)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tambahjd t = new tambahjd();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 tb = new Form1();
            Hide();
            tb.ShowDialog();
            Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HelpC t = new HelpC();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }
    }
}
