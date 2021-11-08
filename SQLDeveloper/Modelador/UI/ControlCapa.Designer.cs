
namespace Modelador.UI
{
    partial class ControlCapa
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
            this.ChechCapa = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BAgregarRegion = new System.Windows.Forms.ToolStripButton();
            this.BagregarTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Beliminar = new System.Windows.Forms.ToolStripButton();
            this.BNuevaTabla = new System.Windows.Forms.ToolStripButton();
            this.BImportarTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChechCapa
            // 
            this.ChechCapa.AutoSize = true;
            this.ChechCapa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ChechCapa.Location = new System.Drawing.Point(10, 41);
            this.ChechCapa.Name = "ChechCapa";
            this.ChechCapa.Size = new System.Drawing.Size(330, 17);
            this.ChechCapa.TabIndex = 0;
            this.ChechCapa.Text = "checkBox1";
            this.ChechCapa.UseVisualStyleBackColor = true;
            this.ChechCapa.CheckedChanged += new System.EventHandler(this.ChechCapa_CheckedChanged_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregarRegion,
            this.BagregarTabla,
            this.BNuevaTabla,
            this.BImportarTabla,
            this.toolStripSeparator1,
            this.Beliminar});
            this.toolStrip1.Location = new System.Drawing.Point(10, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(330, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BAgregarRegion
            // 
            this.BAgregarRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregarRegion.Image = global::Modelador.Recursos.IconoAgregar;
            this.BAgregarRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregarRegion.Name = "BAgregarRegion";
            this.BAgregarRegion.Size = new System.Drawing.Size(23, 22);
            this.BAgregarRegion.Text = "toolStripButton1";
            this.BAgregarRegion.ToolTipText = "Agregar Region";
            this.BAgregarRegion.Click += new System.EventHandler(this.BAgregarRegion_Click);
            // 
            // BagregarTabla
            // 
            this.BagregarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BagregarTabla.Image = global::Modelador.Recursos.Table_Field_Insert;
            this.BagregarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BagregarTabla.Name = "BagregarTabla";
            this.BagregarTabla.Size = new System.Drawing.Size(23, 22);
            this.BagregarTabla.Text = "toolStripButton1";
            this.BagregarTabla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BagregarTabla.ToolTipText = "Agregar Tabla";
            this.BagregarTabla.Click += new System.EventHandler(this.BagregarTabla_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Beliminar
            // 
            this.Beliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Beliminar.Image = global::Modelador.Recursos.IconoEliminar;
            this.Beliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Beliminar.Name = "Beliminar";
            this.Beliminar.Size = new System.Drawing.Size(23, 22);
            this.Beliminar.Text = "toolStripButton1";
            this.Beliminar.ToolTipText = "Eliminar Capa";
            this.Beliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // BNuevaTabla
            // 
            this.BNuevaTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BNuevaTabla.Image = global::Modelador.Recursos.Nuevo;
            this.BNuevaTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BNuevaTabla.Name = "BNuevaTabla";
            this.BNuevaTabla.Size = new System.Drawing.Size(23, 22);
            this.BNuevaTabla.Text = "toolStripButton1";
            this.BNuevaTabla.ToolTipText = "Nueva Tabla";
            this.BNuevaTabla.Click += new System.EventHandler(this.BNuevaTabla_Click);
            // 
            // BImportarTabla
            // 
            this.BImportarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BImportarTabla.Image = global::Modelador.Recursos.database_process_icon;
            this.BImportarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BImportarTabla.Name = "BImportarTabla";
            this.BImportarTabla.Size = new System.Drawing.Size(23, 22);
            this.BImportarTabla.Text = "toolStripButton1";
            this.BImportarTabla.ToolTipText = "Importar Tabla";
            this.BImportarTabla.Click += new System.EventHandler(this.BImportarTabla_Click);
            // 
            // ControlCapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ChechCapa);
            this.Name = "ControlCapa";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(350, 68);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChechCapa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregarRegion;
        private System.Windows.Forms.ToolStripButton BagregarTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Beliminar;
        private System.Windows.Forms.ToolStripButton BNuevaTabla;
        private System.Windows.Forms.ToolStripButton BImportarTabla;
    }
}
