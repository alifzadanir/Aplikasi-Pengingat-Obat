namespace GuiTema
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, Action> themes;
        public Form1()
        {
            InitializeComponent();
            themes = new Dictionary<string, Action>
            {
                { "Default", SetDefaultTheme },
                { "Gelap", SetDarkTheme },
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Silakan pilih tema terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedTheme = comboBox1.SelectedItem.ToString();
                ApplyTheme(selectedTheme);
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Terjadi kesalahan saat menerapkan tema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyTheme(string theme)
        {
            if (!themes.ContainsKey(theme))
            {
                MessageBox.Show("Tema yang dipilih tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            themes[theme]();
        }
        private void SetDefaultTheme()
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is Button || control is Label)
                {
                    control.BackColor = SystemColors.Window;
                    control.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void SetDarkTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is Button || control is Label)
                {
                    control.BackColor = Color.FromArgb(28, 28, 28);
                    control.ForeColor = Color.White;
                }
            }
        }
        private bool IsValidTheme(string theme)
        {
            string[] validThemes = { "Default", "Gelap" };
            return Array.Exists(validThemes, t => t.Equals(theme, StringComparison.OrdinalIgnoreCase));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LogError(Exception ex)
        {
            System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: {ex.Message}{Environment.NewLine}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}