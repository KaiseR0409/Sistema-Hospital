using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Hospital
{

    public partial class AgendarCita : Form
    {
        string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";

        // Agrega este campo en la declaración de variables de la clase


        public AgendarCita()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(184, 255, 249); //cambia el color de fondo del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que el usuario pueda redimensionar el formulario

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Cargar especialidades únicas
                    string queryEspecialidades = "SELECT DISTINCT Especialidad FROM medico";
                    MySqlCommand cmdEspecialidades = new MySqlCommand(queryEspecialidades, conn);
                    MySqlDataReader readerEspecialidades = cmdEspecialidades.ExecuteReader();
                    while (readerEspecialidades.Read())
                    {
                        cbEspecialidad.Items.Add(readerEspecialidades.GetString("Especialidad"));
                    }
                    readerEspecialidades.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Asocia el evento
            cbEspecialidad.SelectedIndexChanged += cbEspecialidad_SelectedIndexChanged;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuOperador menuOperador = new MenuOperador(); // Crea una instancia del formulario MenuOperador
            menuOperador.Show(); // Muestra el formulario MenuOperador
            this.Close(); // Cierra el formulario actual y vuelve al formulario anterior
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {

            string rut = txtRut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string especialidad = cbEspecialidad.SelectedItem.ToString();
            string doctor = cbMedicos.SelectedItem.ToString();
            string sala = cbSalas.SelectedItem.ToString();
            DateTime fechaHora = dtHorario.Value;
            string estado = "Programado";
            string notas = txtNotas.Text.Trim();

            // Justo antes de la conexión:
            var medicoSeleccionado = cbMedicos.SelectedItem as ComboboxItem;
            int idMedico = (int)medicoSeleccionado.Value;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO cita (RutPaciente, IdMedico, NumeroSala, FechaHora, Estado, NotasMedicas) 
                                     VALUES (@RutPaciente, @IdMedico, @NumeroSala, @FechaHora, @Estado, @NotasMedicas)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RutPaciente", rut);
                        command.Parameters.AddWithValue("@IdMedico", idMedico);
                        command.Parameters.AddWithValue("@NumeroSala", sala);
                        command.Parameters.AddWithValue("@FechaHora", fechaHora);
                        command.Parameters.AddWithValue("@Estado", estado);
                        command.Parameters.AddWithValue("@NotasMedicas", notas); // Puedes agregar notas médicas si es necesario
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Actualizar la disponibilidad de la sala a 0
                            string updateSala = "UPDATE sala SET Disponibilidad = 0 WHERE NumeroSala = @NumeroSala";
                            using (MySqlCommand cmdUpdateSala = new MySqlCommand(updateSala, connection))
                            {
                                cmdUpdateSala.Parameters.AddWithValue("@NumeroSala", sala);
                                cmdUpdateSala.ExecuteNonQuery();
                            }

                            MessageBox.Show("Cita agendada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error al agendar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            string texto = txtRut.Text.Replace("-", "").Trim(); //ELIMINA UIONES Y ESPACIOS DEL RUT
            if (texto.Length > 1)
            {
                string cuerpo = texto.Substring(0, texto.Length - 1); // Obtiene el cuerpo del RUT sin el dígito verificador
                string dv = texto.Substring(texto.Length - 1, 1); // Obtiene el dígito verificador del RUT
                txtRut.Text = cuerpo + "-" + dv; // Vuelve a construir el RUT con el guion
                txtRut.SelectionStart = txtRut.Text.Length; // Mueve el cursor al final del texto
            }
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMedicos.Items.Clear();
            cbSalas.Items.Clear();

            string especialidadSeleccionada = cbEspecialidad.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Cargar médicos de la especialidad seleccionada
                    string queryMedicos = "SELECT IdMedico, Nombre FROM medico WHERE Especialidad = @Especialidad";
                    MySqlCommand cmdMedicos = new MySqlCommand(queryMedicos, conn);
                    cmdMedicos.Parameters.AddWithValue("@Especialidad", especialidadSeleccionada);
                    MySqlDataReader readerMedicos = cmdMedicos.ExecuteReader();
                    while (readerMedicos.Read())
                    {
                        cbMedicos.Items.Add(new ComboboxItem
                        {
                            Text = readerMedicos.GetString("Nombre"),
                            Value = readerMedicos.GetInt32("IdMedico")
                        });
                    }
                    readerMedicos.Close();

                    // Cargar salas disponibles
                    string querySalas = "SELECT NumeroSala FROM sala WHERE Disponibilidad = 1";
                    MySqlCommand cmdSalas = new MySqlCommand(querySalas, conn);
                    MySqlDataReader readerSalas = cmdSalas.ExecuteReader();
                    while (readerSalas.Read())
                    {
                        cbSalas.Items.Add(readerSalas.GetInt32("NumeroSala").ToString());
                    }
                    readerSalas.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar médicos o salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
