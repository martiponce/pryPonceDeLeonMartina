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
    public partial class frmInicioJuego : Form
    {
        public frmInicioJuego()
        {
            InitializeComponent();
        }

        string nombre;
        private void btnComenzar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text.Trim(); // Obtener el nombre ingresado

            if (!string.IsNullOrEmpty(nombre))
            {
                frmJuego frmJuego = new frmJuego();
                frmJuego.SetNombreJugador(nombre); // Pasar el nombre al formulario principal
                frmJuego.Show();                
            }
            else
            {
                MessageBox.Show("Por favor, ingrese su nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmInicioJuego_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frm = new frmMain();
            frm.Show();
        }
    }
}
