namespace pryPonceDeLeonMartina
{
    partial class frmInicioJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioJuego));
            btnComenzar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblTittle = new Label();
            btnVerScore = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnComenzar
            // 
            btnComenzar.BackColor = Color.Khaki;
            btnComenzar.FlatStyle = FlatStyle.Popup;
            btnComenzar.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnComenzar.Location = new Point(239, 292);
            btnComenzar.Name = "btnComenzar";
            btnComenzar.Size = new Size(200, 58);
            btnComenzar.TabIndex = 0;
            btnComenzar.Text = "¡Jugar!";
            btnComenzar.UseVisualStyleBackColor = false;
            btnComenzar.Click += btnComenzar_Click;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Info;
            txtNombre.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtNombre.Location = new Point(239, 427);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 33);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.Khaki;
            lblNombre.Location = new Point(239, 394);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 30);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Ingresa tu Nombre:";
            // 
            // lblTittle
            // 
            lblTittle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTittle.AutoSize = true;
            lblTittle.BackColor = Color.Transparent;
            lblTittle.Cursor = Cursors.PanNW;
            lblTittle.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblTittle.ForeColor = Color.Khaki;
            lblTittle.Location = new Point(173, 87);
            lblTittle.Name = "lblTittle";
            lblTittle.Size = new Size(352, 158);
            lblTittle.TabIndex = 3;
            lblTittle.Text = "GÁLAGA \r\nLOW COST";
            lblTittle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVerScore
            // 
            btnVerScore.BackColor = SystemColors.Info;
            btnVerScore.FlatStyle = FlatStyle.Popup;
            btnVerScore.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            btnVerScore.Location = new Point(21, 602);
            btnVerScore.Name = "btnVerScore";
            btnVerScore.Size = new Size(84, 48);
            btnVerScore.TabIndex = 4;
            btnVerScore.Text = "Ver Scores";
            btnVerScore.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.Info;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Showcard Gothic", 12F, FontStyle.Underline, GraphicsUnit.Point);
            btnSalir.Location = new Point(574, 602);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(84, 47);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmInicioJuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(684, 661);
            Controls.Add(btnSalir);
            Controls.Add(btnVerScore);
            Controls.Add(lblTittle);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(btnComenzar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmInicioJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gálaga Low Cost";
            Load += frmInicioJuego_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnComenzar;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblTittle;
        private Button btnVerScore;
        private Button btnSalir;
    }
}