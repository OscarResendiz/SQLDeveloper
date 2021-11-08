namespace GridControl
{
    partial class GriVisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GriVisor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BExportar = new System.Windows.Forms.ToolStripButton();
            this.BFiltrar = new System.Windows.Forms.ToolStripButton();
            this.BFiltoCampos = new System.Windows.Forms.ToolStripButton();
            this.BCalculadora = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.sIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LCopiar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LTabla = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BKExporter = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BExportar,
            this.BFiltrar,
            this.BFiltoCampos,
            this.BCalculadora,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.LCopiar,
            this.toolStripSeparator2,
            this.LTabla,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(625, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BExportar
            // 
            this.BExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BExportar.Image = ((System.Drawing.Image)(resources.GetObject("BExportar.Image")));
            this.BExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BExportar.Name = "BExportar";
            this.BExportar.Size = new System.Drawing.Size(23, 22);
            this.BExportar.Text = "Exportar";
            this.BExportar.Click += new System.EventHandler(this.BExportar_Click);
            // 
            // BFiltrar
            // 
            this.BFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("BFiltrar.Image")));
            this.BFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(23, 22);
            this.BFiltrar.Text = "Filtrar registros";
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // BFiltoCampos
            // 
            this.BFiltoCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BFiltoCampos.Image = ((System.Drawing.Image)(resources.GetObject("BFiltoCampos.Image")));
            this.BFiltoCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BFiltoCampos.Name = "BFiltoCampos";
            this.BFiltoCampos.Size = new System.Drawing.Size(23, 22);
            this.BFiltoCampos.Text = "Seleccionar Columnas";
            this.BFiltoCampos.Click += new System.EventHandler(this.BFiltoCampos_Click);
            // 
            // BCalculadora
            // 
            this.BCalculadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("BCalculadora.Image")));
            this.BCalculadora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCalculadora.Name = "BCalculadora";
            this.BCalculadora.Size = new System.Drawing.Size(23, 22);
            this.BCalculadora.Text = "Calculadora";
            this.BCalculadora.Click += new System.EventHandler(this.BCalculadora_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sIToolStripMenuItem,
            this.nOToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // sIToolStripMenuItem
            // 
            this.sIToolStripMenuItem.Name = "sIToolStripMenuItem";
            this.sIToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.sIToolStripMenuItem.Text = "SI";
            this.sIToolStripMenuItem.Click += new System.EventHandler(this.sIToolStripMenuItem_Click);
            // 
            // nOToolStripMenuItem
            // 
            this.nOToolStripMenuItem.Name = "nOToolStripMenuItem";
            this.nOToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.nOToolStripMenuItem.Text = "NO";
            this.nOToolStripMenuItem.Click += new System.EventHandler(this.nOToolStripMenuItem_Click);
            // 
            // LCopiar
            // 
            this.LCopiar.Name = "LCopiar";
            this.LCopiar.Size = new System.Drawing.Size(175, 22);
            this.LCopiar.Text = "NO Incluir columnas al compiar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // LTabla
            // 
            this.LTabla.Name = "LTabla";
            this.LTabla.Size = new System.Drawing.Size(78, 22);
            this.LTabla.Text = "Comentarios:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 23);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LRegistros,
            this.BarraProgreso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 210);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(625, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabel1.Text = "Numero de registros";
            // 
            // LRegistros
            // 
            this.LRegistros.Name = "LRegistros";
            this.LRegistros.Size = new System.Drawing.Size(13, 17);
            this.LRegistros.Text = "0";
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(100, 16);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 25);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.Size = new System.Drawing.Size(625, 185);
            this.Grid.TabIndex = 2;
            this.Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Grid_DataBindingComplete);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivo de excel|*.xls|Archivo separado por comas|*.csv|Archivo XML|*.xml";
            // 
            // BKExporter
            // 
            this.BKExporter.WorkerReportsProgress = true;
            this.BKExporter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKExporter_DoWork);
            this.BKExporter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKExporter_ProgressChanged);
            this.BKExporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKExporter_RunWorkerCompleted);
            // 
            // GriVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GriVisor";
            this.Size = new System.Drawing.Size(625, 232);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BExportar;
        private System.Windows.Forms.ToolStripButton BFiltrar;
        private System.Windows.Forms.ToolStripButton BFiltoCampos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LRegistros;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.ToolStripLabel LTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton BCalculadora;
        private System.Windows.Forms.ToolStripProgressBar BarraProgreso;
        private System.ComponentModel.BackgroundWorker BKExporter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem sIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel LCopiar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
