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
            try
            {
                // con el metodo datetime creo el nombre de archivo con la fecha y hora actual
                string nombreArchivo = DateTime.Now.ToString("yyyy.MM.dd.HH.mm") + ".png";
                //obtengo la rutade la carpeta "FIRMAS", con el metodo path comb que combina rutas
                string carpetaFirmas = Path.Combine(Application.StartupPath, "FIRMAS");
                //devuelve la ruta dond esta el .exe

                // ver si la carpeta on existe y hacerla
                if (!Directory.Exists(carpetaFirmas))
                {
                    Directory.CreateDirectory(carpetaFirmas);
                }

                // combino la ruta completa de la carpeta con el nombre de archivo
                string rutaCompleta = Path.Combine(carpetaFirmas, nombreArchivo);

                // GuarRdo el Bitmap en el archivo
                firma.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("Firma guardada con éxito en:\n" + rutaCompleta, "Guardado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la firma: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Creao un nuevo Bitmap del mismo tamaño que el PictureBox
            using (Graphics g = Graphics.FromImage(firma))
            {
                g.Clear(Color.Thistle);
            }
            // asigno el nuevo Bitmap al PictureBox para borrar la imagen
            picFirma.Image = firma;
        }
    }
}