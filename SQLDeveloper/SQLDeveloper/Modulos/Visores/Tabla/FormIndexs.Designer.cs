namespace SQLDeveloper.Modulos.Visores.Tabla
{
    partial class FormIndexs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIndexs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTabla = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Bagregar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListaIndexes = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.campoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTabla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 43);
            this.panel1.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 58);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(548, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(109, 58);
            this.panel4.TabIndex = 4;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(11, 6);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(86, 43);
            this.BCerrar.TabIndex = 2;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Bagregar);
            this.panel3.Controls.Add(this.BEliminar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 58);
            this.panel3.TabIndex = 3;
            // 
            // Bagregar
            // 
            this.Bagregar.Image = ((System.Drawing.Image)(resources.GetObject("Bagregar.Image")));
            this.Bagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bagregar.Location = new System.Drawing.Point(12, 6);
            this.Bagregar.Name = "Bagregar";
            this.Bagregar.Size = new System.Drawing.Size(86, 43);
            this.Bagregar.TabIndex = 0;
            this.Bagregar.Text = "Agregar";
            this.Bagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bagregar.UseVisualStyleBackColor = true;
            this.Bagregar.Click += new System.EventHandler(this.Bagregar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(133, 6);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(86, 43);
            this.BEliminar.TabIndex = 1;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaIndexes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(657, 345);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 2;
            // 
            // ListaIndexes
            // 
            this.ListaIndexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaIndexes.ImageIndex = 0;
            this.ListaIndexes.ImageList = this.imageList1;
            this.ListaIndexes.Location = new System.Drawing.Point(0, 0);
            this.ListaIndexes.Name = "ListaIndexes";
            this.ListaIndexes.SelectedImageIndex = 0;
            this.ListaIndexes.Size = new System.Drawing.Size(219, 345);
            this.ListaIndexes.StateImageList = this.imageList1;
            this.ListaIndexes.TabIndex = 0;
            this.ListaIndexes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaIndexes_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "llaves.jpg");
            this.imageList1.Images.SetKeyName(1, "DIR02B.ICO");
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
            this.dataGridView1.Size = new System.Drawing.Size(434, 345);
            this.dataGridView1.TabIndex = 0;
            // 
            // campoDataGridViewTextBoxColumn
            // 
            this.campoDataGridViewTextBoxColumn.DataPropertyName = "Campo";
            this.campoDataGridViewTextBoxColumn.HeaderText = "Campo";
            this.campoDataGridViewTextBoxColumn.Name = "campoDataGridViewTextBoxColumn";
            this.campoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenamientoDataGridViewTextBoxColumn
            // 
            this.ordenamientoDataGridViewTextBoxColumn.DataPropertyName = "Ordenamiento";
            this.ordenamientoDataGridViewTextBoxColumn.HeaderText = "Ordenamiento";
            this.ordenamientoDataGridViewTextBoxColumn.Name = "ordenamientoDataGridViewTextBoxColumn";
            this.ordenamientoDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "Campos";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Campo";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Tipo";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Ordenamiento";
            // 
            // FormIndexs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 446);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormIndexs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexs";
            this.Load += new System.EventHandler(this.FormIndexs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LTabla;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button Bagregar;
        private System.Windows.Forms.TreeView ListaIndexes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn campoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenamientoDataGridViewTextBoxColumn;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
    }
}