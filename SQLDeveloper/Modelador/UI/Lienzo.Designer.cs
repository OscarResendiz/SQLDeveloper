namespace Modelador.UI
{
    partial class Lienzo
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
            this.BNuevo = new System.Windows.Forms.ToolStripButton();
            this.BAbrir = new System.Windows.Forms.ToolStripButton();
            this.BGuardar = new System.Windows.Forms.ToolStripButton();
            this.BguardarComo = new System.Windows.Forms.ToolStripButton();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.controlDibujable1 = new Modelador.Dibujable.ControlDibujable();
            this.controladorCapas1 = new Modelador.UI.ControladorCapas();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlDibujable1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BNuevo,
            this.BAbrir,
            this.BGuardar,
            this.BguardarComo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(983, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BNuevo
            // 
            this.BNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BNuevo.Image = global::Modelador.Recursos.Nuevo;
            this.BNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Size = new System.Drawing.Size(23, 22);
            this.BNuevo.Text = "toolStripButton2";
            this.BNuevo.ToolTipText = "Nuevo";
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
            // 
            // BAbrir
            // 
            this.BAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAbrir.Image = global::Modelador.Recursos.Abrir;
            this.BAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAbrir.Name = "BAbrir";
            this.BAbrir.Size = new System.Drawing.Size(23, 22);
            this.BAbrir.Text = "toolStripButton1";
            this.BAbrir.ToolTipText = "Abrir";
            this.BAbrir.Click += new System.EventHandler(this.BAbrir_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGuardar.Image = global::Modelador.Recursos.filesave;
            this.BGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(23, 22);
            this.BGuardar.Text = "toolStripButton3";
            this.BGuardar.ToolTipText = "Guardar";
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BguardarComo
            // 
            this.BguardarComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BguardarComo.Image = global::Modelador.Recursos.gurdarcomo;
            this.BguardarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BguardarComo.Name = "BguardarComo";
            this.BguardarComo.Size = new System.Drawing.Size(23, 22);
            this.BguardarComo.Text = "toolStripButton1";
            this.BguardarComo.ToolTipText = "Guardar como";
            this.BguardarComo.Click += new System.EventHandler(this.BguardarComo_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(-15, -15);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(80, 17);
            this.hScrollBar1.TabIndex = 2;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar2.Location = new System.Drawing.Point(0, 741);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(789, 17);
            this.hScrollBar2.TabIndex = 3;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(772, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 741);
            this.vScrollBar1.TabIndex = 4;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.controlDibujable1);
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            this.splitContainer1.Panel1.Controls.Add(this.hScrollBar2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.controladorCapas1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(983, 758);
            this.splitContainer1.SplitterDistance = 789;
            this.splitContainer1.TabIndex = 5;
            // 
            // controlDibujable1
            // 
            this.controlDibujable1.AnchoCuadricula = 15;
            this.controlDibujable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlDibujable1.ColorCuadricula = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.controlDibujable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDibujable1.HScroolValue = 0;
            this.controlDibujable1.Location = new System.Drawing.Point(0, 0);
            this.controlDibujable1.Modelo = null;
            this.controlDibujable1.MostrarCuadricula = true;
            this.controlDibujable1.Name = "controlDibujable1";
            this.controlDibujable1.Size = new System.Drawing.Size(772, 741);
            this.controlDibujable1.TabIndex = 1;
            this.controlDibujable1.TabStop = false;
            this.controlDibujable1.VScroolValue = 0;
            // 
            // controladorCapas1
            // 
            this.controladorCapas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controladorCapas1.Location = new System.Drawing.Point(0, 0);
            this.controladorCapas1.Modelo = null;
            this.controladorCapas1.Name = "controladorCapas1";
            this.controladorCapas1.Size = new System.Drawing.Size(190, 758);
            this.controladorCapas1.TabIndex = 0;
            // 
            // Lienzo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Lienzo";
            this.Size = new System.Drawing.Size(983, 783);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlDibujable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Dibujable.ControlDibujable controlDibujable1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ToolStripButton BNuevo;
        private System.Windows.Forms.ToolStripButton BAbrir;
        private System.Windows.Forms.ToolStripButton BGuardar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ControladorCapas controladorCapas1;
        private System.Windows.Forms.ToolStripButton BguardarComo;
    }
}
