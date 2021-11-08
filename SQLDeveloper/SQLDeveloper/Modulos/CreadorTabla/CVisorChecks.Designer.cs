namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class CVisorChecks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CVisorChecks));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BAgregar = new System.Windows.Forms.ToolStripButton();
            this.BEliminar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTabla = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListaChecks = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TRegla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregar,
            this.BEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(625, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BAgregar
            // 
            this.BAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(23, 22);
            this.BAgregar.Text = "Agregar";
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(23, 22);
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTabla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 43);
            this.panel1.TabIndex = 9;
            // 
            // LTabla
            // 
            this.LTabla.AutoSize = true;
            this.LTabla.Location = new System.Drawing.Point(13, 13);
            this.LTabla.Name = "LTabla";
            this.LTabla.Size = new System.Drawing.Size(34, 13);
            this.LTabla.TabIndex = 0;
            this.LTabla.Text = "Tabla";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaChecks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TRegla);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.TNombre);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(625, 331);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 11;
            // 
            // ListaChecks
            // 
            this.ListaChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaChecks.ImageIndex = 0;
            this.ListaChecks.ImageList = this.imageList1;
            this.ListaChecks.Location = new System.Drawing.Point(0, 0);
            this.ListaChecks.Name = "ListaChecks";
            this.ListaChecks.SelectedImageIndex = 0;
            this.ListaChecks.Size = new System.Drawing.Size(238, 331);
            this.ListaChecks.StateImageList = this.imageList1;
            this.ListaChecks.TabIndex = 0;
            this.ListaChecks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaChecks_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check.png");
            this.imageList1.Images.SetKeyName(1, "llaves.jpg");
            this.imageList1.Images.SetKeyName(2, "DIR02B.ICO");
            // 
            // TRegla
            // 
            this.TRegla.Location = new System.Drawing.Point(53, 60);
            this.TRegla.Multiline = true;
            this.TRegla.Name = "TRegla";
            this.TRegla.ReadOnly = true;
            this.TRegla.Size = new System.Drawing.Size(282, 72);
            this.TRegla.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Regla";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 16);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(177, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // CVisorChecks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CVisorChecks";
            this.Size = new System.Drawing.Size(625, 399);
            this.Load += new System.EventHandler(this.CVisorChecks_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregar;
        private System.Windows.Forms.ToolStripButton BEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTabla;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView ListaChecks;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox TRegla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
    }
}
