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
    public partial class frmJuego : Form
    {
       
        //creo obj
        clsNave objNaveJugador;
        clsNave[] objEnemigos;
        Random rnd = new Random();

        // var global
        bool disparo = false;
        bool gameOver = false;
        public frmJuego()
        {
            InitializeComponent();
        }

        
        private void frmJuego_Load(object sender, EventArgs e)
        {
            // Instanciar el jugador (Nave)
            objNaveJugador = new clsNave();
            objNaveJugador.CrearJugador();
            objNaveJugador.imgNave.Location = new Point(350, 650);
            Controls.Add(objNaveJugador.imgNave);

            // Instanciar los enemigos
  
            //int numEnemigos = 5;
            //objEnemigos = new clsNave[numEnemigos];
            //for (int i = 0; i < numEnemigos; i++)
            //{
            //    objEnemigos[i] = new clsNave();
            //    objEnemigos[i].CrearEnemigo();
            //    int posX = rnd.Next(0, ClientSize.Width - objEnemigos[i].imgNave.Width);
            //    int posY = rnd.Next(0, ClientSize.Height / 2);
            //    objEnemigos[i].imgNave.Location = new Point(posX, posY);
            //    Controls.Add(objEnemigos[i].imgNave);
            //}
        }

        private void frmJuego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) {

                    objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X + 6,
                    objNaveJugador.imgNave.Location.Y);
            }
            if (e.KeyCode == Keys.Left)
            {

                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X - 6,
                    objNaveJugador.imgNave.Location.Y);
            }
            if (e.KeyCode == Keys.Up)
            {

                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X,
                    objNaveJugador.imgNave.Location.Y +6);
            }
            if (e.KeyCode == Keys.Down)
            {

                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X - 6,
                    objNaveJugador.imgNave.Location.Y);
            }

            //if (e.KeyCode == Keys.Space)
            //{
            //    disparo = true;
            //    disparar();
            //}
            //if (e.KeyCode == Keys.Enter && gameOver == true)
            //{
            //    limpiar();
            //    empezarJuego();
            //}
        }
        public void disparar()
        {

        }
        

        public void limpiar()
        {

        }
        public void empezarJuego()
        {
            //txtScore.Text = "Score: 0";
            //objNaveJugador.score = 0;
            //gameOver = false;
            //objNaveJugador.crearEnemigo();
            
        }

        private void frmJuego_Load_1(object sender, EventArgs e)
        {
            // Instanciar el jugador (Nave)
            objNaveJugador = new clsNave();
            objNaveJugador.CrearJugador();
            objNaveJugador.imgNave.Location = new Point(350, 650);
            Controls.Add(objNaveJugador.imgNave);

        }
    }
}
