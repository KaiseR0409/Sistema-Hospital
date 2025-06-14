using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Sistema_Hospital
{
    public partial class MenuOperador : Form
    {
        string connectionString = "server=localhost;user=root;password=;database=centroclinico;port=3306;sslmode=none;";
        string rut;
        DateTime fecha;
        public MenuOperador()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuOperador_Load(object sender, EventArgs e)
        {
            CargarCitas();
        }
        private void CargarCitas()
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                    c.RutPaciente,
                    c.IdMedico,
                    c.FechaHora,
                    c.Estado,
                    c.NotasMedicas,
                    CASE
                        WHEN c.NotasMedicas LIKE '%infarto%' OR c.NotasMedicas LIKE '%fractura%' THEN 'Grave'
                        WHEN c.NotasMedicas LIKE '%dolor%' OR c.NotasMedicas LIKE '%fiebre%' THEN 'Moderado'
                        ELSE 'Leve'
                    END AS Gravedad
                 FROM cita c;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable citasTable = new DataTable();
                        adapter.Fill(citasTable);
                        dgvCitas.DataSource = citasTable;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            rut = txtBuscarRut.Text.Trim();
            fecha = dtpBuscarFecha.Value.Date;

            if (string.IsNullOrEmpty(rut))
            {
                MessageBox.Show("Por favor, ingrese un RUT válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    //abrir conexión
                    conn.Open();
                    //filtrar tabla por rut
                    string query = "SELECT RutPaciente,IdMedico,FechaHora,Estado,NotasMedicas, gravedad from cita where RutPaciente = @rut and DATE(FechaHora) >= @fecha;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rut", rut);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable citasFiltradas = new DataTable();
                        adapter.Fill(citasFiltradas);
                        if (citasFiltradas.Rows.Count > 0)
                        {
                            dgvCitas.DataSource = citasFiltradas;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron citas para el RUT y la fecha especificados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCitas.DataSource = null; // Limpiar el DataGridView si no hay resultados
                        }
                    }
                }
            }
        }

        private void txtBuscarRut_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarRut.Text.Replace("-", "").Trim(); //ELIMINA UIONES Y ESPACIOS DEL RUT
            if (texto.Length > 1)
            {
                string cuerpo = texto.Substring(0, texto.Length - 1); // Obtiene el cuerpo del RUT sin el dígito verificador
                string dv = texto.Substring(texto.Length - 1, 1); // Obtiene el dígito verificador del RUT
                txtBuscarRut.Text = cuerpo + "-" + dv; // Vuelve a construir el RUT con el guion
                txtBuscarRut.SelectionStart = txtBuscarRut.Text.Length; // Mueve el cursor al final del texto
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBuscarRut.ResetText(); // Resetea el campo de búsqueda de RUT
            dtpBuscarFecha.Value = DateTime.Now; // Resetea la fecha al día actual

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //abrir conexión
                conn.Open();
                string query = @"SELECT 
                    c.RutPaciente,
                    c.IdMedico,
                    c.FechaHora,
                    c.Estado,
                    c.NotasMedicas,
                    CASE
                        WHEN c.NotasMedicas LIKE '%infarto%' OR c.NotasMedicas LIKE '%fractura%' THEN 'Grave'
                        WHEN c.NotasMedicas LIKE '%dolor%' OR c.NotasMedicas LIKE '%fiebre%' THEN 'Moderado'
                        ELSE 'Leve'
                    END AS Gravedad
                 FROM cita c;"; // Consulta para obtener todas las citas
                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Ejecuta la consulta para obtener todas las citas
                {


                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); // Crea un adaptador para llenar el DataTable
                    DataTable citasTable = new DataTable(); // Crea un DataTable para almacenar los resultados
                    adapter.Fill(citasTable); // Llena el DataTable con los resultados de la consulta
                    dgvCitas.DataSource = citasTable; // Asigna el DataTable al DataGridView para mostrar todas las citas

                }
            }

        }
        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvCitas.Columns["Gravedad"].Index && e.Value != null)
            {
                string gravedad = e.Value.ToString();
                switch (gravedad)
                {
                    case "Grave":
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "Moderado":
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "Leve":
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            AgendarCita agendarForm = new AgendarCita();
            agendarForm.Show(); // Abre el formulario para agendar una cita
            this.Close(); // Cierra el formulario actual
        }
    }
}
