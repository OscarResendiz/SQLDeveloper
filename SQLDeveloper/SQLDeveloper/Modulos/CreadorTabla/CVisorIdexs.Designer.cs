namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class CVisorIdexs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CVisorIdexs));
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.ordenamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ListaIndexes = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LTabla = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BAgregar = new System.Windows.Forms.ToolStripButton();
            this.BEliminar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Ordenamiento";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Campo";
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "Campos";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Tipo";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // ordenamientoDataGridViewTextBoxColumn
            // 
            this.ordenamientoDataGridViewTextBoxColumn.DataPropertyName = "Ordenamiento";
            this.ordenamientoDataGridViewTextBoxColumn.HeaderText = "Ordenamiento";
            this.ordenamientoDataGridViewTextBoxColumn.Name = "ordenamientoDataGridViewTextBoxColumn";
            this.ordenamientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // campoDataGridViewTextBoxColumn
            // 
            this.campoDataGridViewTextBoxColumn.DataPropertyName = "Campo";
            this.campoDataGridViewTextBoxColumn.HeaderText = "Campo";
            this.campoDataGridViewTextBoxColumn.Name = "campoDataGridViewTextBoxColumn";
            this.campoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.campoDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.ordenamientoDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Campos";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(452, 389);
            this.dataGridView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "llaves.jpg");
            this.imageList1.Images.SetKeyName(1, "DIR02B.ICO");
            // 
            // ListaIndexes
            // 
            this.ListaIndexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaIndexes.ImageIndex = 0;
            this.ListaIndexes.ImageList = this.imageList1;
            this.ListaIndexes.Location = new System.Drawing.Point(0, 0);
            this.ListaIndexes.Name = "ListaIndexes";
            this.ListaIndexes.SelectedImageIndex = 0;
            this.ListaIndexes.Size = new System.Drawing.Size(228, 389);
            this.ListaIndexes.StateImageList = this.imageList1;
            this.ListaIndexes.TabIndex = 0;
            this.ListaIndexes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaIndexes_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaIndexes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(684, 389);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 5;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.LTabla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 43);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregar,
            this.BEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 25);
            this.toolStrip1.TabIndex = 6;
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
            // VisorIdexs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VisorIdexs";
            this.Size = new System.Drawing.Size(684, 457);
            this.Load += new System.EventHandler(this.VisorIdexs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn campoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView ListaIndexes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LTabla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregar;
        private System.Windows.Forms.ToolStripButton BEliminar;
    }
}
