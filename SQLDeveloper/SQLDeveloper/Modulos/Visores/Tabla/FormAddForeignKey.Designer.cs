namespace SQLDeveloper.Modulos.Visores.Tabla
{
    partial class FormAddForeignKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddForeignKey));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TTablaHija = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboTablas = new System.Windows.Forms.ComboBox();
            this.BTablas = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TForeignKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboDelete = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboUpdate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn3 = new System.Data.DataColumn();
            this.columnaPadreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaHijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TForeignKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BTablas);
            this.panel1.Controls.Add(this.ComboTablas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TTablaHija);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 108);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 60);
            this.panel2.TabIndex = 1;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AutoGenerateColumns = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaPadreDataGridViewTextBoxColumn,
            this.columnaHijaDataGridViewTextBoxColumn});
            this.Grid.DataMember = "Columnas";
            this.Grid.DataSource = this.dataSet1;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 189);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(390, 191);
            this.Grid.TabIndex = 2;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "TipoDato", "Columnas", new string[] {
                        "Tipo"}, new string[] {
                        "Tipo"}, false),
            new System.Data.DataRelation("Relation2", "TipoDato", "TablaHija", new string[] {
                        "Tipo"}, new string[] {
                        "Tipo"}, false)});
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn6});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "TipoDato", new string[] {
                        "Tipo"}, new string[] {
                        "Tipo"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.TableName = "Columnas";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ColumnaPadre";
            this.dataColumn1.ReadOnly = true;
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ColumnaHija";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla Hija";
            // 
            // TTablaHija
            // 
            this.TTablaHija.Location = new System.Drawing.Point(73, 15);
            this.TTablaHija.Name = "TTablaHija";
            this.TTablaHija.ReadOnly = true;
            this.TTablaHija.Size = new System.Drawing.Size(248, 20);
            this.TTablaHija.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tabla Padre";
            // 
            // ComboTablas
            // 
            this.ComboTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTablas.FormattingEnabled = true;
            this.ComboTablas.Location = new System.Drawing.Point(83, 45);
            this.ComboTablas.Name = "ComboTablas";
            this.ComboTablas.Size = new System.Drawing.Size(238, 21);
            this.ComboTablas.Sorted = true;
            this.ComboTablas.TabIndex = 3;
            this.ComboTablas.SelectedIndexChanged += new System.EventHandler(this.ComboTablas_SelectedIndexChanged);
            // 
            // BTablas
            // 
            this.BTablas.Image = ((System.Drawing.Image)(resources.GetObject("BTablas.Image")));
            this.BTablas.Location = new System.Drawing.Point(327, 35);
            this.BTablas.Name = "BTablas";
            this.BTablas.Size = new System.Drawing.Size(51, 44);
            this.BTablas.TabIndex = 4;
            this.BTablas.Tag = "Buscar Tablas";
            this.BTablas.UseVisualStyleBackColor = true;
            this.BTablas.Click += new System.EventHandler(this.BTablas_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(102, 60);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCancelar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(279, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(111, 60);
            this.panel4.TabIndex = 1;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre del FK";
            // 
            // TForeignKey
            // 
            this.TForeignKey.Location = new System.Drawing.Point(95, 72);
            this.TForeignKey.Name = "TForeignKey";
            this.TForeignKey.Size = new System.Drawing.Size(226, 20);
            this.TForeignKey.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Al Borrar Registros";
            // 
            // ComboDelete
            // 
            this.ComboDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDelete.FormattingEnabled = true;
            this.ComboDelete.Location = new System.Drawing.Point(12, 43);
            this.ComboDelete.Name = "ComboDelete";
            this.ComboDelete.Size = new System.Drawing.Size(159, 21);
            this.ComboDelete.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Al Actualizar Registros";
            // 
            // ComboUpdate
            // 
            this.ComboUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboUpdate.FormattingEnabled = true;
            this.ComboUpdate.Location = new System.Drawing.Point(189, 43);
            this.ComboUpdate.Name = "ComboUpdate";
            this.ComboUpdate.Size = new System.Drawing.Size(159, 21);
            this.ComboUpdate.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ComboUpdate);
            this.groupBox1.Controls.Add(this.ComboDelete);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 81);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones Referenciales";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3,
            this.dataColumn5});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation2", "TipoDato", new string[] {
                        "Tipo"}, new string[] {
                        "Tipo"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable2.TableName = "TablaHija";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Campo";
            // 
            // columnaPadreDataGridViewTextBoxColumn
            // 
            this.columnaPadreDataGridViewTextBoxColumn.DataPropertyName = "ColumnaPadre";
            this.columnaPadreDataGridViewTextBoxColumn.HeaderText = "ColumnaPadre";
            this.columnaPadreDataGridViewTextBoxColumn.Name = "columnaPadreDataGridViewTextBoxColumn";
            this.columnaPadreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnaHijaDataGridViewTextBoxColumn
            // 
            this.columnaHijaDataGridViewTextBoxColumn.DataPropertyName = "ColumnaHija";
            this.columnaHijaDataGridViewTextBoxColumn.DataSource = this.dataSet1;
            this.columnaHijaDataGridViewTextBoxColumn.DisplayMember = "TablaHija.Campo";
            this.columnaHijaDataGridViewTextBoxColumn.HeaderText = "ColumnaHija";
            this.columnaHijaDataGridViewTextBoxColumn.Name = "columnaHijaDataGridViewTextBoxColumn";
            this.columnaHijaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnaHijaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnaHijaDataGridViewTextBoxColumn.ValueMember = "TablaHija.Campo";
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4});
            this.dataTable3.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Tipo"}, false)});
            this.dataTable3.TableName = "TipoDato";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Tipo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Tipo";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Tipo";
            // 
            // FormAddForeignKey
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(390, 440);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddForeignKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar llave Foranea";
            this.Load += new System.EventHandler(this.FormAddForeignKey_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TextBox TForeignKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTablas;
        private System.Windows.Forms.ComboBox ComboTablas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TTablaHija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BAceptar;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPadreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnaHijaDataGridViewTextBoxColumn;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataTable dataTable3;
        private System.Data.DataColumn dataColumn4;
    }
}