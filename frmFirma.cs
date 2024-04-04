using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPonceDeLeonMartina
{
    public partial class frmFirma : Form
    {
        private Bitmap firma;
        public frmFirma()
        {
            InitializeComponent();
        }

        private void picFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                using(Graphics lapiz = Graphics.FromImage(firma))
                {
                    lapiz.FillEllipse(Brushes.White, e.X, e.Y, 5, 5);
                }

                picFirma.Invalidate();

            }
        }

        private void frmFirma_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            firma.Save("Firma.png",System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void picFirma_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(firma, Point.Empty);
            }
            catch (Exception)
            {

                //throw;
            }
            
        }

        private void frmFirma_Load(object sender, EventArgs e)
        {
            firma = new Bitmap(picFirma);
        }
    }
}
