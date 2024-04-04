namespace pryPonceDeLeonMartina
{
    partial class frmFirma
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
            picFirma = new PictureBox();
            btnGuardar = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picFirma).BeginInit();
            SuspendLayout();
            // 
            // picFirma
            // 
            picFirma.BackColor = SystemColors.ActiveCaptionText;
            picFirma.Location = new Point(12, 12);
            picFirma.Name = "picFirma";
            picFirma.Size = new Size(610, 558);
            picFirma.TabIndex = 0;
            picFirma.TabStop = false;
            picFirma.Paint += picFirma_Paint;
            picFirma.MouseMove += picFirma_MouseMove;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Plum;
            btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 192);
            btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.Location = new Point(547, 576);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 576);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmFirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 611);
            Controls.Add(button1);
            Controls.Add(btnGuardar);
            Controls.Add(picFirma);
            Name = "frmFirma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dibujar Firma";
            Load += frmFirma_Load;
            MouseMove += frmFirma_MouseMove;
            ((System.ComponentModel.ISupportInitialize)picFirma).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picFirma;
        private Button btnGuardar;
        private Button button1;
    }
}