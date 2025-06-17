using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class Login : Form
    {
        //variables

        public Login()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249); // Verde menta suave
            // Opcional: Cambia el color de los controles principales
            txtUsuario.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            btnIngresar.BackColor = Color.FromArgb(102, 221, 187); // Un verde menta un poco más fuerte para el botón
            btnIngresar.ForeColor = Color.White;
            label1.ForeColor = Color.FromArgb(0, 128, 128); // Verde azulado para el título
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(184, 255, 249);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
                {
                    // Cambia Logearse a que devuelva true si el login es exitoso
                    if (Logearse(usuario, password))
                    {
                        this.Hide(); // Oculta el formulario solo si el login fue exitoso
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifica Logearse para que devuelva bool
        public static bool Logearse(string usuario, string password)
        {
            try
            {
                string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM operador WHERE usuario = @usuario;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string password_hash_guardada = reader.GetString("password");
                                string password_ingresada_hasheada = CalcularHashSHA256(password);

                                if (password_hash_guardada == password_ingresada_hasheada)
                                {
                                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MenuOperador menuForm = new MenuOperador();
                                    menuForm.Show();
                                    return true;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string CalcularHashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
