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
        public int Vida { get; set; }
        public string? Nombre { get; set; }
        public int PuntosDanho { get; set; }
        public int Score { get; set; }
        public PictureBox? imgNave { get; set; }
        private Random aleatorioEnemigo = new Random();

        public void CrearJugador()
        {
            Vida = 100;
            Nombre = "Jugador 1";
            PuntosDanho = 1;
            Score = 0;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = Path.Combine(Application.StartupPath, "img", "Nave.png");
        }

        public void CrearEnemigo()
        {
            int codigoEnemigo = aleatorioEnemigo.Next(0, 3);

            switch (codigoEnemigo)
            {
                case 0:
                    // No hacemos nada, podemos agregar más casos según necesitemos más tipos de enemigos
                    break;

                case 1:
                    // Enemigo tipo 1
                    Vida = 25;
                    Nombre = "Enemigo 1";
                    PuntosDanho = 2;
                    imgNave = new PictureBox();
                    imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgNave.ImageLocation = Path.Combine(Application.StartupPath, "img", "enemigos.png");
                    break;

                case 2:
                    // Enemigo tipo 2
                    Vida = 25;
                    Nombre = "Enemigo 2";
                    PuntosDanho = 2;
                    imgNave = new PictureBox();
                    imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgNave.ImageLocation = Path.Combine(Application.StartupPath, "img", "enemigos.png");
                    break;
            }
        }
    }
}
