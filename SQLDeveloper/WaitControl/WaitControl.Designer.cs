namespace WaitControl
{
    partial class WaitControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarraInterior = new System.Windows.Forms.Panel();
            this.PanelDerecho = new System.Windows.Forms.Panel();
            this.PanelIzquierdo = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BarraInterior.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraInterior
            // 
            this.BarraInterior.BackColor = System.Drawing.Color.Silver;
            this.BarraInterior.Controls.Add(this.PanelDerecho);
            this.BarraInterior.Controls.Add(this.PanelIzquierdo);
            this.BarraInterior.Location = new System.Drawing.Point(3, 0);
            this.BarraInterior.Name = "BarraInterior";
            this.BarraInterior.Size = new System.Drawing.Size(170, 22);
            this.BarraInterior.TabIndex = 0;
            // 
            // PanelDerecho
            // 
            this.PanelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelDerecho.Location = new System.Drawing.Point(78, 0);
            this.PanelDerecho.Name = "PanelDerecho";
            this.PanelDerecho.Size = new System.Drawing.Size(92, 22);
            this.PanelDerecho.TabIndex = 1;
            // 
            // PanelIzquierdo
            // 
            this.PanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.PanelIzquierdo.Name = "PanelIzquierdo";
            this.PanelIzquierdo.Size = new System.Drawing.Size(82, 22);
            this.PanelIzquierdo.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WaitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BarraInterior);
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(460, 22);
            this.Resize += new System.EventHandler(this.WaitControl_Resize);
            this.BarraInterior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraInterior;
        private System.Windows.Forms.Panel PanelDerecho;
        private System.Windows.Forms.Panel PanelIzquierdo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
