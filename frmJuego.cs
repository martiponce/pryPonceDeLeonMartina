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

namespace pryPonceDeLeonMartina
{
    public partial class frmJuego : Form
    {

        //creo obj
        clsNave objNaveJugador;
        private List<Control> enemigos = new List<Control>(); // Lista para almacenar los enemigos

        public frmJuego()
        {
            InitializeComponent();           

        }

        private void frmJuego_Load_1(object sender, EventArgs e)
        {
            objNaveJugador = new clsNave();
            objNaveJugador.crearJugador();
            objNaveJugador.PosX = 350;
            objNaveJugador.PosY = 650;
            objNaveJugador.imgNave.Location = new Point(objNaveJugador.PosX, objNaveJugador.PosY);
            Controls.Add(objNaveJugador.imgNave);

            // Crear enemigos aleatoriamente
            CrearEnemigosAleatorios(3);

            foreach (Control control in Controls)
            {
                if (control is PictureBox && control != objNaveJugador.imgNave)
                {
                    enemigos.Add(control);
                }
            }

            // Inicializar la bala de la nave
            objNaveJugador.InicializarBala();
        }
        private void CrearEnemigosAleatorios(int cantidad)
        {
            Random aleatorioEnemigo = new Random(); // generar enemigos aleatoriamente

            for (int i = 0; i < cantidad; i++)
            {
                PictureBox imgEnemigo = objNaveJugador.CrearEnemigo();

                // possion aleatorea dentro del form 
                int posX = aleatorioEnemigo.Next(0, ClientSize.Width - imgEnemigo.Width);
                int posY = aleatorioEnemigo.Next(0, 500);

                imgEnemigo.Location = new Point(posX, posY);
                Controls.Add(imgEnemigo);
            }

        }
        private void frmJuego_KeyDown_1(object sender, KeyEventArgs e)
        {

            int cantMovimientos = 6; // Cantidad de movimiento

            // Obtener la posición actual de la imagen
            int nuevaX = objNaveJugador.imgNave.Location.X;
            int nuevaY = objNaveJugador.imgNave.Location.Y;

            // Actualizar la posición según la tecla presionada
            if (e.KeyCode == Keys.Space)
            {
                objNaveJugador.Disparar();
            }
            if (e.KeyCode == Keys.Right)
            {
                nuevaX += cantMovimientos;
            }
            else if (e.KeyCode == Keys.Left)
            {
                nuevaX -= cantMovimientos;
            }
            else if (e.KeyCode == Keys.Up)
            {
                nuevaY -= cantMovimientos;
            }
            else if (e.KeyCode == Keys.Down)
            {
                nuevaY += cantMovimientos;
            }

            // Verificar si la nueva posición está dentro de los límites del formulario
            //ClientSize obtiene el tamaño del fotm
            if (nuevaX >= 0 && nuevaX + objNaveJugador.imgNave.Width <= ClientSize.Width &&
                nuevaY >= 0 && nuevaY + objNaveJugador.imgNave.Height <= ClientSize.Height)
            {
                objNaveJugador.imgNave.Location = new Point(nuevaX, nuevaY);
            }
            
        }
        private void UpdateGame()
        {
            // Mover la bala de la nave y verificar colisiones con los enemigos
            objNaveJugador.MoverBala(enemigos);
        }

        // Método para actualizar el juego en un bucle de juego 
        private void GameLoop()
        {
            // Actualizar el juego
        }
    }
}
   


