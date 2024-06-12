using Pertanyaan1;
using Pertanyaan2;

namespace HelpCenter
{
    public partial class HelpC : Form
    {
        public HelpC()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            One t = new One();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Two t = new Two();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }
    }
}
