namespace pryPonceDeLeonMartina
{
    partial class frmJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJuego));
            pgbScore = new ProgressBar();
            lblScore = new Label();
            pgbVida = new ProgressBar();
            lblVida = new Label();
            SuspendLayout();
            // 
            // pgbScore
            // 
            pgbScore.BackColor = SystemColors.ActiveCaptionText;
            pgbScore.ForeColor = Color.Tomato;
            pgbScore.Location = new Point(2, 5);
            pgbScore.Maximum = 250;
            pgbScore.Name = "pgbScore";
            pgbScore.Size = new Size(143, 23);
            pgbScore.TabIndex = 1;
            pgbScore.Value = 250;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.ForeColor = Color.Transparent;
            lblScore.Location = new Point(2, 30);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 17);
            lblScore.TabIndex = 2;
            lblScore.Text = "SCORE";
            // 
            // pgbVida
            // 
            pgbVida.BackColor = SystemColors.ActiveCaptionText;
            pgbVida.ForeColor = Color.Lime;
            pgbVida.Location = new Point(545, 5);
            pgbVida.Name = "pgbVida";
            pgbVida.Size = new Size(143, 23);
            pgbVida.TabIndex = 1;
            pgbVida.Value = 100;
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.BackColor = Color.Transparent;
            lblVida.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblVida.ForeColor = Color.Transparent;
            lblVida.Location = new Point(545, 30);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(40, 17);
            lblVida.TabIndex = 2;
            lblVida.Text = "VIDA";
            // 
            // frmJuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(700, 700);
            Controls.Add(lblVida);
            Controls.Add(lblScore);
            Controls.Add(pgbVida);
            Controls.Add(pgbScore);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "frmJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Juego";
            Load += frmJuego_Load_1;
            KeyDown += frmJuego_KeyDown_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pgbScore;
        private Label lblScore;
        private ProgressBar pgbVida;
        private Label lblVida;
    }
}