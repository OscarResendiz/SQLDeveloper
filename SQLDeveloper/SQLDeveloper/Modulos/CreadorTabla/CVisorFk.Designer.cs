namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class CVisorFk
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnaPadreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaHijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TTablaPadre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TActualizar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBorrar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(350, 151);
            this.dataGridView1.TabIndex = 7;
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
            this.columnaHijaDataGridViewTextBoxColumn.HeaderText = "ColumnaHija";
            this.columnaHijaDataGridViewTextBoxColumn.Name = "columnaHijaDataGridViewTextBoxColumn";
            this.columnaHijaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "Columnas";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ColumnaPadre";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ColumnaHija";
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
            this.panel5.Size = new System.Drawing.Size(350, 87);
            this.panel5.TabIndex = 8;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.TNombre);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 34);
            this.panel3.TabIndex = 6;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(58, 8);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(266, 20);
            this.TNombre.TabIndex = 2;
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
            // CVisorFk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "CVisorFk";
            this.Load += new System.EventHandler(this.CVisorFk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPadreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaHijaDataGridViewTextBoxColumn;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TTablaPadre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TActualizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBorrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label3;
    }
}
