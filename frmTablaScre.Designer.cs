namespace pryPonceDeLeonMartina
{
    partial class frmTablaScre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTablaScre));
            dgvTablaScore = new DataGridView();
            columNmbre = new DataGridViewTextBoxColumn();
            columScore = new DataGridViewTextBoxColumn();
            columTiempo = new DataGridViewTextBoxColumn();
            columFecha = new DataGridViewTextBoxColumn();
            lblTitulo = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTablaScore).BeginInit();
            SuspendLayout();
            // 
            // dgvTablaScore
            // 
            dgvTablaScore.AllowUserToAddRows = false;
            dgvTablaScore.AllowUserToDeleteRows = false;
            dgvTablaScore.BackgroundColor = Color.BlanchedAlmond;
            dgvTablaScore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablaScore.Columns.AddRange(new DataGridViewColumn[] { columNmbre, columScore, columTiempo, columFecha });
            dgvTablaScore.Location = new Point(12, 90);
            dgvTablaScore.Name = "dgvTablaScore";
            dgvTablaScore.ReadOnly = true;
            dgvTablaScore.RowTemplate.Height = 25;
            dgvTablaScore.Size = new Size(660, 515);
            dgvTablaScore.TabIndex = 0;
            // 
            // columNmbre
            // 
            columNmbre.Frozen = true;
            columNmbre.HeaderText = "Nombre Jugador";
            columNmbre.Name = "columNmbre";
            columNmbre.ReadOnly = true;
            columNmbre.Width = 150;
            // 
            // columScore
            // 
            columScore.Frozen = true;
            columScore.HeaderText = "Score";
            columScore.Name = "columScore";
            columScore.ReadOnly = true;
            // 
            // columTiempo
            // 
            columTiempo.Frozen = true;
            columTiempo.HeaderText = "Tiempo";
            columTiempo.Name = "columTiempo";
            columTiempo.ReadOnly = true;
            columTiempo.Width = 200;
            // 
            // columFecha
            // 
            columFecha.Frozen = true;
            columFecha.HeaderText = "Fecha";
            columFecha.Name = "columFecha";
            columFecha.ReadOnly = true;
            columFecha.Width = 150;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Gold;
            lblTitulo.Location = new Point(155, 36);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(338, 27);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "SCORE TODOS LOS JUGADORES";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.Info;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnVolver.ForeColor = SystemColors.ActiveCaptionText;
            btnVolver.Location = new Point(583, 626);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(89, 23);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmTablaScre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(684, 661);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dgvTablaScore);
            Name = "frmTablaScre";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tabla Score";
            ((System.ComponentModel.ISupportInitialize)dgvTablaScore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTablaScore;
        private DataGridViewTextBoxColumn columNmbre;
        private DataGridViewTextBoxColumn columScore;
        private DataGridViewTextBoxColumn columTiempo;
        private DataGridViewTextBoxColumn columFecha;
        private Label lblTitulo;
        private Button btnVolver;
    }
}