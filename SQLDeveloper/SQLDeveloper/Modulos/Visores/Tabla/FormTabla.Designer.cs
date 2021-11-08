namespace SQLDeveloper.Modulos.Visores.Tabla
{
    partial class FormTabla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTabla));
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
            this.pKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nulosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BDependencias = new System.Windows.Forms.ToolStripButton();
            this.BRelacion = new System.Windows.Forms.ToolStripButton();
            this.BCodigo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BSPInsert = new System.Windows.Forms.ToolStripButton();
            this.BSPUpdate = new System.Windows.Forms.ToolStripButton();
            this.BSPDelete = new System.Windows.Forms.ToolStripButton();
            this.BSPSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BAddFk = new System.Windows.Forms.ToolStripButton();
            this.Btrrigers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BUniques = new System.Windows.Forms.ToolStripButton();
            this.BotonChecks = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.BAgregarCampos = new System.Windows.Forms.ToolStripButton();
            this.BEliminarCampos = new System.Windows.Forms.ToolStripButton();
            this.BEditarCampos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
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
            this.dataGridViewImageColumn21 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn22 = new System.Windows.Forms.DataGridViewImageColumn();
            this.BKExtractor = new System.ComponentModel.BackgroundWorker();
            this.waitControl1 = new WaitControl.WaitControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.panel1.Controls.Add(this.waitControl1);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 47);
            this.panel1.TabIndex = 0;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 9);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(226, 20);
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
            this.tipoDataGridViewTextBoxColumn,
            this.pKDataGridViewTextBoxColumn,
            this.nulosDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Campos";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.Size = new System.Drawing.Size(309, 394);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.RowDividerDoubleClick += new System.Windows.Forms.DataGridViewRowDividerDoubleClickEventHandler(this.dataGridView1_RowDividerDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // Campo
            // 
            this.Campo.DataPropertyName = "Campo";
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            this.Campo.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Width = 80;
            // 
            // pKDataGridViewTextBoxColumn
            // 
            this.pKDataGridViewTextBoxColumn.DataPropertyName = "PK";
            this.pKDataGridViewTextBoxColumn.HeaderText = "PK";
            this.pKDataGridViewTextBoxColumn.Name = "pKDataGridViewTextBoxColumn";
            this.pKDataGridViewTextBoxColumn.ReadOnly = true;
            this.pKDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pKDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pKDataGridViewTextBoxColumn.Width = 50;
            // 
            // nulosDataGridViewTextBoxColumn
            // 
            this.nulosDataGridViewTextBoxColumn.DataPropertyName = "Nulos";
            this.nulosDataGridViewTextBoxColumn.HeaderText = "Nulos";
            this.nulosDataGridViewTextBoxColumn.Name = "nulosDataGridViewTextBoxColumn";
            this.nulosDataGridViewTextBoxColumn.ReadOnly = true;
            this.nulosDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nulosDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nulosDataGridViewTextBoxColumn.Width = 50;
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
            this.BRelacion,
            this.BCodigo,
            this.toolStripSeparator1,
            this.BSPInsert,
            this.BSPUpdate,
            this.BSPDelete,
            this.BSPSelect,
            this.toolStripSeparator2,
            this.BAddFk,
            this.Btrrigers,
            this.toolStripButton1,
            this.BUniques,
            this.BotonChecks});
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
            // BRelacion
            // 
            this.BRelacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BRelacion.Image = ((System.Drawing.Image)(resources.GetObject("BRelacion.Image")));
            this.BRelacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BRelacion.Name = "BRelacion";
            this.BRelacion.Size = new System.Drawing.Size(23, 22);
            this.BRelacion.Text = "Ver relacion de tablas";
            this.BRelacion.Click += new System.EventHandler(this.BRelacion_Click);
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
            // BSPInsert
            // 
            this.BSPInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSPInsert.Image = ((System.Drawing.Image)(resources.GetObject("BSPInsert.Image")));
            this.BSPInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSPInsert.Name = "BSPInsert";
            this.BSPInsert.Size = new System.Drawing.Size(23, 22);
            this.BSPInsert.Text = "Crear SP de inserción";
            // 
            // BSPUpdate
            // 
            this.BSPUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSPUpdate.Image = ((System.Drawing.Image)(resources.GetObject("BSPUpdate.Image")));
            this.BSPUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSPUpdate.Name = "BSPUpdate";
            this.BSPUpdate.Size = new System.Drawing.Size(23, 22);
            this.BSPUpdate.Text = "Crear SP de Actualizacion";
            // 
            // BSPDelete
            // 
            this.BSPDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSPDelete.Image = ((System.Drawing.Image)(resources.GetObject("BSPDelete.Image")));
            this.BSPDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSPDelete.Name = "BSPDelete";
            this.BSPDelete.Size = new System.Drawing.Size(23, 22);
            this.BSPDelete.Text = "Crear SP de Borrado";
            // 
            // BSPSelect
            // 
            this.BSPSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSPSelect.Image = ((System.Drawing.Image)(resources.GetObject("BSPSelect.Image")));
            this.BSPSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSPSelect.Name = "BSPSelect";
            this.BSPSelect.Size = new System.Drawing.Size(23, 22);
            this.BSPSelect.Text = "Crear SP de Seleccion";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BAddFk
            // 
            this.BAddFk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAddFk.Image = ((System.Drawing.Image)(resources.GetObject("BAddFk.Image")));
            this.BAddFk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAddFk.Name = "BAddFk";
            this.BAddFk.Size = new System.Drawing.Size(23, 22);
            this.BAddFk.Text = "Administrar FKs";
            this.BAddFk.Click += new System.EventHandler(this.BAddFk_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Indexs";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BUniques
            // 
            this.BUniques.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BUniques.Image = ((System.Drawing.Image)(resources.GetObject("BUniques.Image")));
            this.BUniques.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BUniques.Name = "BUniques";
            this.BUniques.Size = new System.Drawing.Size(23, 22);
            this.BUniques.Text = "Campos unicos";
            this.BUniques.Click += new System.EventHandler(this.BUniques_Click);
            // 
            // BotonChecks
            // 
            this.BotonChecks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotonChecks.Image = ((System.Drawing.Image)(resources.GetObject("BotonChecks.Image")));
            this.BotonChecks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotonChecks.Name = "BotonChecks";
            this.BotonChecks.Size = new System.Drawing.Size(23, 22);
            this.BotonChecks.Text = "Administrar Reglas (Checks)";
            this.BotonChecks.Click += new System.EventHandler(this.BotonChecks_Click);
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
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregarCampos,
            this.BEliminarCampos,
            this.BEditarCampos,
            this.toolStripSeparator3,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(309, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // BAgregarCampos
            // 
            this.BAgregarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregarCampos.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarCampos.Image")));
            this.BAgregarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregarCampos.Name = "BAgregarCampos";
            this.BAgregarCampos.Size = new System.Drawing.Size(23, 22);
            this.BAgregarCampos.Text = "Agregar campo";
            this.BAgregarCampos.Click += new System.EventHandler(this.BAgregarCampos_Click);
            // 
            // BEliminarCampos
            // 
            this.BEliminarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEliminarCampos.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarCampos.Image")));
            this.BEliminarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEliminarCampos.Name = "BEliminarCampos";
            this.BEliminarCampos.Size = new System.Drawing.Size(23, 22);
            this.BEliminarCampos.Text = "Eliminar Campos";
            this.BEliminarCampos.Click += new System.EventHandler(this.BEliminarCampos_Click);
            // 
            // BEditarCampos
            // 
            this.BEditarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEditarCampos.Image = ((System.Drawing.Image)(resources.GetObject("BEditarCampos.Image")));
            this.BEditarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEditarCampos.Name = "BEditarCampos";
            this.BEditarCampos.Size = new System.Drawing.Size(23, 22);
            this.BEditarCampos.Text = "Modificar Campo";
            this.BEditarCampos.Click += new System.EventHandler(this.BEditarCampos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Avanzado";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            // dataGridViewImageColumn21
            // 
            this.dataGridViewImageColumn21.DataPropertyName = "PK";
            this.dataGridViewImageColumn21.HeaderText = "PK";
            this.dataGridViewImageColumn21.Name = "dataGridViewImageColumn21";
            this.dataGridViewImageColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn21.Width = 50;
            // 
            // dataGridViewImageColumn22
            // 
            this.dataGridViewImageColumn22.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn22.HeaderText = "Nulos";
            this.dataGridViewImageColumn22.Name = "dataGridViewImageColumn22";
            this.dataGridViewImageColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn22.Width = 50;
            // 
            // BKExtractor
            // 
            this.BKExtractor.WorkerReportsProgress = true;
            this.BKExtractor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKExtractor_DoWork);
            this.BKExtractor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKExtractor_ProgressChanged);
            this.BKExtractor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKExtractor_RunWorkerCompleted);
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitControl1.Location = new System.Drawing.Point(0, 37);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(309, 10);
            this.waitControl1.TabIndex = 5;
            // 
            // FormTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 491);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormTabla";
            this.Text = "FormTabla";
            this.Load += new System.EventHandler(this.FormTabla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton BRelacion;
        private System.Windows.Forms.ToolStripButton BCodigo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BSPInsert;
        private System.Windows.Forms.ToolStripButton BSPUpdate;
        private System.Windows.Forms.ToolStripButton BSPDelete;
        private System.Windows.Forms.ToolStripButton BSPSelect;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BAddFk;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn6;
        private System.Windows.Forms.ToolStripButton Btrrigers;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn9;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton BAgregarCampos;
        private System.Windows.Forms.ToolStripButton BEliminarCampos;
        private System.Windows.Forms.ToolStripButton BEditarCampos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn11;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn12;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn13;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn14;
        private System.Windows.Forms.ToolStripButton BUniques;
        private System.Windows.Forms.ToolStripButton BotonChecks;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn15;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn16;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn17;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn18;
        private System.Windows.Forms.DataGridViewImageColumn pKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn nulosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn19;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn20;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn21;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn22;
        private System.ComponentModel.BackgroundWorker BKExtractor;
        private WaitControl.WaitControl waitControl1;
    }
}