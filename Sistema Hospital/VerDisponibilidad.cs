using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema_Hospital
{
    public partial class VerDisponibilidad : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";

        public VerDisponibilidad()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            CargarSalas();
            chkSoloDisponibles.CheckedChanged += chkSoloDisponibles_CheckedChanged;
        }

        private void CargarSalas()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = chkSoloDisponibles.Checked
                    ? "SELECT * FROM sala WHERE Disponibilidad = 1"
                    : "SELECT * FROM sala";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSalas.DataSource = dt;
                dgvSalas.Columns["Disponibilidad"].HeaderText = "Disponible (1=Sí, 0=No)";
            }
        }

        private void chkSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            CargarSalas();
        }

        private void chkSoloDisponibles_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}