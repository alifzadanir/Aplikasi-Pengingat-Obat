namespace GuiCerdik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.MouseClick += panel2_Clicked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 navigasi = new Form2();
            navigasi.Tag = this;
            navigasi.Show();
            Hide();
        }

        private void panel2_Clicked(object sender, EventArgs e)
        {
            Form2 navigasi = new Form2();
            navigasi.Tag = this;
            navigasi.Show();
            Hide();
        }
    }
}
