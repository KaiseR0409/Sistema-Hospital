using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Hospital
{
    public partial class MenuOperador : Form
    {
        public MenuOperador()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string rut = txtBuscarRut.Text.Trim();
            DateTime fecha = dtpBuscarFecha.Value.Date;

            // Aquí deberías consultar la base de datos o tu fuente de datos
            // para filtrar las citas por RUT y fecha, y luego mostrar los resultados en dgvCitas.
            // Ejemplo:
            // dgvCitas.DataSource = ObtenerCitasFiltradas(rut, fecha);
        }
    }
}
