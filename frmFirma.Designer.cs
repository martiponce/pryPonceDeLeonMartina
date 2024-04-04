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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFirma));
            picFirma = new PictureBox();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)picFirma).BeginInit();
            SuspendLayout();
            // 
            // picFirma
            // 
            picFirma.BackColor = Color.Thistle;
            picFirma.Location = new Point(12, 12);
            picFirma.Name = "picFirma";
            picFirma.Size = new Size(610, 558);
            picFirma.TabIndex = 0;
            picFirma.TabStop = false;
            picFirma.MouseMove += picFirma_MouseMove;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Thistle;
            btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 192);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardar.Location = new Point(547, 576);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // frmFirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(634, 611);
            Controls.Add(btnGuardar);
            Controls.Add(picFirma);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmFirma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dibujar Firma";
            ((System.ComponentModel.ISupportInitialize)picFirma).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picFirma;
        private Button btnGuardar;
    }
}