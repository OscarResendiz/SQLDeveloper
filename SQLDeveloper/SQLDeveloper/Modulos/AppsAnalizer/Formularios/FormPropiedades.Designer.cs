namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    partial class FormPropiedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropiedades));
            this.label1 = new System.Windows.Forms.Label();
            this.TRuta = new System.Windows.Forms.TextBox();
            this.modeloConexiones1 = new ManagerConnect.ModeloConexiones();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BRuta = new System.Windows.Forms.Button();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LConexiones = new System.Windows.Forms.TreeView();
            this.TStatus = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BProbarConexiones = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BEliminarExtencion = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.LExtenciones = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TExtencion = new System.Windows.Forms.TextBox();
            this.BAgregarExtencion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BackConexiones = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.modeloConexiones1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta";
            // 
            // TRuta
            // 
            this.TRuta.Location = new System.Drawing.Point(48, 39);
            this.TRuta.Name = "TRuta";
            this.TRuta.Size = new System.Drawing.Size(420, 20);
            this.TRuta.TabIndex = 1;
            // 
            // modeloConexiones1
            // 
            this.modeloConexiones1.DataSetName = "ModeloConexiones";
            this.modeloConexiones1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BRuta);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TRuta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 80);
            this.panel1.TabIndex = 3;
            // 
            // BRuta
            // 
            this.BRuta.Location = new System.Drawing.Point(474, 39);
            this.BRuta.Name = "BRuta";
            this.BRuta.Size = new System.Drawing.Size(48, 23);
            this.BRuta.TabIndex = 4;
            this.BRuta.Text = "...";
            this.BRuta.UseVisualStyleBackColor = true;
            this.BRuta.Click += new System.EventHandler(this.BRuta_Click);
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(127, 13);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(395, 20);
            this.TNombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre del proyecto";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 53);
            this.panel2.TabIndex = 4;
            // 
            // BAceptar
            // 
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(19, 6);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(86, 38);
            this.BAceptar.TabIndex = 1;
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
            this.BCancelar.Location = new System.Drawing.Point(424, 8);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(86, 35);
            this.BCancelar.TabIndex = 0;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 416);
            this.panel3.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LConexiones);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TStatus);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Size = new System.Drawing.Size(520, 387);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 3;
            // 
            // LConexiones
            // 
            this.LConexiones.CheckBoxes = true;
            this.LConexiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LConexiones.LabelEdit = true;
            this.LConexiones.Location = new System.Drawing.Point(0, 0);
            this.LConexiones.Name = "LConexiones";
            this.LConexiones.Size = new System.Drawing.Size(520, 193);
            this.LConexiones.TabIndex = 3;
            this.LConexiones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.LConexiones_AfterCheck_1);
            // 
            // TStatus
            // 
            this.TStatus.BackColor = System.Drawing.Color.Black;
            this.TStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TStatus.ForeColor = System.Drawing.Color.GreenYellow;
            this.TStatus.Location = new System.Drawing.Point(0, 0);
            this.TStatus.Multiline = true;
            this.TStatus.Name = "TStatus";
            this.TStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TStatus.Size = new System.Drawing.Size(520, 164);
            this.TStatus.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 164);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(520, 26);
            this.progressBar1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BProbarConexiones);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(520, 29);
            this.panel4.TabIndex = 0;
            // 
            // BProbarConexiones
            // 
            this.BProbarConexiones.Location = new System.Drawing.Point(100, 1);
            this.BProbarConexiones.Name = "BProbarConexiones";
            this.BProbarConexiones.Size = new System.Drawing.Size(114, 23);
            this.BProbarConexiones.TabIndex = 1;
            this.BProbarConexiones.Text = "Probar conexiones";
            this.BProbarConexiones.UseVisualStyleBackColor = true;
            this.BProbarConexiones.Click += new System.EventHandler(this.BProbarConexiones_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Conexiones";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BEliminarExtencion);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(520, 416);
            this.panel5.TabIndex = 6;
            // 
            // BEliminarExtencion
            // 
            this.BEliminarExtencion.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarExtencion.Image")));
            this.BEliminarExtencion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminarExtencion.Location = new System.Drawing.Point(206, 62);
            this.BEliminarExtencion.Name = "BEliminarExtencion";
            this.BEliminarExtencion.Size = new System.Drawing.Size(86, 41);
            this.BEliminarExtencion.TabIndex = 3;
            this.BEliminarExtencion.Text = "Eliminar";
            this.BEliminarExtencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminarExtencion.UseVisualStyleBackColor = true;
            this.BEliminarExtencion.Click += new System.EventHandler(this.BEliminarExtencion_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.LExtenciones);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 46);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 370);
            this.panel7.TabIndex = 1;
            // 
            // LExtenciones
            // 
            this.LExtenciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LExtenciones.FormattingEnabled = true;
            this.LExtenciones.Location = new System.Drawing.Point(0, 0);
            this.LExtenciones.Name = "LExtenciones";
            this.LExtenciones.Size = new System.Drawing.Size(200, 370);
            this.LExtenciones.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.TExtencion);
            this.panel6.Controls.Add(this.BAgregarExtencion);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(520, 46);
            this.panel6.TabIndex = 0;
            // 
            // TExtencion
            // 
            this.TExtencion.Location = new System.Drawing.Point(77, 9);
            this.TExtencion.Name = "TExtencion";
            this.TExtencion.Size = new System.Drawing.Size(120, 20);
            this.TExtencion.TabIndex = 1;
            // 
            // BAgregarExtencion
            // 
            this.BAgregarExtencion.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarExtencion.Image")));
            this.BAgregarExtencion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregarExtencion.Location = new System.Drawing.Point(203, 3);
            this.BAgregarExtencion.Name = "BAgregarExtencion";
            this.BAgregarExtencion.Size = new System.Drawing.Size(89, 40);
            this.BAgregarExtencion.TabIndex = 2;
            this.BAgregarExtencion.Text = "Agregar";
            this.BAgregarExtencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregarExtencion.UseVisualStyleBackColor = true;
            this.BAgregarExtencion.Click += new System.EventHandler(this.BAgregarExtencion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Extenciones";
            // 
            // BackConexiones
            // 
            this.BackConexiones.WorkerReportsProgress = true;
            this.BackConexiones.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackConexiones_DoWork);
            this.BackConexiones.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackConexiones_ProgressChanged);
            this.BackConexiones.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackConexiones_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 448);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conexiones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Extenciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(534, 581);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPropiedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades";
            this.Load += new System.EventHandler(this.FormPropiedades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modeloConexiones1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TRuta;
        private ManagerConnect.ModeloConexiones modeloConexiones1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BEliminarExtencion;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox LExtenciones;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox TExtencion;
        private System.Windows.Forms.Button BAgregarExtencion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BRuta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BProbarConexiones;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView LConexiones;
        private System.Windows.Forms.TextBox TStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker BackConexiones;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}   