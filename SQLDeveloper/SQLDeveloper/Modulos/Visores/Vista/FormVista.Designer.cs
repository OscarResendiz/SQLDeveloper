namespace SQLDeveloper.Modulos.Visores.Vista
{
    partial class FormVista
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVista));
            this.dataSet1 = new System.Data.DataSet();
            this.Campos = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BDependencias = new System.Windows.Forms.ToolStripButton();
            this.BCodigo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Btrrigers = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn13 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn14 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn15 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn16 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn17 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn18 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn19 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn20 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.Campos,
            this.dataTable1});
            // 
            // Campos
            // 
            this.Campos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.Campos.TableName = "Campos";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "";
            this.dataColumn1.ColumnName = "PK";
            this.dataColumn1.DataType = typeof(object);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Campo";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Tipo";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Acepta Nulos";
            this.dataColumn4.ColumnName = "Nulos";
            this.dataColumn4.DataType = typeof(object);
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6});
            this.dataTable1.TableName = "PropiedadesCampo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Atributo";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Valor";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 41);
            this.panel1.TabIndex = 0;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 9);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(171, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TNombre_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campo,
            this.tipoDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Campos";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.Size = new System.Drawing.Size(309, 425);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // Campo
            // 
            this.Campo.DataPropertyName = "Campo";
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            this.Campo.ReadOnly = true;
            this.Campo.Width = 150;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PK.ico");
            this.imageList1.Images.SetKeyName(1, "FK.ico");
            this.imageList1.Images.SetKeyName(2, "FKPK.ico");
            this.imageList1.Images.SetKeyName(3, "ImagenVacia.png");
            this.imageList1.Images.SetKeyName(4, "Tips.png");
            this.imageList1.Images.SetKeyName(5, "identidad.png");
            this.imageList1.Images.SetKeyName(6, "IdentidadPk.png");
            this.imageList1.Images.SetKeyName(7, "IdentidadFK.png");
            this.imageList1.Images.SetKeyName(8, "IdentidadFKPk.png");
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "PK";
            this.dataGridViewImageColumn1.HeaderText = "PK";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn2.HeaderText = "Nulos";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BDependencias,
            this.BCodigo,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.Btrrigers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(309, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BDependencias
            // 
            this.BDependencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDependencias.Image = ((System.Drawing.Image)(resources.GetObject("BDependencias.Image")));
            this.BDependencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDependencias.Name = "BDependencias";
            this.BDependencias.Size = new System.Drawing.Size(23, 22);
            this.BDependencias.Text = "Buscar Dependencias";
            this.BDependencias.Click += new System.EventHandler(this.BDependencias_Click);
            // 
            // BCodigo
            // 
            this.BCodigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCodigo.Image = ((System.Drawing.Image)(resources.GetObject("BCodigo.Image")));
            this.BCodigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCodigo.Name = "BCodigo";
            this.BCodigo.Size = new System.Drawing.Size(23, 22);
            this.BCodigo.Text = "Ver codigo";
            this.BCodigo.Click += new System.EventHandler(this.BCodigo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Btrrigers
            // 
            this.Btrrigers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btrrigers.Image = ((System.Drawing.Image)(resources.GetObject("Btrrigers.Image")));
            this.Btrrigers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btrrigers.Name = "Btrrigers";
            this.Btrrigers.Size = new System.Drawing.Size(23, 22);
            this.Btrrigers.Text = "Administrar Triggers";
            this.Btrrigers.Click += new System.EventHandler(this.Btrrigers_Click);
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "PK";
            this.dataGridViewImageColumn3.HeaderText = "PK";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 50;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn4.HeaderText = "Nulos";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn4.Width = 50;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = "PK";
            this.dataGridViewImageColumn5.HeaderText = "PK";
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.ReadOnly = true;
            this.dataGridViewImageColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn5.Width = 50;
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn6.HeaderText = "Nulos";
            this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            this.dataGridViewImageColumn6.ReadOnly = true;
            this.dataGridViewImageColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn6.Width = 50;
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.DataPropertyName = "PK";
            this.dataGridViewImageColumn7.HeaderText = "PK";
            this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            this.dataGridViewImageColumn7.ReadOnly = true;
            this.dataGridViewImageColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn7.Width = 50;
            // 
            // dataGridViewImageColumn8
            // 
            this.dataGridViewImageColumn8.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn8.HeaderText = "Nulos";
            this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
            this.dataGridViewImageColumn8.ReadOnly = true;
            this.dataGridViewImageColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn8.Width = 50;
            // 
            // dataGridViewImageColumn9
            // 
            this.dataGridViewImageColumn9.DataPropertyName = "PK";
            this.dataGridViewImageColumn9.HeaderText = "PK";
            this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
            this.dataGridViewImageColumn9.ReadOnly = true;
            this.dataGridViewImageColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn9.Width = 50;
            // 
            // dataGridViewImageColumn10
            // 
            this.dataGridViewImageColumn10.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn10.HeaderText = "Nulos";
            this.dataGridViewImageColumn10.Name = "dataGridViewImageColumn10";
            this.dataGridViewImageColumn10.ReadOnly = true;
            this.dataGridViewImageColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn10.Width = 50;
            // 
            // dataGridViewImageColumn11
            // 
            this.dataGridViewImageColumn11.DataPropertyName = "PK";
            this.dataGridViewImageColumn11.HeaderText = "PK";
            this.dataGridViewImageColumn11.Name = "dataGridViewImageColumn11";
            this.dataGridViewImageColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn11.Width = 50;
            // 
            // dataGridViewImageColumn12
            // 
            this.dataGridViewImageColumn12.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn12.HeaderText = "Nulos";
            this.dataGridViewImageColumn12.Name = "dataGridViewImageColumn12";
            this.dataGridViewImageColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn12.Width = 50;
            // 
            // dataGridViewImageColumn13
            // 
            this.dataGridViewImageColumn13.DataPropertyName = "PK";
            this.dataGridViewImageColumn13.HeaderText = "PK";
            this.dataGridViewImageColumn13.Name = "dataGridViewImageColumn13";
            this.dataGridViewImageColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn13.Width = 50;
            // 
            // dataGridViewImageColumn14
            // 
            this.dataGridViewImageColumn14.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn14.HeaderText = "Nulos";
            this.dataGridViewImageColumn14.Name = "dataGridViewImageColumn14";
            this.dataGridViewImageColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn14.Width = 50;
            // 
            // dataGridViewImageColumn15
            // 
            this.dataGridViewImageColumn15.DataPropertyName = "PK";
            this.dataGridViewImageColumn15.HeaderText = "PK";
            this.dataGridViewImageColumn15.Name = "dataGridViewImageColumn15";
            this.dataGridViewImageColumn15.ReadOnly = true;
            this.dataGridViewImageColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn15.Width = 50;
            // 
            // dataGridViewImageColumn16
            // 
            this.dataGridViewImageColumn16.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn16.HeaderText = "Nulos";
            this.dataGridViewImageColumn16.Name = "dataGridViewImageColumn16";
            this.dataGridViewImageColumn16.ReadOnly = true;
            this.dataGridViewImageColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn16.Width = 50;
            // 
            // dataGridViewImageColumn17
            // 
            this.dataGridViewImageColumn17.DataPropertyName = "PK";
            this.dataGridViewImageColumn17.HeaderText = "PK";
            this.dataGridViewImageColumn17.Name = "dataGridViewImageColumn17";
            this.dataGridViewImageColumn17.ReadOnly = true;
            this.dataGridViewImageColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn17.Width = 50;
            // 
            // dataGridViewImageColumn18
            // 
            this.dataGridViewImageColumn18.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn18.HeaderText = "Nulos";
            this.dataGridViewImageColumn18.Name = "dataGridViewImageColumn18";
            this.dataGridViewImageColumn18.ReadOnly = true;
            this.dataGridViewImageColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn18.Width = 50;
            // 
            // dataGridViewImageColumn19
            // 
            this.dataGridViewImageColumn19.DataPropertyName = "PK";
            this.dataGridViewImageColumn19.HeaderText = "PK";
            this.dataGridViewImageColumn19.Name = "dataGridViewImageColumn19";
            this.dataGridViewImageColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn19.Width = 50;
            // 
            // dataGridViewImageColumn20
            // 
            this.dataGridViewImageColumn20.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn20.HeaderText = "Nulos";
            this.dataGridViewImageColumn20.Name = "dataGridViewImageColumn20";
            this.dataGridViewImageColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn20.Width = 50;
            // 
            // FormVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 491);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormVista";
            this.Text = "Vista";
            this.Load += new System.EventHandler(this.FormVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable Campos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BDependencias;
        private System.Windows.Forms.ToolStripButton BCodigo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn6;
        private System.Windows.Forms.ToolStripButton Btrrigers;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn8;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn9;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn10;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn11;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn12;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn13;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn14;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn15;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn16;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn17;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn18;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn19;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
    }
}