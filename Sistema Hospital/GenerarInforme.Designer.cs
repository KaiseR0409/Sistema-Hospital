namespace Sistema_Hospital
{
    partial class GenerarInforme
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRutPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIdMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNotasMedicas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumeroSala;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGravedad;
        private System.Windows.Forms.Button btnExportar;

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
            this.label1 = new System.Windows.Forms.Label();
            this.lblRutPaciente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIdMedico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNotasMedicas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumeroSala = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGravedad = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Text = "RUT Paciente:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            // 
            // lblRutPaciente
            // 
            this.lblRutPaciente.Location = new System.Drawing.Point(150, 20);
            this.lblRutPaciente.AutoSize = true;
            // 
            // label2
            // 
            this.label2.Text = "ID Médico:";
            this.label2.Location = new System.Drawing.Point(20, 50);
            // 
            // lblIdMedico
            // 
            this.lblIdMedico.Location = new System.Drawing.Point(150, 50);
            this.lblIdMedico.AutoSize = true;
            // 
            // label3
            // 
            this.label3.Text = "Fecha y Hora:";
            this.label3.Location = new System.Drawing.Point(20, 80);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Location = new System.Drawing.Point(150, 80);
            this.lblFechaHora.AutoSize = true;
            // 
            // label4
            // 
            this.label4.Text = "Estado:";
            this.label4.Location = new System.Drawing.Point(20, 110);
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(150, 110);
            this.lblEstado.AutoSize = true;
            // 
            // label5
            // 
            this.label5.Text = "Notas Médicas:";
            this.label5.Location = new System.Drawing.Point(20, 140);
            // 
            // lblNotasMedicas
            // 
            this.lblNotasMedicas.Location = new System.Drawing.Point(150, 140);
            this.lblNotasMedicas.AutoSize = true;
            // 
            // label6
            // 
            this.label6.Text = "Número Sala:";
            this.label6.Location = new System.Drawing.Point(20, 170);
            // 
            // lblNumeroSala
            // 
            this.lblNumeroSala.Location = new System.Drawing.Point(150, 170);
            this.lblNumeroSala.AutoSize = true;
            // 
            // label7
            // 
            this.label7.Text = "Gravedad:";
            this.label7.Location = new System.Drawing.Point(20, 200);
            // 
            // lblGravedad
            // 
            this.lblGravedad.Location = new System.Drawing.Point(150, 200);
            this.lblGravedad.AutoSize = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Text = "Exportar Informe";
            this.btnExportar.Location = new System.Drawing.Point(20, 240);
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // GenerarInforme
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRutPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdMedico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNotasMedicas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNumeroSala);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblGravedad);
            this.Controls.Add(this.btnExportar);
            this.Name = "GenerarInforme";
            this.Text = "Informe de Cita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}