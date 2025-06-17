namespace Sistema_Hospital
{
    partial class GestionarPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGestionarPacientes = new System.Windows.Forms.Button();
            this.btnGestionarMedicos = new System.Windows.Forms.Button();
            this.btnGestionarOperadores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(33, 23);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "<--";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnGestionarPacientes
            // 
            this.btnGestionarPacientes.Location = new System.Drawing.Point(314, 38);
            this.btnGestionarPacientes.Name = "btnGestionarPacientes";
            this.btnGestionarPacientes.Size = new System.Drawing.Size(161, 78);
            this.btnGestionarPacientes.TabIndex = 1;
            this.btnGestionarPacientes.Text = "Gestionar Pacientes";
            this.btnGestionarPacientes.UseVisualStyleBackColor = true;
            this.btnGestionarPacientes.Click += new System.EventHandler(this.btnGestionarPacientes_Click);
            // 
            // btnGestionarMedicos
            // 
            this.btnGestionarMedicos.Location = new System.Drawing.Point(314, 167);
            this.btnGestionarMedicos.Name = "btnGestionarMedicos";
            this.btnGestionarMedicos.Size = new System.Drawing.Size(161, 76);
            this.btnGestionarMedicos.TabIndex = 2;
            this.btnGestionarMedicos.Text = "Gestionar Medicos";
            this.btnGestionarMedicos.UseVisualStyleBackColor = true;
            this.btnGestionarMedicos.Click += new System.EventHandler(this.btnGestionarMedicos_Click);
            // 
            // btnGestionarOperadores
            // 
            this.btnGestionarOperadores.Location = new System.Drawing.Point(314, 284);
            this.btnGestionarOperadores.Name = "btnGestionarOperadores";
            this.btnGestionarOperadores.Size = new System.Drawing.Size(161, 89);
            this.btnGestionarOperadores.TabIndex = 3;
            this.btnGestionarOperadores.Text = "GestionarOperadores";
            this.btnGestionarOperadores.UseVisualStyleBackColor = true;
            this.btnGestionarOperadores.Click += new System.EventHandler(this.btnGestionarOperadores_Click);
            // 
            // GestionarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGestionarOperadores);
            this.Controls.Add(this.btnGestionarMedicos);
            this.Controls.Add(this.btnGestionarPacientes);
            this.Controls.Add(this.btnVolver);
            this.Name = "GestionarPermisos";
            this.Text = "GestionarPermisos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGestionarPacientes;
        private System.Windows.Forms.Button btnGestionarMedicos;
        private System.Windows.Forms.Button btnGestionarOperadores;
    }
}