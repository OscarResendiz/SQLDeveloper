namespace SQLDeveloper.Modulos.BuscadorTablas
{
    partial class FormBuscadorDependencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscadorDependencias));
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn4 = new System.Data.DataColumn();
            this.DataReporte = new System.Data.DataSet();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.BBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.waitControl1 = new WaitControl.WaitControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BExcluidos = new System.Windows.Forms.ToolStripButton();
            this.BGenerarReporte = new System.Windows.Forms.ToolStripButton();
            this.LResultado = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cConecionesManager1 = new ManagerConnect.CConecionesManager();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verCodigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarYResaltarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resaltarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desmarcarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarAExcluidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TimerLLena = new System.Windows.Forms.Timer(this.components);
            this.cBuscadorDependencias1 = new SQLDeveloper.Modulos.BuscadorDependencias.CBuscadorDependencias();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataReporte)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Objeto";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Base";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Servidor";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Origen";
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Tabla";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Padre";
            // 
            // DataReporte
            // 
            this.DataReporte.DataSetName = "NewDataSet";
            this.DataReporte.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(122, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(284, 19);
            this.miniToolStrip.TabIndex = 7;
            // 
            // BBuscar
            // 
            this.BBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(23, 22);
            this.BBuscar.Text = "Iniciar Busqueda";
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TBuscar
            // 
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Analizar";
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.waitControl1.Location = new System.Drawing.Point(0, 25);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(304, 10);
            this.waitControl1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.TBuscar,
            this.toolStripSeparator1,
            this.BBuscar,
            this.BExcluidos});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(304, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BExcluidos
            // 
            this.BExcluidos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BExcluidos.Image = ((System.Drawing.Image)(resources.GetObject("BExcluidos.Image")));
            this.BExcluidos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BExcluidos.Name = "BExcluidos";
            this.BExcluidos.Size = new System.Drawing.Size(23, 22);
            this.BExcluidos.Text = "Administrar Excluidos";
            this.BExcluidos.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BGenerarReporte
            // 
            this.BGenerarReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGenerarReporte.Image = ((System.Drawing.Image)(resources.GetObject("BGenerarReporte.Image")));
            this.BGenerarReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGenerarReporte.Name = "BGenerarReporte";
            this.BGenerarReporte.Size = new System.Drawing.Size(23, 22);
            this.BGenerarReporte.Text = "Generar Reporte";
            this.BGenerarReporte.Click += new System.EventHandler(this.BGenerarReporte_Click);
            // 
            // LResultado
            // 
            this.LResultado.Name = "LResultado";
            this.LResultado.Size = new System.Drawing.Size(59, 22);
            this.LResultado.Text = "Resultado";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LResultado,
            this.BGenerarReporte});
            this.toolStrip3.Location = new System.Drawing.Point(0, 35);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(304, 25);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cConecionesManager1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListaObjetos);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer1.Panel2.Controls.Add(this.waitControl1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(304, 509);
            this.splitContainer1.SplitterDistance = 92;
            this.splitContainer1.TabIndex = 6;
            // 
            // cConecionesManager1
            // 
            this.cConecionesManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cConecionesManager1.Location = new System.Drawing.Point(0, 25);
            this.cConecionesManager1.MotorInicial = null;
            this.cConecionesManager1.Name = "cConecionesManager1";
            this.cConecionesManager1.Size = new System.Drawing.Size(304, 67);
            this.cConecionesManager1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(304, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel2.Text = "Conexiones";
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.AllowDrop = true;
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList2;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 60);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.ShowNodeToolTips = true;
            this.ListaObjetos.Size = new System.Drawing.Size(304, 314);
            this.ListaObjetos.StateImageList = this.imageList2;
            this.ListaObjetos.TabIndex = 2;
            this.ListaObjetos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaObjetos_AfterSelect);
            this.ListaObjetos.DoubleClick += new System.EventHandler(this.ListaObjetos_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCodigoToolStripMenuItem,
            this.copiarNombreToolStripMenuItem,
            this.copiarYResaltarToolStripMenuItem,
            this.toolStripSeparator3,
            this.verTodosToolStripMenuItem,
            this.resaltarToolStripMenuItem,
            this.desmarcarToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitarToolStripMenuItem,
            this.enviarAExcluidosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 192);
            // 
            // verCodigoToolStripMenuItem
            // 
            this.verCodigoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verCodigoToolStripMenuItem.Image")));
            this.verCodigoToolStripMenuItem.Name = "verCodigoToolStripMenuItem";
            this.verCodigoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.verCodigoToolStripMenuItem.Text = "Ver codigo";
            this.verCodigoToolStripMenuItem.Click += new System.EventHandler(this.verCodigoToolStripMenuItem_Click);
            // 
            // copiarNombreToolStripMenuItem
            // 
            this.copiarNombreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copiarNombreToolStripMenuItem.Image")));
            this.copiarNombreToolStripMenuItem.Name = "copiarNombreToolStripMenuItem";
            this.copiarNombreToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.copiarNombreToolStripMenuItem.Text = "Copiar Nombre";
            this.copiarNombreToolStripMenuItem.Click += new System.EventHandler(this.copiarNombreToolStripMenuItem_Click);
            // 
            // copiarYResaltarToolStripMenuItem
            // 
            this.copiarYResaltarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copiarYResaltarToolStripMenuItem.Image")));
            this.copiarYResaltarToolStripMenuItem.Name = "copiarYResaltarToolStripMenuItem";
            this.copiarYResaltarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.copiarYResaltarToolStripMenuItem.Text = "Copiar y resaltar";
            this.copiarYResaltarToolStripMenuItem.Click += new System.EventHandler(this.copiarYResaltarToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // verTodosToolStripMenuItem
            // 
            this.verTodosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verTodosToolStripMenuItem.Image")));
            this.verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            this.verTodosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.verTodosToolStripMenuItem.Text = "Ver todos";
            this.verTodosToolStripMenuItem.Click += new System.EventHandler(this.verTodosToolStripMenuItem_Click);
            // 
            // resaltarToolStripMenuItem
            // 
            this.resaltarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resaltarToolStripMenuItem.Image")));
            this.resaltarToolStripMenuItem.Name = "resaltarToolStripMenuItem";
            this.resaltarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.resaltarToolStripMenuItem.Text = "Resaltar";
            this.resaltarToolStripMenuItem.Click += new System.EventHandler(this.resaltarToolStripMenuItem_Click);
            // 
            // desmarcarToolStripMenuItem
            // 
            this.desmarcarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("desmarcarToolStripMenuItem.Image")));
            this.desmarcarToolStripMenuItem.Name = "desmarcarToolStripMenuItem";
            this.desmarcarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.desmarcarToolStripMenuItem.Text = "Desmarcar";
            this.desmarcarToolStripMenuItem.Click += new System.EventHandler(this.desmarcarToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // quitarToolStripMenuItem
            // 
            this.quitarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitarToolStripMenuItem.Image")));
            this.quitarToolStripMenuItem.Name = "quitarToolStripMenuItem";
            this.quitarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.quitarToolStripMenuItem.Text = "Quitar";
            this.quitarToolStripMenuItem.Click += new System.EventHandler(this.quitarToolStripMenuItem_Click);
            // 
            // enviarAExcluidosToolStripMenuItem
            // 
            this.enviarAExcluidosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enviarAExcluidosToolStripMenuItem.Image")));
            this.enviarAExcluidosToolStripMenuItem.Name = "enviarAExcluidosToolStripMenuItem";
            this.enviarAExcluidosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.enviarAExcluidosToolStripMenuItem.Text = "Enviar a Excluidos";
            this.enviarAExcluidosToolStripMenuItem.Click += new System.EventHandler(this.enviarAExcluidosToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Vista.ico");
            this.imageList2.Images.SetKeyName(1, "vista.png");
            this.imageList2.Images.SetKeyName(2, "funcion.png");
            this.imageList2.Images.SetKeyName(3, "SP.ICO");
            this.imageList2.Images.SetKeyName(4, "trriger.jpg");
            this.imageList2.Images.SetKeyName(5, "check.png");
            this.imageList2.Images.SetKeyName(6, "default.png");
            this.imageList2.Images.SetKeyName(7, "FK.ico");
            this.imageList2.Images.SetKeyName(8, "llaves.jpg");
            this.imageList2.Images.SetKeyName(9, "Trasar2.jpg");
            this.imageList2.Images.SetKeyName(10, "desconocido.jpg");
            this.imageList2.Images.SetKeyName(11, "molde2.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 39);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(304, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Busca las dependencias de los objetos y como se van llamando hasta llegar a las t" +
    "ablas base que utiliza";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file-manager.png");
            this.imageList1.Images.SetKeyName(1, "Shaded Right Tab.ico");
            this.imageList1.Images.SetKeyName(2, "kedit2.png");
            // 
            // TimerLLena
            // 
            this.TimerLLena.Enabled = true;
            this.TimerLLena.Tick += new System.EventHandler(this.TimerLLena_Tick);
            // 
            // cBuscadorDependencias1
            // 
            this.cBuscadorDependencias1.ObjetoInicial = null;
            this.cBuscadorDependencias1.OnMotorChange += new SQLDeveloper.Modulos.BuscadorDependencias.OnBusquedaDependenciaEvent(this.cBuscadorDependencias1_OnMotorChange);
            this.cBuscadorDependencias1.OnObjetoEncontrado += new SQLDeveloper.Modulos.BuscadorDependencias.OnObjetoDependenciaEncontradoEvent(this.cBuscadorDependencias1_OnObjetoEncontrado);
            this.cBuscadorDependencias1.OnInicioBusqueda += new SQLDeveloper.Modulos.BuscadorDependencias.OnBusquedaDependenciaEvent(this.cBuscadorDependencias1_OnInicioBusqueda);
            this.cBuscadorDependencias1.OnFinBusqueda += new SQLDeveloper.Modulos.BuscadorDependencias.OnBusquedaDependenciaEvent(this.cBuscadorDependencias1_OnFinBusqueda);
            this.cBuscadorDependencias1.OnMensaje += new SQLDeveloper.Modulos.BuscadorDependencias.OnObjetoDependenciaMensajeEvent(this.cBuscadorDependencias1_OnMensaje);
            // 
            // FormBuscadorDependencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 509);
            this.Controls.Add(this.miniToolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormBuscadorDependencias";
            this.Text = "FormBuscadorTablas";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataReporte)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataSet DataReporte;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton BBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox TBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BGenerarReporte;
        private System.Windows.Forms.ToolStripLabel LResultado;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verCodigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
        private System.Windows.Forms.Timer TimerLLena;
        private System.Windows.Forms.ImageList imageList2;
        private ManagerConnect.CConecionesManager cConecionesManager1;
        private BuscadorDependencias.CBuscadorDependencias cBuscadorDependencias1;
        private System.Windows.Forms.ToolStripMenuItem resaltarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarYResaltarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton BExcluidos;
        private System.Windows.Forms.ToolStripMenuItem enviarAExcluidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desmarcarToolStripMenuItem;
    }
}