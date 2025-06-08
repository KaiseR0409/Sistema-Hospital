namespace Sistema_Hospital
{
    partial class MenuOperador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Button btnAgendarCita;
        private System.Windows.Forms.Button btnGenerarInforme;
        private System.Windows.Forms.Button btnGestionarPermisos;
        private System.Windows.Forms.Button btnVerDisponibilidad;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.TextBox txtBuscarRut;
        private System.Windows.Forms.DateTimePicker dtpBuscarFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.Label lblFecha;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.btnAgendarCita = new System.Windows.Forms.Button();
            this.btnGenerarInforme = new System.Windows.Forms.Button();
            this.btnGestionarPermisos = new System.Windows.Forms.Button();
            this.btnVerDisponibilidad = new System.Windows.Forms.Button();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.txtBuscarRut = new System.Windows.Forms.TextBox();
            this.dtpBuscarFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.lblRut = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();

            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.Controls.Add(this.btnAgendarCita);
            this.panelIzquierdo.Controls.Add(this.btnGenerarInforme);
            this.panelIzquierdo.Controls.Add(this.btnGestionarPermisos);
            this.panelIzquierdo.Controls.Add(this.btnVerDisponibilidad);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Width = 180;
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(102, 221, 187);

            // 
            // Botones
            // 
            this.btnAgendarCita.Text = "Agendar Cita";
            this.btnAgendarCita.Top = 30;
            this.btnAgendarCita.Width = 150;
            this.btnAgendarCita.Left = 15;

            this.btnGenerarInforme.Text = "Generar Informe";
            this.btnGenerarInforme.Top = 80;
            this.btnGenerarInforme.Width = 150;
            this.btnGenerarInforme.Left = 15;

            this.btnGestionarPermisos.Text = "Gestionar Permisos";
            this.btnGestionarPermisos.Top = 130;
            this.btnGestionarPermisos.Width = 150;
            this.btnGestionarPermisos.Left = 15;

            this.btnVerDisponibilidad.Text = "Ver Disponibilidad";
            this.btnVerDisponibilidad.Top = 180;
            this.btnVerDisponibilidad.Width = 150;
            this.btnVerDisponibilidad.Left = 15;

            // 
            // panelDerecho
            // 
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Controls.Add(this.lblRut);
            this.panelDerecho.Controls.Add(this.txtBuscarRut);
            this.panelDerecho.Controls.Add(this.lblFecha);
            this.panelDerecho.Controls.Add(this.dtpBuscarFecha);
            this.panelDerecho.Controls.Add(this.btnBuscar);
            this.panelDerecho.Controls.Add(this.dgvCitas);
            this.panelDerecho.BackColor = System.Drawing.Color.White;

            // 
            // lblRut
            // 
            this.lblRut.Text = "RUT:";
            this.lblRut.Top = 20;
            this.lblRut.Left = 20;
            this.lblRut.Width = 40;

            // 
            // txtBuscarRut
            // 
            this.txtBuscarRut.Top = 18;
            this.txtBuscarRut.Left = 65;
            this.txtBuscarRut.Width = 120;

            // 
            // lblFecha
            // 
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 20;
            this.lblFecha.Left = 200;
            this.lblFecha.Width = 50;

            // 
            // dtpBuscarFecha
            // 
            this.dtpBuscarFecha.Top = 18;
            this.dtpBuscarFecha.Left = 255;
            this.dtpBuscarFecha.Width = 120;
            this.dtpBuscarFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // 
            // btnBuscar
            // 
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Top = 16;
            this.btnBuscar.Left = 390;
            this.btnBuscar.Width = 80;

            // 
            // dgvCitas
            // 
            this.dgvCitas.Top = 60;
            this.dgvCitas.Left = 20;
            this.dgvCitas.Width = 600;
            this.dgvCitas.Height = 350;
            this.dgvCitas.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom);
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // MenuOperador
            // 
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.Text = "Menú Operador";
            this.Size = new System.Drawing.Size(850, 450);
        }

        #endregion
    }
}