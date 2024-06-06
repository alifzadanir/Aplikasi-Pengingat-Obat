namespace GuiCerdik
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            panel1 = new Panel();
            panel2 = new Panel();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(-7, 337);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 419);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Location = new Point(108, 369);
            panel2.Name = "panel2";
            panel2.Size = new Size(133, 35);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(36, 319);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Jenis Kelamin";
            textBox6.Size = new Size(283, 27);
            textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(36, 266);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Tanggal Lahir";
            textBox5.Size = new Size(283, 27);
            textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(36, 111);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Nama Lengkap";
            textBox4.Size = new Size(283, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(36, 163);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Email";
            textBox3.Size = new Size(283, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(36, 216);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(283, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 59);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Username";
            textBox1.Size = new Size(283, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(90, 186);
            label1.Name = "label1";
            label1.Size = new Size(160, 42);
            label1.TabIndex = 1;
            label1.Text = "Registrasi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Snow;
            label2.Location = new Point(71, 239);
            label2.Name = "label2";
            label2.Size = new Size(149, 21);
            label2.TabIndex = 2;
            label2.Text = "Sudah Punya Akun?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(215, 239);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 3;
            label3.Text = "Login";
            label3.Click += label3_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(342, 753);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form3";
            Text = "Form3";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}