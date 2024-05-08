using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace pryPonceDeLeonMartina
{
    internal class clsNave
    {
        // Propiedades
        public int Vida { get; set; }
        public int Score { get; private set; }
        public string Nombre { get; private set; }

        public PictureBox ImgNave;
        public PictureBox ImgBala { get; private set; }


        private Random aleatorioEnemigo = new Random();


        public event EventHandler VidaCambiada; // Evento para notificar cambios en la vida
        public event EventHandler BalaColisionEnemigo; // Evento para notificar colisión bala-enemigo
        public event EventHandler ScoreCambiado;

        //metods
        public void CrearJugador()
        {
            ImgNave = new PictureBox();


            Vida = 100;
            Nombre = "Jugador";           
            Score = 0;

            ImgNave.Image = Properties.Resources.enemigos;
            ImgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //ImgNave.ImageLocation = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQgByBT5IiAT_a2x9pUVb4VMoOrlzHH7Jrzj-HB5jzHlR4lNLMS";
        }

        public PictureBox CrearEnemigo()
        {
            PictureBox imgEnemigo = new PictureBox();
            imgEnemigo.SizeMode = PictureBoxSizeMode.StretchImage;


            int codigoEnemigo = aleatorioEnemigo.Next(0, 5);
            switch (codigoEnemigo)
            {
                case 0:
                    // imgEnemigo.Image = Properties.Resources.enemigos; 
                    imgEnemigo.ImageLocation = "https://http2.mlstatic.com/D_NQ_NP_991474-MLA54010614857_022023-O.webp";


                    break;
                case 1:
                    // imgEnemigo.Image = Properties.Resources.enemigos; 
                    imgEnemigo.ImageLocation = "https://http2.mlstatic.com/D_NQ_NP_991474-MLA54010614857_022023-O.webp";
                    break;
                case 2:
                    // imgEnemigo.Image = Properties.Resources.enemigos; 
                    imgEnemigo.ImageLocation = "https://http2.mlstatic.com/D_NQ_NP_991474-MLA54010614857_022023-O.webp";
                    break;
            }

            // Posición aleatoria para el enemigo
            int posX = aleatorioEnemigo.Next(0, 700);
            int posY = aleatorioEnemigo.Next(0, 700);
            imgEnemigo.Location = new Point(posX, posY);

            return imgEnemigo;
        }

        public PictureBox CrearJefe()
        {
            PictureBox imgJefe = new PictureBox();
            imgJefe.SizeMode = PictureBoxSizeMode.StretchImage;          
            imgJefe.ImageLocation = "https://images.aws.nestle.recipes/original/cbff956dfd5f633d0a1ffbea5681d2e9_canelones.jpg"; 

            // Establece las características del jefe
            Vida = 500; // Ejemplo de vida para el jefe
                        // Otras características específicas del jefe

            // Ubicación del jefe en el formulario
            int posX = aleatorioEnemigo.Next(0, 700);
            int posY = aleatorioEnemigo.Next(0, 200); // Ubica al jefe en la parte superior del formulario
            imgJefe.Location = new Point(posX, posY);

            // Retornar la imagen del jefe configurada
            return imgJefe;
        }

      


        public void ColisionEnemigo()
        {
            Vida -= 25; // Reducir la vida al colisionar con un enemigo
            VidaCambiada?.Invoke(this, EventArgs.Empty);

            // Decrementar la puntuación al colisionar con un enemigo
            Score -= 25;
            ScoreCambiado?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
    




