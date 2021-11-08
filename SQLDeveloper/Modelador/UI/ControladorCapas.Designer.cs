
namespace Modelador.UI
{
    partial class ControladorCapas
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BAgregar = new System.Windows.Forms.ToolStripButton();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BAgregar
            // 
            this.BAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregar.Image = global::Modelador.Recursos.IconoAgregar;
            this.BAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(23, 22);
            this.BAgregar.Text = "toolStripButton1";
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.AutoSize = true;
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelContenedor.Location = new System.Drawing.Point(0, 473);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(260, 0);
            this.PanelContenedor.TabIndex = 1;
            // 
            // ControladorCapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControladorCapas";
            this.Size = new System.Drawing.Size(260, 473);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregar;
        private System.Windows.Forms.Panel PanelContenedor;
    }
}
