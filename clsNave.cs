using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace pryPonceDeLeonMartina
{
    internal class clsNave
    {
        // Propiedades
        public int Vida { get; set; }
        public int Score { get; private set; }
        public string Nombre { get; private set; }    
        public PictureBox ImgNave { get; private set; }
        public PictureBox ImgBala { get; private set; }

        private List<PictureBox> balas = new List<PictureBox>();

        private Random aleatorioEnemigo = new Random();
        public int PosX { get; set; }  // Propiedad para la posición X
        public int PosY { get; set; }  // Propiedad para la posición Y

        public event EventHandler VidaCambiada; // Evento para notificar cambios en la vida
        public event EventHandler BalaColisionEnemigo; // Evento para notificar colisión bala-enemigo
        public event EventHandler ScoreCambiado;
        public event EventHandler jugadorColisionado;

        //metods
        public void CrearJugador()
        {
            Vida = 100;
            Nombre = "Jugador";           
            Score = 0;
            

            ImgNave = new PictureBox();
            ImgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            // ImgNave.Image = Properties.Resources.Nave; 
            ImgNave.ImageLocation = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQgByBT5IiAT_a2x9pUVb4VMoOrlzHH7Jrzj-HB5jzHlR4lNLMS";
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
            int velocidadBala = 20; // Velocidad de la bala (píxeles por movimiento)
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

        public void MoverJefe(int deltaX)
        {
            // Movimiento del jefe de lado a lado
            int nuevaX = PosX + deltaX;

            // Limitar el movimiento dentro de los límites del formulario
            if (nuevaX >= 0 && nuevaX + ImgNave.Width <= ImgNave.Parent.Width)
            {
                PosX = nuevaX;
                ImgNave.Location = new Point(PosX, PosY);
            }
        }

        public void DispararBalaJefe()
        {
            PictureBox nuevaBala = new PictureBox();
            nuevaBala.SizeMode = PictureBoxSizeMode.StretchImage;          
            nuevaBala.ImageLocation = "https://w7.pngwing.com/pngs/107/369/png-transparent-bank-cash-coin-dollar-money-payment-money-related-icon.png"; 
            nuevaBala.Size = new Size(10, 20); // Tamaño de la bala

            // Posición de la nueva bala (disparo hacia abajo desde el jefe)
            nuevaBala.Location = new Point(PosX + ImgNave.Width / 2 - nuevaBala.Width / 2, PosY + ImgNave.Height);

            Form formulario = ImgNave.FindForm();
            formulario.Controls.Add(nuevaBala);
            balas.Add(nuevaBala); // Agregar la nueva bala a la lista de balas del jefe
        }

        public void MoverBalaJefe(List<PictureBox> jugadores)
        {
            int velocidadBalaJefe = 10; // Velocidad de la bala del jefe (píxeles por movimiento)
            List<PictureBox> balasEliminadas = new List<PictureBox>(); // Lista auxiliar para balas eliminadas

            // Crear una copia de la lista de balas del jefe para evitar modificaciones durante la iteración
            List<PictureBox> copiaBalasJefe = new List<PictureBox>(balas);

            foreach (PictureBox bala in copiaBalasJefe)
            {
                if (bala != null && bala.Visible)
                {
                    bala.Top += velocidadBalaJefe; // Mover la bala del jefe hacia abajo

                    if (bala.Top > ImgNave.Parent.Height)
                    {
                        bala.Dispose(); // Eliminar la bala si sale de la pantalla
                        balasEliminadas.Add(bala); // Agregar a la lista de eliminados
                        continue; // Pasar a la siguiente iteración del bucle
                    }

                    foreach (PictureBox jugador in jugadores)
                    {
                        if (jugador != null && bala.Bounds.IntersectsWith(jugador.Bounds))
                        {
                            // Colisión de la bala del jefe con la nave del jugador
                            jugadorColisionado?.Invoke(this, EventArgs.Empty);
                            bala.Dispose(); // Eliminar la bala al colisionar
                            balasEliminadas.Add(bala); // Agregar a la lista de eliminados
                            break; // Salir del bucle al eliminar la bala
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
    




