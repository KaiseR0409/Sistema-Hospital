using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class GestionarPaciente : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Button btnAgregar;
        private DataGridView dgvPacientes;
        private string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";

        public GestionarPaciente()
        {
            InitializeComponent(); // Llamar al método renombrado
            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que el usuario pueda redimensionar el formulario
            CargarPacientes();

            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.dgvPacientes.CellClick += new DataGridViewCellEventHandler(this.dgvPacientes_CellClick);
            this.btnEditarPaciente.Click += new System.EventHandler(this.btnEditarPaciente_Click);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrEmpty(rut) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO paciente (Rut, Nombre, Correo, Telefono,HistorialDeCitas,HistorialClinico) VALUES (@Rut, @Nombre, @Correo, @Telefono,'HistorialDeCitas.pdf','HistorialClinico.pdf')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Rut", rut);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Paciente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPacientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            if (string.IsNullOrEmpty(rut))
            {
                MessageBox.Show("Ingrese el RUT del paciente a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Obtener todas las salas asociadas a las citas del paciente
                    string selectSalas = "SELECT DISTINCT IdSala FROM cita WHERE RutPaciente = @Rut";
                    var salas = new System.Collections.Generic.List<int>();
                    using (MySqlCommand cmdSelect = new MySqlCommand(selectSalas, conn))
                    {
                        cmdSelect.Parameters.AddWithValue("@Rut", rut);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                salas.Add(reader.GetInt32("IdSala"));
                            }
                        }
                    }

                    // 2. Eliminar todas las citas del paciente
                    string deleteCitas = "DELETE FROM cita WHERE RutPaciente = @Rut";
                    using (MySqlCommand cmdCita = new MySqlCommand(deleteCitas, conn))
                    {
                        cmdCita.Parameters.AddWithValue("@Rut", rut);
                        cmdCita.ExecuteNonQuery();
                    }

                    // 3. Para cada sala, verificar si tiene más citas activas
                    foreach (var idSala in salas)
                    {
                        string checkCitas = "SELECT COUNT(*) FROM cita WHERE IdSala = @IdSala";
                        using (MySqlCommand cmdCheck = new MySqlCommand(checkCitas, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@IdSala", idSala);
                            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                            if (count == 0)
                            {
                                // Si no hay más citas, marcar la sala como disponible
                                string updateSala = "UPDATE sala SET Estado = 1 WHERE IdSala = @IdSala";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(updateSala, conn))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@IdSala", idSala);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // 4. Eliminar el paciente
                    string deletePaciente = "DELETE FROM paciente WHERE Rut = @Rut";
                    using (MySqlCommand cmdPaciente = new MySqlCommand(deletePaciente, conn))
                    {
                        cmdPaciente.Parameters.AddWithValue("@Rut", rut);
                        int rows = cmdPaciente.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPacientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un paciente con ese RUT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPacientes.Rows[e.RowIndex];
                txtRut.Text = row.Cells["Rut"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            }
        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrEmpty(rut) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE paciente SET Nombre=@Nombre, Correo=@Correo, Telefono=@Telefono WHERE Rut=@Rut";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Rut", rut);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPacientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un paciente con ese RUT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarPacientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Rut, Nombre, Correo, Telefono FROM paciente";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPacientes.DataSource = dt;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var formPermisos = new GestionarPermisos();
            formPermisos.Show();
            this.Close();
        }

        private void GestionarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            GestionarPermisos gestionarPermisos = new GestionarPermisos(); // Crea una instancia del formulario GestionarPermisos
            gestionarPermisos.Show(); // Muestra el formulario GestionarPermisos
            this.Close(); // Cierra el formulario actual y vuelve al formulario anterior
        }

        private void VerificarPacienteAntesDeCita(MySqlConnection conn, string rutPaciente)
        {
            string checkPaciente = "SELECT COUNT(*) FROM paciente WHERE Rut = @Rut";
            using (MySqlCommand cmdCheck = new MySqlCommand(checkPaciente, conn))
            {
                cmdCheck.Parameters.AddWithValue("@Rut", rutPaciente);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (existe == 0)
                {
                    MessageBox.Show("El paciente no existe. Debe registrar al paciente antes de agendar la cita.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnEditarPaciente_Click_1(object sender, EventArgs e)
        {

        }
    }
}
