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
        
        //variables
        private Timer gameTimer = new Timer();
        private Random rnd = new Random();
        private int vida = 100; // Valor inicial de la vida del jugador
        private int score = 250; // Valor inicial del score
        private string nombreJugador;


        //listas
        List<PictureBox> enemigosEliminados = new List<PictureBox>(); //enemigos eliminados 
        private List<PictureBox> balas = new List<PictureBox>(); //balas
        private List<PictureBox> enemigos = new List<PictureBox>(); //enemigos
        private List<PictureBox> jugadores = new List<PictureBox>(); // Lista que incluye la nave del jugador y posiblemente otras naves de jugadores

        public event EventHandler jugadorColisionadoHandler;

        public frmJuego()
        {
            InitializeComponent();
            gameTimer.Interval = 100; // Intervalo del temporizador en milisegundos
            gameTimer.Tick += GameLoop; // Evento que se ejecuta en cada tick del temporizador

            // Crear y configurar el jugador
            objNaveJugador = new clsNave();
            objNaveJugador.CrearJugador();
            PosX = 350;
            PosY = 650;
            objNaveJugador.ImgNave.Location = new Point(PosX, PosY);
            Controls.Add(objNaveJugador.ImgNave);
            pgbScore.Value = 0;
           
            // Actualizar las barras de progreso al inicio del juego
            pgbVida.Value = vida;

            objJefe = new clsNave();  // Inicializar el objeto objJefe
            jugadorColisionadoHandler += ObjNaveJugador_jugadorColisionado; // Suscribir al evento

            gameTimer.Start(); // Iniciar el temporizador

        }

        //procedimientos y funciones
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
                Disparar(posicionNave);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoverNave(6, 0); // Mover a la derecha
            }
            else if (e.KeyCode == Keys.Left)
            {
                MoverNave(-6, 0); // Mover a la izquierda
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoverNave(0, -6); // Mover hacia arriba
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoverNave(0, 6); // Mover hacia abajo
            }

            if(e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
        private void GameLoop(object sender, EventArgs e)
        {
            // Lógica del juego
            MoverEnemigos();
            MoverBala(enemigos); // Mueve la bala del jugador y verifica colisiones
                                               // Verificar que objJefe no sea null antes de llamar a sus métodos
            if (objJefe != null)
            {
                MoverBalaJefe(jugadores); // Mueve la bala del jefe y verifica colisiones
            }
        }
        private void gameOver()
        {
            // Guardar datos en Excel
            //GuardarDatosEnExcel(nombreJugador, score);

            gameTimer.Stop(); // Detener el temporizador
            MessageBox.Show($"Game Over {nombreJugador}\nScore: {pgbScore.Value}\n¡Suerte la Próxima! ", "Juego Terminado");
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
            // Lista auxiliar para almacenar enemigos eliminados

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
        }

        //private void levelFinal()
        //  {
        //      if ()
        //      {
        //          gameTimer.Stop(); // Detener el temporizador
        //          enemigos.Clear();
        //          foreach (Control control in Controls)
        //          {
        //              if (control is PictureBox && control != objNaveJugador.ImgNave)
        //              {
        //                  control.Dispose();
        //              }
        //          }
        //          this.Close();
        //          frmJefe f = new frmJefe();
        //          f.ShowDialog();

        //      }
            //vida -= 25; // Decrementar la vida en 25
            //pgbVida.Value = vida; // Actualizar la barra de progreso de la vida
            //if (vida <= 0)
            //{
            //    gameOver();
            //}
       
    //  }

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
                            balasEliminadas.Add(bala);
                            enemigosEliminados.Add(enemigo);
                            pgbScore.Value += 25;// Agregar a la lista de eliminados

                            break; // Salir del bucle al eliminar un enemigo
                        }
                    }

                    foreach (PictureBox enemigoEliminado in enemigosEliminados)
                    {
                        enemigoEliminado.Dispose();
                        enemigos.Remove(enemigoEliminado);
                    }
                }
            }

            // Eliminar las balas que deben ser removidas de la lista original
            foreach (PictureBox balaEliminada in balasEliminadas)
            {
                balas.Remove(balaEliminada);
            }


        }

        public void Disparar(Point posicion)
        {
            PictureBox nuevaBala = new PictureBox();
            nuevaBala.SizeMode = PictureBoxSizeMode.StretchImage;
            nuevaBala.ImageLocation = "https://i.postimg.cc/FHPqQ4kJ/bullet.png";
            nuevaBala.Visible = true;
            nuevaBala.Size = new Size(10, 20); // Tamaño de la bala

            // Posición de la nueva bala
            nuevaBala.Location = new Point(posicion.X + objNaveJugador.ImgNave.Width / 2 - nuevaBala.Width / 2, posicion.Y);

            Form formulario = objNaveJugador.ImgNave.FindForm();
            formulario.Controls.Add(nuevaBala);

            balas.Add(nuevaBala); // Agregar la nueva bala a la lista de balas
        }

        public void DispararBalaJefe()
        {
            PictureBox nuevaBala = new PictureBox();
            nuevaBala.SizeMode = PictureBoxSizeMode.StretchImage;
            nuevaBala.ImageLocation = "https://w7.pngwing.com/pngs/107/369/png-transparent-bank-cash-coin-dollar-money-payment-money-related-icon.png";
            nuevaBala.Size = new Size(10, 20); // Tamaño de la bala

            // Posición de la nueva bala (disparo hacia abajo desde el jefe)
            nuevaBala.Location = new Point(PosX + objNaveJugador.ImgNave.Width / 2 - nuevaBala.Width / 2, PosY + objNaveJugador.ImgNave.Height);

            Form formulario = objNaveJugador.ImgNave.FindForm();
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

                    if (bala.Top > objNaveJugador.ImgNave.Parent.Height)
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
                            jugadorColisionadoHandler?.Invoke(this, EventArgs.Empty);
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

        public void MoverNave(int deltaX, int deltaY)
        {
            // Obtener la nueva posición propuesta
            int nuevaX = PosX + deltaX;
            int nuevaY = PosY + deltaY;

            // Limitar el movimiento hacia abajo (solo si se va a mover hacia abajo)
            if (deltaY > 0 && nuevaY + objNaveJugador.ImgNave.Height > objNaveJugador.ImgNave.Parent.Height)
            {
                nuevaY = objNaveJugador.ImgNave.Parent.Height - objNaveJugador.ImgNave.Height;
            }

            // Actualizar la posición solo si está dentro de los límites
            if (nuevaX >= 0 && nuevaX + objNaveJugador.ImgNave.Width <= objNaveJugador.ImgNave.Parent.Width &&
                nuevaY >= 0 && nuevaY + objNaveJugador.ImgNave.Height <= objNaveJugador.ImgNave.Parent.Height)
            {
                PosX = nuevaX;
                PosY = nuevaY;
                objNaveJugador.ImgNave.Location = new Point(PosX, PosY);
            }
        }

        public void MoverJefe(int deltaX)
        {
            // Movimiento del jefe de lado a lado
            int nuevaX = PosX + deltaX;

            // Limitar el movimiento dentro de los límites del formulario
            if (nuevaX >= 0 && nuevaX + objNaveJugador.ImgNave.Width <= objNaveJugador.ImgNave.Parent.Width)
            {
                PosX = nuevaX;
                objNaveJugador.ImgNave.Location = new Point(PosX, PosY);
            }
        }

        public int PosX { get; set; }  // Propiedad para la posición X
        public int PosY { get; set; }  // Propiedad para la posición Y

        
    }

}





