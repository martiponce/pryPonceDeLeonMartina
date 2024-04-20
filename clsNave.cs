using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pryPonceDeLeonMartina
{
    internal class clsNave
    {
        // Propiedades
        public int vida;
        public string nombre;
        public int puntosDaño;
        public PictureBox imgNave;
        public PictureBox imgBala; 
        Random aleatorioEnemigo = new Random();

        //psc nave
        public int PosX { get; set; }
        public int PosY { get; set; }

        public void crearJugador()
        {
            vida = 100;
            nombre = "jugador1";
            puntosDaño = 1;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQgByBT5IiAT_a2x9pUVb4VMoOrlzHH7Jrzj-HB5jzHlR4lNLMS";
        }

        // Método para mover la nave
        public void MoverNave(int deltaX, int deltaY)
        {
            PosX += deltaX;
            PosY += deltaY;
            imgNave.Location = new Point(PosX, PosY);
        }
        public PictureBox CrearEnemigo()
        {
            int codigoEnemigo = aleatorioEnemigo.Next(0, 3);
            PictureBox imgEnemigo = new PictureBox();
            imgEnemigo.SizeMode = PictureBoxSizeMode.StretchImage;

            switch (codigoEnemigo)
            {
                case 0:
                    vida = 25;
                    nombre = "enemigo1";
                    puntosDaño = 2;
                    imgEnemigo.ImageLocation = "https://www.abrafersrl.com.ar/wp-content/uploads/77426324-1.jpg";
                    break;

                case 1:
                    vida = 20;
                    nombre = "enemigo2";
                    puntosDaño = 2;
                    imgEnemigo.ImageLocation = "https://www.abrafersrl.com.ar/wp-content/uploads/77426324-1.jpg";
                    break;

                case 2:
                    vida = 20;
                    nombre = "enemigo3";
                    puntosDaño = 2;
                    imgEnemigo.ImageLocation = "https://www.abrafersrl.com.ar/wp-content/uploads/77426324-1.jpg";
                    break;
            }

            // Posicion del enemig
            imgEnemigo.Location = new Point(aleatorioEnemigo.Next(0, 700), aleatorioEnemigo.Next(0, 700));

            return imgEnemigo;
        }

        public void InicializarBala()
        {
            imgBala = new PictureBox();
            imgBala.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBala.ImageLocation = "https://static.vecteezy.com/system/resources/previews/029/284/186/original/bullet-bullet-bullet-icon-bullet-with-transparent-background-ai-generative-free-png.png";
            imgBala.Visible = false;
        }

        public void Disparar()
        {
            if (imgBala != null && !imgBala.Visible)
            {
                // EPosicion bala incial
                imgBala.Location = new Point(imgNave.Location.X + imgNave.Width / 2 - imgBala.Width / 2, imgNave.Location.Y);
                imgBala.Visible = true;
                imgBala.Parent = imgNave.Parent;
            }
        }

        public void MoverBala(List<Control> enemigos)
        {
            if (imgBala != null && imgBala.Visible)
            {
                // Mover bala arriba
                imgBala.Top -= 10; //velocidad

                // colision
                foreach (Control enemigo in enemigos)
                {
                    if (imgBala.Bounds.IntersectsWith(enemigo.Bounds))
                    {
                        
                        enemigos.Remove(enemigo); // Remueve el enemigo de la lista
                        enemigo.Dispose(); // Elimina el enemigo del formulario
                        imgBala.Visible = false; // Oculta la bala al impactar
                        break; // Sale del bucle 
                    }
                }

                // Verifica si la bala ha salido de la pantalla y la oculta
                if (imgBala.Top + imgBala.Height < 0)
                {
                    imgBala.Visible = false;
                }
            }
        }
    }
}


