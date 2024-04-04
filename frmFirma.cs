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
        //Declaro el cmpo
        //Bitmap alamcena la imagen donde se realiza el dibujo
        private Bitmap firma;

        public frmFirma()
        {
            InitializeComponent();


            //ctor del formulario con el ancho y alto del control picFirma.
            firma = new Bitmap(picFirma.Width, picFirma.Height);
        }


        //Método que se activa cuando se mueve el mouse
        private void picFirma_MouseMove(object sender, MouseEventArgs e)
        {
            //aca digo que cuando el boton izq este apretado dibuje con color rosa en el pictureBox
            if (e.Button == MouseButtons.Left)
            {
                //graphic es el obj que uso para dibujar
                using (Graphics lapiz = Graphics.FromImage(firma))
                {
                    lapiz.FillEllipse(Brushes.DeepPink, e.X, e.Y, 5, 5);
                }

                //Asigno este Bitmap al Image del control picFirma, lo que actualiza la imagen que se muestra en el pictureBox
                picFirma.Image = firma;
            }
        }

        //Metodo para guardar cuando apreto el boton
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //cuadro de texto al ser exitoso
            MessageBox.Show("Firma guardada con éxito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            {
                //guarda el Bitmap firma como un archivo de imagen gracias al metodo Save
                firma.Save("Firma.png", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}