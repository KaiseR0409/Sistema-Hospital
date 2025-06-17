using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class GestionarOperador : Form
    {
        private Label lblUsuario;
        
        private Label lblPassword;
        
        private Button btnAgregar;
        private string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";

        public GestionarOperador()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que el usuario pueda redimensionar el formulario
            CargarOperadores();

            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.dgvOperadores.CellClick += new DataGridViewCellEventHandler(this.dgvOperadores_CellClick);
            this.btnEditarOperador.Click += new System.EventHandler(this.btnEditarOperador_Click);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = Login.CalcularHashSHA256(password);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO operador (usuario, password) VALUES (@usuario, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", passwordHash);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Operador agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarOperadores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar operador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingrese el usuario a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM operador WHERE usuario = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Operador eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarOperadores();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un operador con ese usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar operador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOperadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOperadores.Rows[e.RowIndex];
                txtUsuario.Text = row.Cells["usuario"].Value.ToString();
                txtPassword.Text = ""; // No mostrar la contraseña
            }
        }

        private void btnEditarOperador_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, seleccione un operador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese la nueva contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = Login.CalcularHashSHA256(password);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE operador SET password=@password WHERE usuario=@usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", passwordHash);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Operador actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarOperadores();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un operador con ese usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar operador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarOperadores()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT usuario FROM operador";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvOperadores.DataSource = dt;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            GestionarPermisos gestionarPermiso = new GestionarPermisos();
            gestionarPermiso.Show();
            this.Hide();
        }

        private void GestionarOperador_Load(object sender, EventArgs e)
        {

        }
    }
}