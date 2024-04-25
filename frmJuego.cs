using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Timer = System.Windows.Forms.Timer;

namespace pryPonceDeLeonMartina
{
    public partial class frmJuego : Form
    {
        clsNave objNaveJugador;
        private List<PictureBox> enemigos = new List<PictureBox>();
        private Timer gameTimer = new Timer();
        private Random rnd = new Random();
        private int score = 0;


        public frmJuego()
        {
            InitializeComponent();
            gameTimer.Interval = 100; // Intervalo del temporizador en milisegundos
            gameTimer.Tick += GameLoop; // Evento que se ejecuta en cada tick del temporizador

            // Crear y configurar el jugador
            objNaveJugador = new clsNave();
            objNaveJugador.CrearJugador();
            objNaveJugador.PosX = 350;
            objNaveJugador.PosY = 650;
            objNaveJugador.ImgNave.Location = new Point(objNaveJugador.PosX, objNaveJugador.PosY);
            Controls.Add(objNaveJugador.ImgNave);

            // Suscribirse al evento BalaColisionEnemigo para actualizar el puntaje
            objNaveJugador.BalaColisionEnemigo += ActualizarScore;

            gameTimer.Start(); // Iniciar el temporizador


        }

        private void GameLoop(object sender, EventArgs e)
        {
            MoverEnemigos();
            objNaveJugador.MoverBala(enemigos); // Mover la bala de la nave y verificar colisiones
        }

        private void MoverEnemigos()
        {
            List<PictureBox> enemigosEliminados = new List<PictureBox>(); // Lista auxiliar para almacenar enemigos eliminados

            // Crear una copia de la lista de enemigos para evitar modificaciones durante la iteración
            List<PictureBox> copiaEnemigos = new List<PictureBox>(enemigos);

            foreach (PictureBox enemigo in copiaEnemigos)
            {
                enemigo.Top += 3; // Velocidad de movimiento de los enemigos

                // Verificar colisiones con la nave del jugador
                if (enemigo.Bounds.IntersectsWith(objNaveJugador.ImgNave.Bounds))
                {
                    enemigosEliminados.Add(enemigo); // Agregar enemigo a la lista de eliminados
                    gameOver();
                }

                // Verificar si el enemigo salió de la pantalla
                if (enemigo.Top > ClientSize.Height)
                {
                    enemigosEliminados.Add(enemigo); // Agregar enemigo a la lista de eliminados
                    score++; // Incrementar score al evitar un enemigo
                }
            }

            // Eliminar enemigos que deben ser removidos de la lista original
            foreach (PictureBox enemigoEliminado in enemigosEliminados)
            {
                enemigoEliminado.Dispose();
                enemigos.Remove(enemigoEliminado);
            }

            // Crear nuevos enemigos de forma aleatoria
            if (rnd.Next(0, 100) < 3) // Ajusta el número para controlar la frecuencia de creación de enemigos
            {
                PictureBox imgEnemigo = objNaveJugador.CrearEnemigo();
                int posX = rnd.Next(0, ClientSize.Width - imgEnemigo.Width);
                imgEnemigo.Location = new Point(posX, 0);
                Controls.Add(imgEnemigo);
                enemigos.Add(imgEnemigo);
            }
        }

        private void gameOver()
        {
            gameTimer.Stop(); // Detener el temporizador
            MessageBox.Show($"Game Over\nScore: {score}", "Juego Terminado");
            score = 0;
            enemigos.Clear();
            foreach (Control control in Controls)
            {
                if (control is PictureBox && control != objNaveJugador.ImgNave)
                {
                    control.Dispose();
                }
            }
            gameTimer.Start(); // Reiniciar el juego
        }

        private void frmJuego_Load_1(object sender, EventArgs e)
        {
           
            gameTimer.Start(); // Iniciar el temporizador
        }

        private void frmJuego_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Point posicionNave = objNaveJugador.ImgNave.Location;
                objNaveJugador.Disparar(posicionNave);
            }
            else if (e.KeyCode == Keys.Right)
            {
                objNaveJugador.MoverNave(6, 0); // Mover a la derecha
            }
            else if (e.KeyCode == Keys.Left)
            {
                objNaveJugador.MoverNave(-6, 0); // Mover a la izquierda
            }
            else if (e.KeyCode == Keys.Up)
            {
                objNaveJugador.MoverNave(0, -6); // Mover hacia arriba
            }
            else if (e.KeyCode == Keys.Down)
            {
                objNaveJugador.MoverNave(0, 6); // Mover hacia abajo
            }
        }

        private void ActualizarScore(object sender, EventArgs e)
        {
            score += 25; // Incrementar el puntaje
            txtScore.Text = score.ToString(); // Actualizar el texto del puntaje
        }
    }

}



