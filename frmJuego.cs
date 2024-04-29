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
//using OfficeOpenXml; // Agregar este using para guardar en excel


namespace pryPonceDeLeonMartina
{
    public partial class frmJuego : Form
    {
        private clsNave objNaveJugador;
        private clsNave objJefe; // Objeto para el jefe
        private List<PictureBox> enemigos = new List<PictureBox>();
        private List<PictureBox> jugadores = new List<PictureBox>(); // Lista que incluye la nave del jugador y posiblemente otras naves de jugadores
        private Timer gameTimer = new Timer();
        private Random rnd = new Random();
        private int vida = 100; // Valor inicial de la vida del jugador
        private int score = 250; // Valor inicial del score
        private string nombreJugador;
        


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
           
            // Actualizar las barras de progreso al inicio del juego
            pgbVida.Value = vida;
            pgbScore.Value = score;

            objJefe = new clsNave();  // Inicializar el objeto objJefe
            objNaveJugador.jugadorColisionado += ObjNaveJugador_jugadorColisionado; // Suscribir al evento

            gameTimer.Start(); // Iniciar el temporizador

        }

        private void frmJuego_Load_1(object sender, EventArgs e)
        {

            gameTimer.Start(); // Iniciar el temporizador
        }
        public void SetNombreJugador(string nombre)
        {
            nombreJugador = nombre;
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
        private void GameLoop(object sender, EventArgs e)
        {
            // Lógica del juego
            MoverEnemigos();
            objNaveJugador.MoverBala(enemigos); // Mueve la bala del jugador y verifica colisiones
                                               // Verificar que objJefe no sea null antes de llamar a sus métodos
            if (objJefe != null)
            {
                objJefe.MoverBalaJefe(jugadores); // Mueve la bala del jefe y verifica colisiones
            }
        }
        private void gameOver()
        {
            // Guardar datos en Excel
            //GuardarDatosEnExcel(nombreJugador, score);

            gameTimer.Stop(); // Detener el temporizador
            MessageBox.Show($"Game Over {nombreJugador}\nScore: {score}\n¡Suerte la Próxima! ", "Juego Terminado");
            score = 250; // Restaurar el valor inicial del score
            vida = 100; // Restaurar el valor inicial de la vida
            pgbVida.Value = vida; // Actualizar la barra de progreso de la vida
            pgbScore.Value = score; // Actualizar la barra de progreso del score
            enemigos.Clear();
            foreach (Control control in Controls)
            {
                if (control is PictureBox && control != objNaveJugador.ImgNave)
                {
                    control.Dispose();
                }
            }
            this.Close();
            frmInicioJuego f = new frmInicioJuego();
            f.ShowDialog();

        }
        private void MoverEnemigos()
        {
            List<PictureBox> enemigosEliminados = new List<PictureBox>(); // Lista auxiliar para almacenar enemigos eliminados

            // Crear una copia de la lista de enemigos para evitar modificaciones durante la iteración
            List<PictureBox> copiaEnemigos = new List<PictureBox>(enemigos);

            foreach (PictureBox enemigo in copiaEnemigos)
            {
                enemigo.Top += 4; // Velocidad de movimiento de los enemigos

                // Verificar colisiones con la nave del jugador
                if (enemigo.Bounds.IntersectsWith(objNaveJugador.ImgNave.Bounds))
                {
                    // Verificar si ya se ha registrado una colisión con este enemigo
                    if (!enemigo.Tag?.Equals("colisionado") ?? true)
                    {
                        enemigo.Tag = "colisionado"; // Marcar el enemigo como colisionado para evitar repeticiones
                        enemigosEliminados.Add(enemigo); // Agregar enemigo a la lista de eliminados
                        RestarVida(); // Decrementar vida al colisionar con un enemigo
                    }
                }
                else
                {
                    // Si el enemigo ya no colisiona, quitar la marca de colisionado
                    enemigo.Tag = null;
                }

                // Verificar si el enemigo salió de la pantalla
                if (enemigo.Top > ClientSize.Height)
                {
                    enemigosEliminados.Add(enemigo); // Agregar enemigo a la lista de eliminados
                    SumarScore(); // Incrementar score al evitar un enemigo
                }
            }

            // Eliminar enemigos que deben ser removidos de la lista original
            foreach (PictureBox enemigoEliminado in enemigosEliminados)
            {
                enemigoEliminado.Dispose();
                enemigos.Remove(enemigoEliminado);
            }

            // Crear nuevos enemigos de forma aleatoria
            if (rnd.Next(0, 100) < 4) // creación de enemigos
            {
                PictureBox imgEnemigo = objNaveJugador.CrearEnemigo();
                int posX = rnd.Next(0, ClientSize.Width - imgEnemigo.Width);
                imgEnemigo.Location = new Point(posX, 0);
                Controls.Add(imgEnemigo);
                enemigos.Add(imgEnemigo);
            }
        }
        private void jugadorColisionado(object sender, EventArgs e)
        {
            vida -= 25; // Reducir la vida del jugador al colisionar con la bala del jefe
            ActualizarVida(vida); // Actualizar la barra de progreso de la vida
            if (vida <= 0)
            {
                gameOver();
            }
        }
        private void EnemigoColisionado(object sender, EventArgs e)
        {
            // Método para manejar la colisión con enemigos
            objNaveJugador.ColisionEnemigo();
        }
        private void ObjNaveJugador_jugadorColisionado(object sender, EventArgs e)
        {
            // Decrementar la vida del jugador en 25
            objNaveJugador.Vida -= 25;

            // Actualizar la barra de progreso de la vida en el formulario
            ActualizarVida(objNaveJugador.Vida);

            // Verificar si la vida llegó a cero y tomar acciones si es necesario
            if (objNaveJugador.Vida <= 0)
            {
                // Ejecutar acciones al perder el juego
                gameOver();
            }
        }
        private void ActualizarVida(int nuevaVida)
        {
            // Asegurar que la nuevaVida esté dentro del rango válido (0 - 100)
            int vidaActualizada = Math.Max(Math.Min(nuevaVida, 100), 0);
            pgbVida.Value = vidaActualizada;
        }
        private void ScoreCambiado(object sender, EventArgs e)
        {
            // Actualizar la barra de progreso de la puntuación
            pgbScore.Value = objNaveJugador.Score; // Suponiendo que objNaveJugador es la instancia de tu nave en el formulario
        }
        private void RestarVida()
        {
            vida -= 25; // Decrementar la vida en 25
            pgbVida.Value = vida; // Actualizar la barra de progreso de la vida
            if (vida <= 0)
            {
                gameOver();
            }
        }
        private void SumarScore()
        {
            score -= 25; // Decrementar el score en 25
            pgbScore.Value = score; // Actualizar la barra de progreso del score
        }
        
        //private void GuardarDatosEnExcel(string nombreJugador, int score)
        //{
        //    string carpetaScores = "Scores";
        //    string rutaScores = Path.Combine(Environment.CurrentDirectory, carpetaScores);

        //    // Verificar si la carpeta "Scores" existe, si no, crearla
        //    if (!Directory.Exists(rutaScores))
        //    {
        //        Directory.CreateDirectory(rutaScores);
        //    }

        //    string nombreArchivo = $"DatosJugador_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";
        //    string rutaCompleta = Path.Combine(rutaScores, nombreArchivo);

        //    using (ExcelPackage excelPackage = new ExcelPackage())
        //    {
        //        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("DatosJugador");

        //        worksheet.Cells[1, 1].Value = "Nombre";
        //        worksheet.Cells[1, 2].Value = "Score";

        //        worksheet.Cells[2, 1].Value = nombreJugador;
        //        worksheet.Cells[2, 2].Value = score;

        //        excelPackage.SaveAs(new FileInfo(rutaCompleta));

        //        MessageBox.Show($"Datos guardados en {rutaCompleta}", "Información");
        //    }
        //}
    }

}





