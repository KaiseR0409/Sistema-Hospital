using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class GenerarInforme : Form
    {
        public GenerarInforme(
            string rutPaciente,
            string idMedico,
            string fechaHora,
            string estado,
            string notasMedicas,
            string numeroSala,
            string gravedad)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que el usuario pueda redimensionar el formulario

            // Asegúrate de que los nombres de los labels coincidan con los del Designer
            lblRutPaciente.Text = rutPaciente ?? "";
            lblIdMedico.Text = idMedico ?? "";
            lblFechaHora.Text = fechaHora ?? "";
            lblEstado.Text = estado ?? "";
            lblNotasMedicas.Text = notasMedicas ?? "";
            lblNumeroSala.Text = numeroSala ?? "";
            lblGravedad.Text = gravedad ?? "";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}