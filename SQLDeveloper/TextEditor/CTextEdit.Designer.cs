namespace TextEditor
{
    public partial class CTextEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTextEdit));
            this.MenuCodigo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuDeficion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAgregarMarcador = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerArchivo = new System.Windows.Forms.Timer(this.components);
            this.BkConsulta = new System.ComponentModel.BackgroundWorker();
            this.TimerFolders = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lecxer1 = new Compiler.Lexer.Lecxer(this.components);
            this.MenuMarcador = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuQuitarMarcador = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLimpiarMarcadores = new System.Windows.Forms.ToolStripMenuItem();
            this.Contenedor = new System.Windows.Forms.SplitContainer();
            this.TCodigo = new ICSharpCode.TextEditor.TextEditorControl();
            this.LMarcador = new System.Windows.Forms.ListBox();
            this.Grid = new GridControl.ControlerGrid();
            this.waitControl1 = new WaitControl.WaitControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BCambiarConexion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Lgrupo = new System.Windows.Forms.ToolStripLabel();
            this.Trgupo = new System.Windows.Forms.ToolStripTextBox();
            this.LConexion = new System.Windows.Forms.ToolStripLabel();
            this.TConexion = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.TNombre = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Babrir = new System.Windows.Forms.ToolStripButton();
            this.BGuardar = new System.Windows.Forms.ToolStripButton();
            this.BguardarComo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BGrid = new System.Windows.Forms.ToolStripButton();
            this.BEjecutar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BComentar = new System.Windows.Forms.ToolStripButton();
            this.BDescomentar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BDeshacer = new System.Windows.Forms.ToolStripButton();
            this.BRehacer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BBuscar = new System.Windows.Forms.ToolStripButton();
            this.BNumeroLinea = new System.Windows.Forms.ToolStripButton();
            this.BTabular = new System.Windows.Forms.ToolStripButton();
            this.BVariables = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LArchivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.cGestorDesaser1 = new CGestorDesaser(this.components);
            this.cInteliences1 = new Inteliences.CInteliences(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LSeleccionado = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuCodigo.SuspendLayout();
            this.MenuMarcador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor)).BeginInit();
            this.Contenedor.Panel1.SuspendLayout();
            this.Contenedor.Panel2.SuspendLayout();
            this.Contenedor.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuCodigo
            // 
            this.MenuCodigo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDeficion,
            this.MenuAgregarMarcador});
            this.MenuCodigo.Name = "MenuCodigo";
            this.MenuCodigo.Size = new System.Drawing.Size(171, 48);
            // 
            // MenuDeficion
            // 
            this.MenuDeficion.Image = ((System.Drawing.Image)(resources.GetObject("MenuDeficion.Image")));
            this.MenuDeficion.Name = "MenuDeficion";
            this.MenuDeficion.Size = new System.Drawing.Size(170, 22);
            this.MenuDeficion.Text = "Ir a la definicion";
            this.MenuDeficion.Click += new System.EventHandler(this.MenuDeficion_Click);
            // 
            // MenuAgregarMarcador
            // 
            this.MenuAgregarMarcador.Image = ((System.Drawing.Image)(resources.GetObject("MenuAgregarMarcador.Image")));
            this.MenuAgregarMarcador.Name = "MenuAgregarMarcador";
            this.MenuAgregarMarcador.Size = new System.Drawing.Size(170, 22);
            this.MenuAgregarMarcador.Text = "Agregar Marcador";
            this.MenuAgregarMarcador.Click += new System.EventHandler(this.MenuAgregarMarcador_Click);
            // 
            // TimerArchivo
            // 
            this.TimerArchivo.Interval = 1000;
            this.TimerArchivo.Tick += new System.EventHandler(this.TimerArchivo_Tick);
            // 
            // BkConsulta
            // 
            this.BkConsulta.WorkerReportsProgress = true;
            this.BkConsulta.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkConsulta_DoWork);
            this.BkConsulta.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkConsulta_ProgressChanged);
            this.BkConsulta.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkConsulta_RunWorkerCompleted);
            // 
            // TimerFolders
            // 
            this.TimerFolders.Enabled = true;
            this.TimerFolders.Interval = 2000;
            this.TimerFolders.Tick += new System.EventHandler(this.TimerFolders_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lecxer1
            // 
            this.lecxer1.Cadena = "";
            // 
            // MenuMarcador
            // 
            this.MenuMarcador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuQuitarMarcador,
            this.MenuLimpiarMarcadores});
            this.MenuMarcador.Name = "MenuMarcador";
            this.MenuMarcador.Size = new System.Drawing.Size(180, 48);
            // 
            // MenuQuitarMarcador
            // 
            this.MenuQuitarMarcador.Image = ((System.Drawing.Image)(resources.GetObject("MenuQuitarMarcador.Image")));
            this.MenuQuitarMarcador.Name = "MenuQuitarMarcador";
            this.MenuQuitarMarcador.Size = new System.Drawing.Size(179, 22);
            this.MenuQuitarMarcador.Text = "Quitar Marcador";
            this.MenuQuitarMarcador.Click += new System.EventHandler(this.MenuQuitarMarcador_Click);
            // 
            // MenuLimpiarMarcadores
            // 
            this.MenuLimpiarMarcadores.Image = ((System.Drawing.Image)(resources.GetObject("MenuLimpiarMarcadores.Image")));
            this.MenuLimpiarMarcadores.Name = "MenuLimpiarMarcadores";
            this.MenuLimpiarMarcadores.Size = new System.Drawing.Size(179, 22);
            this.MenuLimpiarMarcadores.Text = "Limpiar marcadores";
            this.MenuLimpiarMarcadores.Click += new System.EventHandler(this.MenuLimpiarMarcadores_Click);
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 50);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Contenedor.Panel1
            // 
            this.Contenedor.Panel1.Controls.Add(this.TCodigo);
            this.Contenedor.Panel1.Controls.Add(this.LMarcador);
            // 
            // Contenedor.Panel2
            // 
            this.Contenedor.Panel2.Controls.Add(this.Grid);
            this.Contenedor.Panel2.Controls.Add(this.waitControl1);
            this.Contenedor.Size = new System.Drawing.Size(939, 417);
            this.Contenedor.SplitterDistance = 207;
            this.Contenedor.TabIndex = 7;
            // 
            // TCodigo
            // 
            this.TCodigo.AllowDrop = true;
            this.TCodigo.ContextMenuStrip = this.MenuCodigo;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.IsReadOnly = false;
            this.TCodigo.Location = new System.Drawing.Point(0, 0);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ShowLineNumbers = false;
            this.TCodigo.ShowVRuler = false;
            this.TCodigo.Size = new System.Drawing.Size(892, 207);
            this.TCodigo.TabIndex = 5;
            this.TCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyUp);
            // 
            // LMarcador
            // 
            this.LMarcador.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LMarcador.ContextMenuStrip = this.MenuMarcador;
            this.LMarcador.Dock = System.Windows.Forms.DockStyle.Right;
            this.LMarcador.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LMarcador.FormattingEnabled = true;
            this.LMarcador.Location = new System.Drawing.Point(892, 0);
            this.LMarcador.Name = "LMarcador";
            this.LMarcador.Size = new System.Drawing.Size(47, 207);
            this.LMarcador.TabIndex = 6;
            this.LMarcador.DoubleClick += new System.EventHandler(this.LMarcador_DoubleClick);
            // 
            // Grid
            // 
            this.Grid.DataSet = null;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 10);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(939, 196);
            this.Grid.TabIndex = 0;
            this.Grid.OnMessage += new GridControl.OnMessageEvent(this.Grid_OnMessage);
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.waitControl1.Location = new System.Drawing.Point(0, 0);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(939, 10);
            this.waitControl1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BCambiarConexion,
            this.toolStripSeparator1,
            this.Lgrupo,
            this.Trgupo,
            this.LConexion,
            this.TConexion,
            this.toolStripLabel3,
            this.TNombre});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(939, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BCambiarConexion
            // 
            this.BCambiarConexion.Checked = true;
            this.BCambiarConexion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BCambiarConexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BCambiarConexion.Image = ((System.Drawing.Image)(resources.GetObject("BCambiarConexion.Image")));
            this.BCambiarConexion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCambiarConexion.Name = "BCambiarConexion";
            this.BCambiarConexion.Size = new System.Drawing.Size(146, 22);
            this.BCambiarConexion.Text = "Usar la conexion principal";
            this.BCambiarConexion.Click += new System.EventHandler(this.BCambiarConexion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Lgrupo
            // 
            this.Lgrupo.Name = "Lgrupo";
            this.Lgrupo.Size = new System.Drawing.Size(40, 22);
            this.Lgrupo.Text = "Grupo";
            // 
            // Trgupo
            // 
            this.Trgupo.Name = "Trgupo";
            this.Trgupo.ReadOnly = true;
            this.Trgupo.Size = new System.Drawing.Size(150, 25);
            // 
            // LConexion
            // 
            this.LConexion.Name = "LConexion";
            this.LConexion.Size = new System.Drawing.Size(57, 22);
            this.LConexion.Text = "Conexion";
            // 
            // TConexion
            // 
            this.TConexion.Name = "TConexion";
            this.TConexion.ReadOnly = true;
            this.TConexion.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel3.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Babrir,
            this.BGuardar,
            this.BguardarComo,
            this.toolStripSeparator5,
            this.BGrid,
            this.BEjecutar,
            this.toolStripSeparator2,
            this.BComentar,
            this.BDescomentar,
            this.toolStripSeparator3,
            this.BDeshacer,
            this.BRehacer,
            this.toolStripSeparator4,
            this.BBuscar,
            this.BNumeroLinea,
            this.BTabular,
            this.BVariables});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(939, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Babrir
            // 
            this.Babrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Babrir.Image = ((System.Drawing.Image)(resources.GetObject("Babrir.Image")));
            this.Babrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Babrir.Name = "Babrir";
            this.Babrir.Size = new System.Drawing.Size(23, 22);
            this.Babrir.Text = "Abrir";
            this.Babrir.Click += new System.EventHandler(this.Babrir_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BGuardar.Image")));
            this.BGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(23, 22);
            this.BGuardar.Text = "Guardar";
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BguardarComo
            // 
            this.BguardarComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BguardarComo.Image = ((System.Drawing.Image)(resources.GetObject("BguardarComo.Image")));
            this.BguardarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BguardarComo.Name = "BguardarComo";
            this.BguardarComo.Size = new System.Drawing.Size(23, 22);
            this.BguardarComo.Text = "Guardar Como";
            this.BguardarComo.Click += new System.EventHandler(this.BguardarComo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // BGrid
            // 
            this.BGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGrid.Image = ((System.Drawing.Image)(resources.GetObject("BGrid.Image")));
            this.BGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGrid.Name = "BGrid";
            this.BGrid.Size = new System.Drawing.Size(23, 22);
            this.BGrid.Text = "Mostrar grid";
            this.BGrid.Click += new System.EventHandler(this.BGrid_Click);
            // 
            // BEjecutar
            // 
            this.BEjecutar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("BEjecutar.Image")));
            this.BEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEjecutar.Name = "BEjecutar";
            this.BEjecutar.Size = new System.Drawing.Size(23, 22);
            this.BEjecutar.Text = "Ejecutar";
            this.BEjecutar.Click += new System.EventHandler(this.BEjecutar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BComentar
            // 
            this.BComentar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BComentar.Image = ((System.Drawing.Image)(resources.GetObject("BComentar.Image")));
            this.BComentar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BComentar.Name = "BComentar";
            this.BComentar.Size = new System.Drawing.Size(23, 22);
            this.BComentar.Text = "Comentar";
            this.BComentar.Click += new System.EventHandler(this.BComentar_Click);
            // 
            // BDescomentar
            // 
            this.BDescomentar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDescomentar.Image = ((System.Drawing.Image)(resources.GetObject("BDescomentar.Image")));
            this.BDescomentar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDescomentar.Name = "BDescomentar";
            this.BDescomentar.Size = new System.Drawing.Size(23, 22);
            this.BDescomentar.Text = "Descomentar";
            this.BDescomentar.Click += new System.EventHandler(this.BDescomentar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BDeshacer
            // 
            this.BDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDeshacer.Enabled = false;
            this.BDeshacer.Image = ((System.Drawing.Image)(resources.GetObject("BDeshacer.Image")));
            this.BDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDeshacer.Name = "BDeshacer";
            this.BDeshacer.Size = new System.Drawing.Size(23, 22);
            this.BDeshacer.Text = "Deshacer";
            this.BDeshacer.Click += new System.EventHandler(this.BDeshacer_Click);
            // 
            // BRehacer
            // 
            this.BRehacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BRehacer.Enabled = false;
            this.BRehacer.Image = ((System.Drawing.Image)(resources.GetObject("BRehacer.Image")));
            this.BRehacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BRehacer.Name = "BRehacer";
            this.BRehacer.Size = new System.Drawing.Size(23, 22);
            this.BRehacer.Text = "Rehacer";
            this.BRehacer.Click += new System.EventHandler(this.BRehacer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // BBuscar
            // 
            this.BBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(23, 22);
            this.BBuscar.Text = "toolStripButton1";
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // BNumeroLinea
            // 
            this.BNumeroLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BNumeroLinea.Image = ((System.Drawing.Image)(resources.GetObject("BNumeroLinea.Image")));
            this.BNumeroLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BNumeroLinea.Name = "BNumeroLinea";
            this.BNumeroLinea.Size = new System.Drawing.Size(23, 22);
            this.BNumeroLinea.Text = "Ver numero de liena";
            this.BNumeroLinea.Click += new System.EventHandler(this.BNumeroLinea_Click);
            // 
            // BTabular
            // 
            this.BTabular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTabular.Image = ((System.Drawing.Image)(resources.GetObject("BTabular.Image")));
            this.BTabular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTabular.Name = "BTabular";
            this.BTabular.Size = new System.Drawing.Size(23, 22);
            this.BTabular.Text = "Tabular texto";
            this.BTabular.Click += new System.EventHandler(this.BTabular_Click);
            // 
            // BVariables
            // 
            this.BVariables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BVariables.Image = ((System.Drawing.Image)(resources.GetObject("BVariables.Image")));
            this.BVariables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BVariables.Name = "BVariables";
            this.BVariables.Size = new System.Drawing.Size(23, 22);
            this.BVariables.Text = "Ver Variables";
            this.BVariables.Click += new System.EventHandler(this.BVariables_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LArchivo,
            this.toolStripStatusLabel2,
            this.LSeleccionado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Archivo";
            // 
            // LArchivo
            // 
            this.LArchivo.Name = "LArchivo";
            this.LArchivo.Size = new System.Drawing.Size(0, 17);
            // 
            // cGestorDesaser1
            // 
            this.cGestorDesaser1.Editor = this.TCodigo;
            this.cGestorDesaser1.TextoInicial = null;
            this.cGestorDesaser1.OnKeyUp += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyUp);
            this.cGestorDesaser1.OnDesaserChange += new ONGestorDesaserEvent(this.cGestorDesaser1_OnDesaserChange);
            this.cGestorDesaser1.OnReHacerChange += new ONGestorDesaserEvent(this.cGestorDesaser1_OnReHacerChange);
            this.cGestorDesaser1.OnTextChange += new ONGestorDesaserEvent(this.cGestorDesaser1_OnTextChange);
            // 
            // cInteliences1
            // 
            this.cInteliences1.DB = null;
            this.cInteliences1.Editor = this.TCodigo;
            this.cInteliences1.FireAt = 0;
            this.cInteliences1.OnParentForm += new Inteliences.OnParentFormEvent(this.cInteliences1_OnParentForm);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel2.Text = "Seleccion:";
            // 
            // LSeleccionado
            // 
            this.LSeleccionado.Name = "LSeleccionado";
            this.LSeleccionado.Size = new System.Drawing.Size(13, 17);
            this.LSeleccionado.Text = "0";
            // 
            // CTextEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "CTextEdit";
            this.Size = new System.Drawing.Size(939, 489);
            this.Load += new System.EventHandler(this.CTextEdit_Load);
            this.Enter += new System.EventHandler(this.TextEdit_Enter);
            this.MenuCodigo.ResumeLayout(false);
            this.MenuMarcador.ResumeLayout(false);
            this.Contenedor.Panel1.ResumeLayout(false);
            this.Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor)).EndInit();
            this.Contenedor.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Lgrupo;
        private System.Windows.Forms.ToolStripTextBox Trgupo;
        private System.Windows.Forms.ToolStripLabel LConexion;
        private System.Windows.Forms.ToolStripTextBox TConexion;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox TNombre;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton Babrir;
        private System.Windows.Forms.ToolStripButton BGuardar;
        private System.Windows.Forms.ToolStripButton BguardarComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BEjecutar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BComentar;
        private System.Windows.Forms.ToolStripButton BDescomentar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BDeshacer;
        private System.Windows.Forms.ToolStripButton BRehacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BBuscar;
        private System.Windows.Forms.ToolStripButton BNumeroLinea;
        private ICSharpCode.TextEditor.TextEditorControl TCodigo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LArchivo;
        private System.Windows.Forms.Timer TimerArchivo;
        private CGestorDesaser cGestorDesaser1;
        private System.Windows.Forms.SplitContainer Contenedor;
        private GridControl.ControlerGrid Grid;
        private System.ComponentModel.BackgroundWorker BkConsulta;
        private System.Windows.Forms.ToolStripButton BGrid;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.Timer TimerFolders;
        private System.Windows.Forms.ToolStripButton BTabular;
        private Inteliences.CInteliences cInteliences1;
        private System.Windows.Forms.ToolStripButton BCambiarConexion;
        private System.Windows.Forms.ContextMenuStrip MenuCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuDeficion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Compiler.Lexer.Lecxer lecxer1;
        private System.Windows.Forms.ToolStripButton BVariables;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregarMarcador;
        private System.Windows.Forms.ListBox LMarcador;
        private System.Windows.Forms.ContextMenuStrip MenuMarcador;
        private System.Windows.Forms.ToolStripMenuItem MenuQuitarMarcador;
        private System.Windows.Forms.ToolStripMenuItem MenuLimpiarMarcadores;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel LSeleccionado;
    }
}
