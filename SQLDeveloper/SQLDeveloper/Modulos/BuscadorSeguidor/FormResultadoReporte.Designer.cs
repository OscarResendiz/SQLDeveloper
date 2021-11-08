namespace SQLDeveloper.Modulos.BuscadorSeguidor
{
    partial class FormResultadoReporte
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
            this.griVisor1 = new GridControl.GriVisor();
            this.SuspendLayout();
            // 
            // griVisor1
            // 
            this.griVisor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.griVisor1.Location = new System.Drawing.Point(0, 0);
            this.griVisor1.Name = "griVisor1";
            this.griVisor1.Size = new System.Drawing.Size(667, 402);
            this.griVisor1.TabIndex = 0;
            this.griVisor1.Tabla = null;
            // 
            // FormResultadoReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 402);
            this.Controls.Add(this.griVisor1);
            this.Name = "FormResultadoReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormResultadoReporte";
            this.Load += new System.EventHandler(this.FormResultadoReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl.GriVisor griVisor1;
    }
}