using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class GestionarMedico : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblEspecialidad;
        private TextBox txtEspecialidad;
        private Label lblEstado;
        private CheckBox chkDisponible;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnEditarMedico;
        private DataGridView dgvMedicos;
        private string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";

        public GestionarMedico()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarMedicos();

            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.dgvMedicos.CellClick += new DataGridViewCellEventHandler(this.dgvMedicos_CellClick);
            this.btnEditarMedico.Click += new System.EventHandler(this.btnEditarMedico_Click);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string especialidad = txtEspecialidad.Text.Trim();
            bool disponible = chkDisponible.Checked;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(especialidad))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO medico (Nombre, Especialidad, Estado) VALUES (@Nombre, @Especialidad, @Estado)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                        cmd.Parameters.AddWithValue("@Estado", disponible ? "Disponible" : "Ausente");
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Médico agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMedicos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar médico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un médico para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMedico = Convert.ToInt32(dgvMedicos.CurrentRow.Cells["IdMedico"].Value);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM medico WHERE IdMedico = @IdMedico";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Médico eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarMedicos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un médico con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar médico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicos.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtEspecialidad.Text = row.Cells["Especialidad"].Value.ToString();
                chkDisponible.Checked = row.Cells["Estado"].Value.ToString() == "Disponible";
            }
        }

        private void btnEditarMedico_Click(object sender, EventArgs e)
        {
            if (dgvMedicos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un médico para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMedico = Convert.ToInt32(dgvMedicos.CurrentRow.Cells["IdMedico"].Value);
            string nombre = txtNombre.Text.Trim();
            string especialidad = txtEspecialidad.Text.Trim();
            bool disponible = chkDisponible.Checked;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(especialidad))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE medico SET Nombre=@Nombre, Especialidad=@Especialidad, Estado=@Estado WHERE IdMedico=@IdMedico";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                        cmd.Parameters.AddWithValue("@Estado", disponible ? "Disponible" : "Ausente");
                        cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Médico actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarMedicos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un médico con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar médico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarMedicos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IdMedico, Nombre, Especialidad, Estado FROM medico";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMedicos.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionarPermisos gestionarPermisos = new GestionarPermisos(); // Crea una instancia del formulario GestionarPermisos
            gestionarPermisos.Show(); // Muestra el formulario GestionarPermisos
            this.Close(); // Cierra el formulario actual y vuelve al formulario anterior
        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}