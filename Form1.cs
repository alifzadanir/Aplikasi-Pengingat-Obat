namespace GuiTema
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, Action>themeAction;
        private Dictionary<string, Action> themes;

        public Form1()
        {
            InitializeComponent();
            InitializeThemes();
        }
        private void InitializeThemes()
        {
            themes = new Dictionary<string, Action>
            {
                { "Default", SetDefaultTheme },
                { "Dark", SetDarkTheme },
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
            if (!themeAction.ContainsKey(theme))
            {
                MessageBox.Show("Tema yang dipilih tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            themeAction[theme]();
        }
        private void SetDefaultTheme()
        {
            SetTheme(SystemColors.Control, SystemColors.ControlText);
        }

        private void SetDarkTheme()
        {
            SetTheme(Color.FromArgb(45, 45, 48), Color.White, Color.FromArgb(28, 28, 28));
        }
        private void SetTheme(Color backColor, Color foreColor, Color? controlBackColor = null)
        {
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is Button || control is Label)
                {
                    control.BackColor = controlBackColor ?? backColor;
                    control.ForeColor = foreColor;
                }
            }
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
    }
}