namespace SQLDeveloper.Modulos.Visores.Tabla
{
    partial class FormForeignKeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForeignKeys));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListaFks = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.BEliminar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaFks);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(561, 430);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // ListaFks
            // 
            this.ListaFks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaFks.ImageIndex = 0;
            this.ListaFks.ImageList = this.imageList1;
            this.ListaFks.Location = new System.Drawing.Point(0, 0);
            this.ListaFks.Name = "ListaFks";
            this.ListaFks.SelectedImageIndex = 0;
            this.ListaFks.Size = new System.Drawing.Size(221, 374);
            this.ListaFks.StateImageList = this.imageList1;
            this.ListaFks.TabIndex = 3;
            this.ListaFks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaFks_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FK.ico");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BEliminar);
            this.panel2.Controls.Add(this.BAgregar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 56);
            this.panel2.TabIndex = 2;
            // 
            // BEliminar
            // 
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(129, 9);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(84, 38);
            this.BEliminar.TabIndex = 1;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(6, 9);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(84, 38);
            this.BAgregar.TabIndex = 0;
            this.BAgregar.Text = "Agregar";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(336, 253);
            this.dataGridView1.TabIndex = 4;
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
            this.panel5.Size = new System.Drawing.Size(336, 87);
            this.panel5.TabIndex = 5;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 374);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(336, 56);
            this.panel4.TabIndex = 3;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(237, 9);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(87, 38);
            this.BCerrar.TabIndex = 0;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TNombre);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 34);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre";
            // 
            // FormForeignKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 430);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForeignKeys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOREIGN KEYS";
            this.Load += new System.EventHandler(this.FormForeignKeys_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPadreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaHijaDataGridViewTextBoxColumn;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView ListaFks;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox TActualizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBorrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TTablaPadre;
    }
}