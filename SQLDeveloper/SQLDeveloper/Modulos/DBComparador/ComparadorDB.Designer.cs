namespace SQLDeveloper.Modulos.DBComparador
{
    partial class ComparadorDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparadorDB));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.izquierdoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.derechoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDiferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.TimerEnable = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.BKComparar = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BComparar = new System.Windows.Forms.Button();
            this.ComboVer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboConexion2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboGrupo2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.izquierdoDataGridViewTextBoxColumn,
            this.derechoDataGridViewTextBoxColumn,
            this.tipoDiferenciaDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Resultado";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(295, 256);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // izquierdoDataGridViewTextBoxColumn
            // 
            this.izquierdoDataGridViewTextBoxColumn.DataPropertyName = "Izquierdo";
            this.izquierdoDataGridViewTextBoxColumn.HeaderText = "Izquierdo";
            this.izquierdoDataGridViewTextBoxColumn.Name = "izquierdoDataGridViewTextBoxColumn";
            this.izquierdoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // derechoDataGridViewTextBoxColumn
            // 
            this.derechoDataGridViewTextBoxColumn.DataPropertyName = "Derecho";
            this.derechoDataGridViewTextBoxColumn.HeaderText = "Derecho";
            this.derechoDataGridViewTextBoxColumn.Name = "derechoDataGridViewTextBoxColumn";
            this.derechoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDiferenciaDataGridViewTextBoxColumn
            // 
            this.tipoDiferenciaDataGridViewTextBoxColumn.DataPropertyName = "TipoDiferencia";
            this.tipoDiferenciaDataGridViewTextBoxColumn.HeaderText = "TipoDiferencia";
            this.tipoDiferenciaDataGridViewTextBoxColumn.Name = "tipoDiferenciaDataGridViewTextBoxColumn";
            this.tipoDiferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDiferenciaDataGridViewTextBoxColumn.Visible = false;
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
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Resultado";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Izquierdo";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Derecho";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "TipoDiferencia";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "CodigoIzquierdo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "CodigoDerecho";
            // 
            // TimerEnable
            // 
            this.TimerEnable.Enabled = true;
            this.TimerEnable.Interval = 300;
            this.TimerEnable.Tick += new System.EventHandler(this.TimerEnable_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Progreso,
            this.toolStripStatusLabel1,
            this.TStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Progreso
            // 
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // TStatus
            // 
            this.TStatus.ForeColor = System.Drawing.Color.Red;
            this.TStatus.Name = "TStatus";
            this.TStatus.Size = new System.Drawing.Size(39, 17);
            this.TStatus.Text = "Status";
            // 
            // BKComparar
            // 
            this.BKComparar.WorkerReportsProgress = true;
            this.BKComparar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKComparar_DoWork);
            this.BKComparar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKComparar_ProgressChanged);
            this.BKComparar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKComparar_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BComparar);
            this.panel1.Controls.Add(this.ComboVer);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ComboTipo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ComboConexion2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ComboGrupo2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 163);
            this.panel1.TabIndex = 4;
            // 
            // BComparar
            // 
            this.BComparar.Image = ((System.Drawing.Image)(resources.GetObject("BComparar.Image")));
            this.BComparar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BComparar.Location = new System.Drawing.Point(194, 16);
            this.BComparar.Name = "BComparar";
            this.BComparar.Size = new System.Drawing.Size(59, 50);
            this.BComparar.TabIndex = 8;
            this.BComparar.Text = "Analizar";
            this.BComparar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BComparar.UseVisualStyleBackColor = true;
            this.BComparar.Click += new System.EventHandler(this.BComparar_Click);
            // 
            // ComboVer
            // 
            this.ComboVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboVer.FormattingEnabled = true;
            this.ComboVer.Location = new System.Drawing.Point(31, 123);
            this.ComboVer.Name = "ComboVer";
            this.ComboVer.Size = new System.Drawing.Size(157, 21);
            this.ComboVer.TabIndex = 7;
            this.ComboVer.SelectedIndexChanged += new System.EventHandler(this.ComboVer_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ver";
            // 
            // ComboTipo
            // 
            this.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(3, 96);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(185, 21);
            this.ComboTipo.TabIndex = 5;
            this.ComboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_VisibleChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de objeto a comparar";
            // 
            // ComboConexion2
            // 
            this.ComboConexion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexion2.FormattingEnabled = true;
            this.ComboConexion2.Location = new System.Drawing.Point(3, 56);
            this.ComboConexion2.Name = "ComboConexion2";
            this.ComboConexion2.Size = new System.Drawing.Size(185, 21);
            this.ComboConexion2.TabIndex = 3;
            this.ComboConexion2.SelectedIndexChanged += new System.EventHandler(this.ComboConexion2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base de datos a comparar";
            // 
            // ComboGrupo2
            // 
            this.ComboGrupo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupo2.FormattingEnabled = true;
            this.ComboGrupo2.Location = new System.Drawing.Point(3, 16);
            this.ComboGrupo2.Name = "ComboGrupo2";
            this.ComboGrupo2.Size = new System.Drawing.Size(185, 21);
            this.ComboGrupo2.TabIndex = 1;
            this.ComboGrupo2.SelectedIndexChanged += new System.EventHandler(this.ComboGrupo_IndexCahnge);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo";
            // 
            // ComparadorDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 441);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ComparadorDB";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn izquierdoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn derechoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDiferenciaDataGridViewTextBoxColumn;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Timer TimerEnable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar Progreso;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TStatus;
        private System.ComponentModel.BackgroundWorker BKComparar;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboConexion2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboGrupo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BComparar;

    }
}