﻿namespace pryPonceDeLeonMartina
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
            txtScore = new TextBox();
            SuspendLayout();
            // 
            // txtScore
            // 
            txtScore.BackColor = Color.Black;
            txtScore.BorderStyle = BorderStyle.None;
            txtScore.Enabled = false;
            txtScore.Font = new Font("Copperplate Gothic Light", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtScore.ForeColor = SystemColors.InactiveBorder;
            txtScore.Location = new Point(-2, 876);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(198, 22);
            txtScore.TabIndex = 0;
            txtScore.Text = "Score: ";
            // 
            // frmJuego
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(600, 900);
            Controls.Add(txtScore);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Juego";
            Load += frmJuego_Load;
            KeyDown += frmJuego_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtScore;
    }
}