using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class GestionarPermisos : Form
    {
        public GestionarPermisos()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que el usuario pueda redimensionar el formulario
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuOperador menuOperador = new MenuOperador(); // Crea una instancia del formulario MenuOperador
            menuOperador.Show(); // Muestra el formulario MenuOperador
            this.Close(); // Cierra el formulario actual y vuelve al formulario anterior
        }

        private void btnGestionarPacientes_Click(object sender, EventArgs e)
        {
            GestionarPaciente gestionarPaciente = new GestionarPaciente(); // Crea una instancia del formulario GestionarPaciente
            this.Hide(); // Oculta el formulario actual
            gestionarPaciente.Show(); // Muestra el formulario GestionarPaciente
        }

        private void btnGestionarMedicos_Click(object sender, EventArgs e)
        {
            GestionarMedico gestionarMedico = new GestionarMedico(); // Crea una instancia del formulario GestionarMedico
            this.Hide(); // Oculta el formulario actual
            gestionarMedico.Show();
        }

        private void btnGestionarOperadores_Click(object sender, EventArgs e)
        {
            GestionarOperador gestionarOperador = new GestionarOperador(); // Crea una instancia del formulario GestionarOperador
            this.Hide(); // Oculta el formulario actual
            gestionarOperador.Show();
        }
    }
}
