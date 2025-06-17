namespace Sistema_Hospital
{
    partial class GestionarOperador
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.TextBox txtUsuario;
        
        private System.Windows.Forms.TextBox txtPassword;
        
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditarOperador;
        private System.Windows.Forms.DataGridView dgvOperadores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditarOperador = new System.Windows.Forms.Button();
            this.dgvOperadores = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(120, 27);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(350, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 25);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(350, 55);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 25);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditarOperador
            // 
            this.btnEditarOperador.Location = new System.Drawing.Point(350, 85);
            this.btnEditarOperador.Name = "btnEditarOperador";
            this.btnEditarOperador.Size = new System.Drawing.Size(90, 25);
            this.btnEditarOperador.TabIndex = 6;
            this.btnEditarOperador.Text = "Editar";
            this.btnEditarOperador.UseVisualStyleBackColor = true;
            this.btnEditarOperador.Click += new System.EventHandler(this.btnEditarOperador_Click);
            // 
            // dgvOperadores
            // 
            this.dgvOperadores.AllowUserToAddRows = false;
            this.dgvOperadores.AllowUserToDeleteRows = false;
            this.dgvOperadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperadores.Location = new System.Drawing.Point(135, 134);
            this.dgvOperadores.Name = "dgvOperadores";
            this.dgvOperadores.ReadOnly = true;
            this.dgvOperadores.Size = new System.Drawing.Size(174, 193);
            this.dgvOperadores.TabIndex = 7;
            this.dgvOperadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperadores_CellClick);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(40, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "<--";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // GestionarOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvOperadores);
            this.Controls.Add(this.btnEditarOperador);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Name = "GestionarOperador";
            this.Text = "Gestionar Operador";
            this.Load += new System.EventHandler(this.GestionarOperador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnVolver;
    }
}