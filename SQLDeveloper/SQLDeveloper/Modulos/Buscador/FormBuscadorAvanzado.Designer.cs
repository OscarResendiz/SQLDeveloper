namespace SQLDeveloper.Modulos.Buscador
{
    partial class FormBuscadorAvanzado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscadorAvanzado));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ListaFiltros = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BAgregarFiltro = new System.Windows.Forms.ToolStripButton();
            this.BQuitarFiltro = new System.Windows.Forms.ToolStripButton();
            this.BEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BBuscar = new System.Windows.Forms.ToolStripButton();
            this.waitControl1 = new WaitControl.WaitControl();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.LResultado = new System.Windows.Forms.ToolStripLabel();
            this.TimerLLena = new System.Windows.Forms.Timer(this.components);
            this.cBuscadorAvanzado1 = new SQLDeveloper.Modulos.Buscador.CBuscadorAvanzado();
            this.modeloConexiones1 = new ManagerConnect.ModeloConexiones();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modeloConexiones1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(284, 507);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(284, 69);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file-manager.png");
            this.imageList1.Images.SetKeyName(1, "Shaded Right Tab.ico");
            this.imageList1.Images.SetKeyName(2, "kedit2.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(284, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel2.Text = "Conexiones";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ListaFiltros);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ListaObjetos);
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer2.Size = new System.Drawing.Size(284, 409);
            this.splitContainer2.SplitterDistance = 118;
            this.splitContainer2.TabIndex = 0;
            // 
            // ListaFiltros
            // 
            this.ListaFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaFiltros.FormattingEnabled = true;
            this.ListaFiltros.Location = new System.Drawing.Point(0, 38);
            this.ListaFiltros.Name = "ListaFiltros";
            this.ListaFiltros.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListaFiltros.Size = new System.Drawing.Size(284, 80);
            this.ListaFiltros.TabIndex = 2;
            this.ListaFiltros.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaFiltros_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.waitControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 38);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.BAgregarFiltro,
            this.BQuitarFiltro,
            this.BEditar,
            this.toolStripSeparator1,
            this.BBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Filtros";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BAgregarFiltro
            // 
            this.BAgregarFiltro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarFiltro.Image")));
            this.BAgregarFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregarFiltro.Name = "BAgregarFiltro";
            this.BAgregarFiltro.Size = new System.Drawing.Size(23, 22);
            this.BAgregarFiltro.Text = "Agregar filtro";
            this.BAgregarFiltro.Click += new System.EventHandler(this.BAgregarFiltro_Click);
            // 
            // BQuitarFiltro
            // 
            this.BQuitarFiltro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BQuitarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("BQuitarFiltro.Image")));
            this.BQuitarFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BQuitarFiltro.Name = "BQuitarFiltro";
            this.BQuitarFiltro.Size = new System.Drawing.Size(23, 22);
            this.BQuitarFiltro.Text = "Quitar filtro";
            this.BQuitarFiltro.Click += new System.EventHandler(this.BQuitarFiltro_Click);
            // 
            // BEditar
            // 
            this.BEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEditar.Image = ((System.Drawing.Image)(resources.GetObject("BEditar.Image")));
            this.BEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(23, 22);
            this.BEditar.Text = "Modificar";
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitControl1.Location = new System.Drawing.Point(0, 28);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(284, 10);
            this.waitControl1.TabIndex = 4;
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.AllowDrop = true;
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList2;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 25);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.ShowNodeToolTips = true;
            this.ListaObjetos.Size = new System.Drawing.Size(284, 221);
            this.ListaObjetos.StateImageList = this.imageList2;
            this.ListaObjetos.TabIndex = 2;
            this.ListaObjetos.DoubleClick += new System.EventHandler(this.ListaObjetos_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTodosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // verTodosToolStripMenuItem
            // 
            this.verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            this.verTodosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.verTodosToolStripMenuItem.Text = "Ver todos";
            this.verTodosToolStripMenuItem.Click += new System.EventHandler(this.verTodosToolStripMenuItem_Click);
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
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(0, 246);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(284, 41);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Hace una búsqueda avanzada en varias bases de datos por medio de filtros ";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LResultado});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(284, 25);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // LResultado
            // 
            this.LResultado.Name = "LResultado";
            this.LResultado.Size = new System.Drawing.Size(59, 22);
            this.LResultado.Text = "Resultado";
            // 
            // TimerLLena
            // 
            this.TimerLLena.Enabled = true;
            this.TimerLLena.Tick += new System.EventHandler(this.TimerLLena_Tick);
            // 
            // cBuscadorAvanzado1
            // 
            this.cBuscadorAvanzado1.OnFiltroChange += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFiltroChange);
            this.cBuscadorAvanzado1.OnObjetoEncontrado += new SQLDeveloper.Modulos.Buscador.OnObjetoEncontradoEvent(this.cBuscadorAvanzado1_OnObjetoEncontrado);
            this.cBuscadorAvanzado1.OnInicioBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnInicioBusqueda);
            this.cBuscadorAvanzado1.OnFinBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFinBusqueda);
            // 
            // modeloConexiones1
            // 
            this.modeloConexiones1.DataSetName = "ModeloConexiones";
            this.modeloConexiones1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormBuscadorAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormBuscadorAvanzado";
            this.Text = "Busqueda Avanzada";
            this.Load += new System.EventHandler(this.FormBuscadorAvanzado_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modeloConexiones1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregarFiltro;
        private System.Windows.Forms.ToolStripButton BQuitarFiltro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BBuscar;
        private CBuscadorAvanzado cBuscadorAvanzado1;
        private System.Windows.Forms.ListBox ListaFiltros;
        private System.Windows.Forms.Timer TimerLLena;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel LResultado;
        private System.Windows.Forms.ToolStripButton BEditar;
        private System.Windows.Forms.TextBox textBox1;
        private ManagerConnect.ModeloConexiones modeloConexiones1;
    }
}