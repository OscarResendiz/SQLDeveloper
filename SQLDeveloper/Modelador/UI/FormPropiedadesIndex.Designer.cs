namespace Modelador.UI
{
    partial class FormPropiedadesIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropiedadesIndex));
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable3 = new System.Data.DataTable();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BCancelar = new System.Windows.Forms.Button();
            this.Baceptar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CHPrimaryKey = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CkGenFuncion = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ChMultiplesObjetos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Ordenamiento";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Campo";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Campo"}, false)});
            this.dataTable2.TableName = "CamposTabla";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Seleccionado";
            this.dataColumn5.DataType = typeof(bool);
            this.dataColumn5.DefaultValue = false;
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Ordenamiento";
            this.dataColumn2.DefaultValue = "Acendente";
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
            this.dataColumn5});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "Ordenamiento", new string[] {
                        "Ordenamiento"}, new string[] {
                        "Ordenamiento"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("Relation2", "CamposTabla", new string[] {
                        "Campo"}, new string[] {
                        "Campo"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.TableName = "CamposIndex";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "Ordenamiento", "CamposIndex", new string[] {
                        "Ordenamiento"}, new string[] {
                        "Ordenamiento"}, false),
            new System.Data.DataRelation("Relation2", "CamposTabla", "CamposIndex", new string[] {
                        "Campo"}, new string[] {
                        "Campo"}, false)});
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3});
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4});
            this.dataTable3.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Ordenamiento"}, false)});
            this.dataTable3.TableName = "Ordenamiento";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ordenamiento";
            this.dataGridViewTextBoxColumn2.DataSource = this.dataSet1;
            this.dataGridViewTextBoxColumn2.DisplayMember = "Ordenamiento.Ordenamiento";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ordenamiento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ValueMember = "Ordenamiento.Ordenamiento";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Campo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Campo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            this.Seleccionado.Width = 30;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(256, 7);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 44);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // Baceptar
            // 
            this.Baceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Baceptar.Image = ((System.Drawing.Image)(resources.GetObject("Baceptar.Image")));
            this.Baceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Baceptar.Location = new System.Drawing.Point(15, 6);
            this.Baceptar.Name = "Baceptar";
            this.Baceptar.Size = new System.Drawing.Size(90, 47);
            this.Baceptar.TabIndex = 0;
            this.Baceptar.Text = "Aceptar";
            this.Baceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Baceptar.UseVisualStyleBackColor = true;
            this.Baceptar.Click += new System.EventHandler(this.Baceptar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.Baceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 56);
            this.panel2.TabIndex = 4;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 9);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(321, 20);
            this.TNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // CHPrimaryKey
            // 
            this.CHPrimaryKey.AutoSize = true;
            this.CHPrimaryKey.Location = new System.Drawing.Point(293, 35);
            this.CHPrimaryKey.Name = "CHPrimaryKey";
            this.CHPrimaryKey.Size = new System.Drawing.Size(81, 17);
            this.CHPrimaryKey.TabIndex = 2;
            this.CHPrimaryKey.Text = "Primary Key";
            this.CHPrimaryKey.UseVisualStyleBackColor = true;
            this.CHPrimaryKey.CheckedChanged += new System.EventHandler(this.CHPrimaryKey_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChMultiplesObjetos);
            this.panel1.Controls.Add(this.CkGenFuncion);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CHPrimaryKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 67);
            this.panel1.TabIndex = 3;
            // 
            // CkGenFuncion
            // 
            this.CkGenFuncion.AutoSize = true;
            this.CkGenFuncion.Location = new System.Drawing.Point(6, 35);
            this.CkGenFuncion.Name = "CkGenFuncion";
            this.CkGenFuncion.Size = new System.Drawing.Size(102, 17);
            this.CkGenFuncion.TabIndex = 5;
            this.CkGenFuncion.Text = "GenerarFuncion";
            this.CkGenFuncion.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.DataMember = "CamposIndex";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(386, 327);
            this.dataGridView1.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChMultiplesObjetos
            // 
            this.ChMultiplesObjetos.AutoSize = true;
            this.ChMultiplesObjetos.Location = new System.Drawing.Point(114, 35);
            this.ChMultiplesObjetos.Name = "ChMultiplesObjetos";
            this.ChMultiplesObjetos.Size = new System.Drawing.Size(149, 17);
            this.ChMultiplesObjetos.TabIndex = 6;
            this.ChMultiplesObjetos.Text = "Regresar multiples objetos";
            this.ChMultiplesObjetos.UseVisualStyleBackColor = true;
            // 
            // FormPropiedadesIndex
            // 
            this.AcceptButton = this.Baceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(386, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPropiedadesIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del indice";
            this.Load += new System.EventHandler(this.FormPropiedadesIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button Baceptar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CHPrimaryKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CkGenFuncion;
        private System.Windows.Forms.CheckBox ChMultiplesObjetos;
    }
}