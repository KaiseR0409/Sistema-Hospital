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
            this.lblRut = new System.Windows.Forms.Label();
            this.txtBuscarRut = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpBuscarFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelIzquierdo.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(221)))), ((int)(((byte)(187)))));
            this.panelIzquierdo.Controls.Add(this.btnAgendarCita);
            this.panelIzquierdo.Controls.Add(this.btnGenerarInforme);
            this.panelIzquierdo.Controls.Add(this.btnGestionarPermisos);
            this.panelIzquierdo.Controls.Add(this.btnVerDisponibilidad);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(180, 448);
            this.panelIzquierdo.TabIndex = 1;
            // 
            // btnAgendarCita
            // 
            this.btnAgendarCita.Location = new System.Drawing.Point(15, 30);
            this.btnAgendarCita.Name = "btnAgendarCita";
            this.btnAgendarCita.Size = new System.Drawing.Size(150, 23);
            this.btnAgendarCita.TabIndex = 0;
            this.btnAgendarCita.Text = "Agendar Cita";
            // 
            // btnGenerarInforme
            // 
            this.btnGenerarInforme.Location = new System.Drawing.Point(15, 80);
            this.btnGenerarInforme.Name = "btnGenerarInforme";
            this.btnGenerarInforme.Size = new System.Drawing.Size(150, 23);
            this.btnGenerarInforme.TabIndex = 1;
            this.btnGenerarInforme.Text = "Generar Informe";
            // 
            // btnGestionarPermisos
            // 
            this.btnGestionarPermisos.Location = new System.Drawing.Point(15, 130);
            this.btnGestionarPermisos.Name = "btnGestionarPermisos";
            this.btnGestionarPermisos.Size = new System.Drawing.Size(150, 23);
            this.btnGestionarPermisos.TabIndex = 2;
            this.btnGestionarPermisos.Text = "Gestionar Permisos";
            // 
            // btnVerDisponibilidad
            // 
            this.btnVerDisponibilidad.Location = new System.Drawing.Point(15, 180);
            this.btnVerDisponibilidad.Name = "btnVerDisponibilidad";
            this.btnVerDisponibilidad.Size = new System.Drawing.Size(150, 23);
            this.btnVerDisponibilidad.TabIndex = 3;
            this.btnVerDisponibilidad.Text = "Ver Disponibilidad";
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.White;
            this.panelDerecho.Controls.Add(this.btnLimpiar);
            this.panelDerecho.Controls.Add(this.lblRut);
            this.panelDerecho.Controls.Add(this.txtBuscarRut);
            this.panelDerecho.Controls.Add(this.lblFecha);
            this.panelDerecho.Controls.Add(this.dtpBuscarFecha);
            this.panelDerecho.Controls.Add(this.btnBuscar);
            this.panelDerecho.Controls.Add(this.dgvCitas);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(180, 0);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(608, 448);
            this.panelDerecho.TabIndex = 0;
            // 
            // lblRut
            // 
            this.lblRut.Location = new System.Drawing.Point(20, 20);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(40, 23);
            this.lblRut.TabIndex = 0;
            this.lblRut.Text = "RUT:";
            // 
            // txtBuscarRut
            // 
            this.txtBuscarRut.Location = new System.Drawing.Point(65, 18);
            this.txtBuscarRut.MinimumSize = new System.Drawing.Size(0, 10);
            this.txtBuscarRut.Name = "txtBuscarRut";
            this.txtBuscarRut.Size = new System.Drawing.Size(120, 20);
            this.txtBuscarRut.TabIndex = 1;
            this.txtBuscarRut.TextChanged += new System.EventHandler(this.txtBuscarRut_TextChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(200, 20);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(50, 23);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpBuscarFecha
            // 
            this.dtpBuscarFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBuscarFecha.Location = new System.Drawing.Point(255, 18);
            this.dtpBuscarFecha.Name = "dtpBuscarFecha";
            this.dtpBuscarFecha.Size = new System.Drawing.Size(120, 20);
            this.dtpBuscarFecha.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(390, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // dgvCitas
            // 
            this.dgvCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCitas.Location = new System.Drawing.Point(23, 58);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.Size = new System.Drawing.Size(582, 387);
            this.dgvCitas.TabIndex = 5;
            this.dgvCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellContentClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(486, 15);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 24);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar Filtro";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuOperador
            // 
            this.ClientSize = new System.Drawing.Size(788, 448);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.Name = "MenuOperador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Operador";
            this.Load += new System.EventHandler(this.MenuOperador_Load);
            this.panelIzquierdo.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            this.panelDerecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
    }
}