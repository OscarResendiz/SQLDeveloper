namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormImportarCampos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportarCampos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BAceptar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTablas = new System.Windows.Forms.Button();
            this.ComboTablas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataSet1 = new System.Data.DataSet();
            this.Campos = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nulosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 56);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCancelar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(277, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(111, 56);
            this.panel4.TabIndex = 3;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(12, 6);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(87, 42);
            this.BCancelar.TabIndex = 0;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(102, 56);
            this.panel3.TabIndex = 2;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(12, 6);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(87, 42);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTablas);
            this.panel2.Controls.Add(this.ComboTablas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 54);
            this.panel2.TabIndex = 1;
            // 
            // BTablas
            // 
            this.BTablas.Image = ((System.Drawing.Image)(resources.GetObject("BTablas.Image")));
            this.BTablas.Location = new System.Drawing.Point(276, 3);
            this.BTablas.Name = "BTablas";
            this.BTablas.Size = new System.Drawing.Size(51, 44);
            this.BTablas.TabIndex = 5;
            this.BTablas.Tag = "Buscar Tablas";
            this.BTablas.UseVisualStyleBackColor = true;
            this.BTablas.Click += new System.EventHandler(this.BTablas_Click);
            // 
            // ComboTablas
            // 
            this.ComboTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTablas.FormattingEnabled = true;
            this.ComboTablas.Location = new System.Drawing.Point(52, 17);
            this.ComboTablas.Name = "ComboTablas";
            this.ComboTablas.Size = new System.Drawing.Size(218, 21);
            this.ComboTablas.TabIndex = 1;
            this.ComboTablas.SelectedIndexChanged += new System.EventHandler(this.ComboTablas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla";
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
            this.dataColumn4,
            this.dataColumn7});
            this.Campos.TableName = "Campos";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Campo";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Tipo";
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.pKDataGridViewTextBoxColumn,
            this.Campo,
            this.tipoDataGridViewTextBoxColumn,
            this.nulosDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Campos";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.Size = new System.Drawing.Size(388, 312);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Seleccionado";
            this.dataColumn7.DataType = typeof(bool);
            this.dataColumn7.DefaultValue = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "PK";
            this.dataGridViewImageColumn1.HeaderText = "PK";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Nulos";
            this.dataGridViewImageColumn2.HeaderText = "Nulos";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "";
            this.dataColumn1.ColumnName = "PK";
            this.dataColumn1.DataType = typeof(object);
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Acepta Nulos";
            this.dataColumn4.ColumnName = "Nulos";
            this.dataColumn4.DataType = typeof(object);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "Seleccionado";
            this.Seleccionado.Name = "Seleccionado";
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
            // FormImportarCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 422);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImportarCampos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar desde otra tabla";
            this.Load += new System.EventHandler(this.FormImportarCampos_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Campos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ComboTablas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTablas;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable Campos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataColumn dataColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewImageColumn pKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn nulosDataGridViewTextBoxColumn;
    }
}