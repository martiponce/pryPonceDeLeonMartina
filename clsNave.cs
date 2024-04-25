using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace pryPonceDeLeonMartina
{
    internal class clsNave
    {
        // Propiedades
        public int Vida { get; private set; }
        public string Nombre { get; private set; }
        public int PuntosDanio { get; private set; }
        public int Puntuacion { get; private set; }
        public PictureBox ImgNave { get; private set; }
        public PictureBox ImgBala { get; private set; }

        private List<PictureBox> balas = new List<PictureBox>();

        private Random aleatorioEnemigo = new Random();
        public int PosX { get; set; }  // Propiedad para la posición X
        public int PosY { get; set; }  // Propiedad para la posición Y

        public event EventHandler BalaColisionEnemigo; // Evento para notificar colisión bala-enemigo



        public void CrearJugador()
        {
            Vida = 100;
            Nombre = "Jugador";
            PuntosDanio = 25;
            Puntuacion = 0;

            ImgNave = new PictureBox();
            ImgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            // ImgNave.Image = Properties.Resources.Nave; 
            ImgNave.ImageLocation = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQgByBT5IiAT_a2x9pUVb4VMoOrlzHH7Jrzj-HB5jzHlR4lNLMS";
        }

        public void Disparar(Point posicion)
        {
            PictureBox nuevaBala = new PictureBox();
            nuevaBala.SizeMode = PictureBoxSizeMode.StretchImage;
            nuevaBala.ImageLocation = "https://w7.pngwing.com/pngs/107/369/png-transparent-bank-cash-coin-dollar-money-payment-money-related-icon.png";
            nuevaBala.Visible = true;
            nuevaBala.Size = new Size(10, 20); // Tamaño de la bala

            // Posición de la nueva bala
            nuevaBala.Location = new Point(posicion.X + ImgNave.Width / 2 - nuevaBala.Width / 2, posicion.Y);

            Form formulario = ImgNave.FindForm();
            formulario.Controls.Add(nuevaBala);

            balas.Add(nuevaBala); // Agregar la nueva bala a la lista de balas
        }

        public void MoverNave(int deltaX, int deltaY)
        {
            // Obtener la nueva posición propuesta
            int nuevaX = PosX + deltaX;
            int nuevaY = PosY + deltaY;

            // Limitar el movimiento hacia abajo (solo si se va a mover hacia abajo)
            if (deltaY > 0 && nuevaY + ImgNave.Height > ImgNave.Parent.Height)
            {
                nuevaY = ImgNave.Parent.Height - ImgNave.Height;
            }

            // Actualizar la posición solo si está dentro de los límites
            if (nuevaX >= 0 && nuevaX + ImgNave.Width <= ImgNave.Parent.Width &&
                nuevaY >= 0 && nuevaY + ImgNave.Height <= ImgNave.Parent.Height)
            {
                PosX = nuevaX;
                PosY = nuevaY;
                ImgNave.Location = new Point(PosX, PosY);
            }
        }



        public void MoverBala(List<PictureBox> enemigos)
        {
            int velocidadBala = 10; // Velocidad de la bala (píxeles por movimiento)
            List<PictureBox> balasEliminadas = new List<PictureBox>(); // Lista auxiliar para balas eliminadas

            // Crear una copia de la lista de balas para evitar modificaciones durante la iteración
            List<PictureBox> copiaBalas = new List<PictureBox>(balas);

            for (int i = copiaBalas.Count - 1; i >= 0; i--)
            {
                PictureBox bala = copiaBalas[i]; // Obtener la bala actual

                if (bala != null && bala.Visible)
                {
                    bala.Top -= velocidadBala; // Mover la bala hacia arriba

                    if (bala.Top + bala.Height < 0)
                    {
                        bala.Dispose(); // Eliminar la bala si sale de la pantalla
                        balasEliminadas.Add(bala); // Agregar a la lista de eliminados
                        continue; // Pasar a la siguiente iteración del bucle
                    }

                    foreach (PictureBox enemigo in enemigos)
                    {
                        if (enemigo != null && bala.Bounds.IntersectsWith(enemigo.Bounds))
                        {
                            enemigo.Visible = false; // Ocultar enemigo en lugar de eliminarlo
                            bala.Visible = false; // Ocultar la bala
                            balasEliminadas.Add(bala); // Agregar a la lista de eliminados
                            break; // Salir del bucle al eliminar un enemigo
                        }
                    }
                }
            }

            // Eliminar las balas que deben ser removidas de la lista original
            foreach (PictureBox balaEliminada in balasEliminadas)
            {
                balas.Remove(balaEliminada);
            }
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
    }
}
    




