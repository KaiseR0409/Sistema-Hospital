namespace Sistema_Hospital
{
    partial class VerDisponibilidad
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.CheckBox chkSoloDisponibles;

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
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.chkSoloDisponibles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalas
            // 
            this.dgvSalas.AllowUserToAddRows = false;
            this.dgvSalas.AllowUserToDeleteRows = false;
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(48, 43);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            this.dgvSalas.Size = new System.Drawing.Size(435, 309);
            this.dgvSalas.TabIndex = 0;
            // 
            // chkSoloDisponibles
            // 
            this.chkSoloDisponibles.AutoSize = true;
            this.chkSoloDisponibles.Location = new System.Drawing.Point(20, 20);
            this.chkSoloDisponibles.Name = "chkSoloDisponibles";
            this.chkSoloDisponibles.Size = new System.Drawing.Size(165, 17);
            this.chkSoloDisponibles.TabIndex = 1;
            this.chkSoloDisponibles.Text = "Mostrar solo salas disponibles";
            this.chkSoloDisponibles.UseVisualStyleBackColor = true;
            this.chkSoloDisponibles.CheckedChanged += new System.EventHandler(this.chkSoloDisponibles_CheckedChanged_1);
            // 
            // VerDisponibilidad
            // 
            this.ClientSize = new System.Drawing.Size(535, 383);
            this.Controls.Add(this.chkSoloDisponibles);
            this.Controls.Add(this.dgvSalas);
            this.Name = "VerDisponibilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Disponibilidad de Salas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}