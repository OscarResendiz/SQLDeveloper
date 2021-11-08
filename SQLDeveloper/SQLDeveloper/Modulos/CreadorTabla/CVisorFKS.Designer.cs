namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class CVisorFKS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CVisorFKS));
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TTablaPadre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TActualizar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBorrar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataSet1 = new System.Data.DataSet();
            this.columnaHijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaPadreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ListaFks = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Bagregar = new System.Windows.Forms.ToolStripButton();
            this.BEliminar = new System.Windows.Forms.ToolStripButton();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TNombre);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 34);
            this.panel3.TabIndex = 0;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(58, 8);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(266, 20);
            this.TNombre.TabIndex = 2;
            // 
            // TTablaPadre
            // 
            this.TTablaPadre.Location = new System.Drawing.Point(79, 6);
            this.TTablaPadre.Name = "TTablaPadre";
            this.TTablaPadre.ReadOnly = true;
            this.TTablaPadre.Size = new System.Drawing.Size(245, 20);
            this.TTablaPadre.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tabla Padre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Acciones Referenciales";
            // 
            // TActualizar
            // 
            this.TActualizar.Location = new System.Drawing.Point(224, 53);
            this.TActualizar.Name = "TActualizar";
            this.TActualizar.ReadOnly = true;
            this.TActualizar.Size = new System.Drawing.Size(100, 20);
            this.TActualizar.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Actualizar";
            // 
            // TBorrar
            // 
            this.TBorrar.Location = new System.Drawing.Point(57, 53);
            this.TBorrar.Name = "TBorrar";
            this.TBorrar.ReadOnly = true;
            this.TBorrar.Size = new System.Drawing.Size(100, 20);
            this.TBorrar.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Eliminar";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TTablaPadre);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.TActualizar);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.TBorrar);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(353, 87);
            this.panel5.TabIndex = 5;
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ColumnaHija";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ColumnaPadre";
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "Columnas";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // columnaHijaDataGridViewTextBoxColumn
            // 
            this.columnaHijaDataGridViewTextBoxColumn.DataPropertyName = "ColumnaHija";
            this.columnaHijaDataGridViewTextBoxColumn.HeaderText = "ColumnaHija";
            this.columnaHijaDataGridViewTextBoxColumn.Name = "columnaHijaDataGridViewTextBoxColumn";
            this.columnaHijaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnaPadreDataGridViewTextBoxColumn
            // 
            this.columnaPadreDataGridViewTextBoxColumn.DataPropertyName = "ColumnaPadre";
            this.columnaPadreDataGridViewTextBoxColumn.HeaderText = "ColumnaPadre";
            this.columnaPadreDataGridViewTextBoxColumn.Name = "columnaPadreDataGridViewTextBoxColumn";
            this.columnaPadreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaPadreDataGridViewTextBoxColumn,
            this.columnaHijaDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Columnas";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(353, 232);
            this.dataGridView1.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FK.ico");
            // 
            // ListaFks
            // 
            this.ListaFks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaFks.ImageIndex = 0;
            this.ListaFks.ImageList = this.imageList1;
            this.ListaFks.Location = new System.Drawing.Point(0, 0);
            this.ListaFks.Name = "ListaFks";
            this.ListaFks.SelectedImageIndex = 0;
            this.ListaFks.Size = new System.Drawing.Size(230, 353);
            this.ListaFks.StateImageList = this.imageList1;
            this.ListaFks.TabIndex = 3;
            this.ListaFks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaFks_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaFks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(587, 353);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bagregar,
            this.BEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(587, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Bagregar
            // 
            this.Bagregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bagregar.Image = ((System.Drawing.Image)(resources.GetObject("Bagregar.Image")));
            this.Bagregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bagregar.Name = "Bagregar";
            this.Bagregar.Size = new System.Drawing.Size(23, 22);
            this.Bagregar.Text = "Agregar";
            this.Bagregar.Click += new System.EventHandler(this.Bagregar_Click);
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
            // CVisorFKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CVisorFKS";
            this.Size = new System.Drawing.Size(587, 378);
            this.Load += new System.EventHandler(this.CVisorFKS_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TTablaPadre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TActualizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBorrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaHijaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPadreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView ListaFks;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Bagregar;
        private System.Windows.Forms.ToolStripButton BEliminar;
    }
}
