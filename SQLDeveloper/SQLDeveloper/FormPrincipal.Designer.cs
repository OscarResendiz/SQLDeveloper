namespace SQLDeveloper
{
    partial class FormPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProyectos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevoProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbrirProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuProyectoReciente = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestorDeTabuladoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTemas = new System.Windows.Forms.ToolStripMenuItem();
            this.generadorLiberiaCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizadorDeAplicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.BConexiones = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboGrupos = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ComboConexiones = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BBuscador = new System.Windows.Forms.ToolStripButton();
            this.BBuscaAvanzado = new System.Windows.Forms.ToolStripButton();
            this.BSeguir = new System.Windows.Forms.ToolStripButton();
            this.BBuscadorTablas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Bpropiedades = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BNuevaTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.Bnuevo = new System.Windows.Forms.ToolStripButton();
            this.BAbrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.BComparar = new System.Windows.Forms.ToolStripButton();
            this.BDBComparer = new System.Windows.Forms.ToolStripButton();
            this.BModeloador = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cProjectManager1 = new SQLDeveloper.Modulos.ProyectAdmin.CProjectManager(this.components);
            this.configuradorApp1 = new ManagerConnect.ConfiguradorApp(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.MenuProyectos,
            this.toolsMenu,
            this.windowsMenu,
            this.viewMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(713, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Archivo";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "Conexiiones";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.Conecciones);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "&Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.BAbrir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // MenuProyectos
            // 
            this.MenuProyectos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevoProyecto,
            this.MenuAbrirProyecto,
            this.toolStripSeparator4,
            this.MenuProyectoReciente});
            this.MenuProyectos.Name = "MenuProyectos";
            this.MenuProyectos.Size = new System.Drawing.Size(71, 20);
            this.MenuProyectos.Text = "Proyectos";
            // 
            // MenuNuevoProyecto
            // 
            this.MenuNuevoProyecto.Image = ((System.Drawing.Image)(resources.GetObject("MenuNuevoProyecto.Image")));
            this.MenuNuevoProyecto.Name = "MenuNuevoProyecto";
            this.MenuNuevoProyecto.Size = new System.Drawing.Size(124, 22);
            this.MenuNuevoProyecto.Text = "Nuevo";
            this.MenuNuevoProyecto.Click += new System.EventHandler(this.MenuNuevoProyecto_Click);
            // 
            // MenuAbrirProyecto
            // 
            this.MenuAbrirProyecto.Image = ((System.Drawing.Image)(resources.GetObject("MenuAbrirProyecto.Image")));
            this.MenuAbrirProyecto.Name = "MenuAbrirProyecto";
            this.MenuAbrirProyecto.Size = new System.Drawing.Size(124, 22);
            this.MenuAbrirProyecto.Text = "Abrir";
            this.MenuAbrirProyecto.Click += new System.EventHandler(this.MenuAbrirProyecto_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // MenuProyectoReciente
            // 
            this.MenuProyectoReciente.Image = ((System.Drawing.Image)(resources.GetObject("MenuProyectoReciente.Image")));
            this.MenuProyectoReciente.Name = "MenuProyectoReciente";
            this.MenuProyectoReciente.Size = new System.Drawing.Size(124, 22);
            this.MenuProyectoReciente.Text = "Recientes";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.gestorDeTabuladoresToolStripMenuItem,
            this.MenuTemas,
            this.generadorLiberiaCToolStripMenuItem,
            this.analizadorDeAplicacionesToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(90, 20);
            this.toolsMenu.Text = "&Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.optionsToolStripMenuItem.Text = "&Opciones";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // gestorDeTabuladoresToolStripMenuItem
            // 
            this.gestorDeTabuladoresToolStripMenuItem.Name = "gestorDeTabuladoresToolStripMenuItem";
            this.gestorDeTabuladoresToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.gestorDeTabuladoresToolStripMenuItem.Text = "Gestor de tabuladores";
            this.gestorDeTabuladoresToolStripMenuItem.Click += new System.EventHandler(this.gestorDeTabuladoresToolStripMenuItem_Click);
            // 
            // MenuTemas
            // 
            this.MenuTemas.Name = "MenuTemas";
            this.MenuTemas.Size = new System.Drawing.Size(216, 22);
            this.MenuTemas.Text = "Configurar editor de texto";
            this.MenuTemas.Click += new System.EventHandler(this.MenuTemas_Click);
            // 
            // generadorLiberiaCToolStripMenuItem
            // 
            this.generadorLiberiaCToolStripMenuItem.Name = "generadorLiberiaCToolStripMenuItem";
            this.generadorLiberiaCToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.generadorLiberiaCToolStripMenuItem.Text = "Generador Liberia  C#";
            this.generadorLiberiaCToolStripMenuItem.Click += new System.EventHandler(this.generadorLiberiaCToolStripMenuItem_Click);
            // 
            // analizadorDeAplicacionesToolStripMenuItem
            // 
            this.analizadorDeAplicacionesToolStripMenuItem.Name = "analizadorDeAplicacionesToolStripMenuItem";
            this.analizadorDeAplicacionesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.analizadorDeAplicacionesToolStripMenuItem.Text = "Analizador de Aplicaciones";
            this.analizadorDeAplicacionesToolStripMenuItem.Click += new System.EventHandler(this.analizadorDeAplicacionesToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(66, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newWindowToolStripMenuItem.Text = "&Nueva ventana";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.Conecciones);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascada";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileVerticalToolStripMenuItem.Text = "Mosaico &vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Organizar iconos";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(35, 20);
            this.viewMenu.Text = "&Ver";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.toolBarToolStripMenuItem.Text = "&Barra de herramientas";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.statusBarToolStripMenuItem.Text = "&Barra de estado";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "Ay&uda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.contentsToolStripMenuItem.Text = "&Contenido";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.indexToolStripMenuItem.Text = "&Índice";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.searchToolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(173, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "&Acerca de... ...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BConexiones,
            this.toolStripLabel1,
            this.ComboGrupos,
            this.toolStripLabel2,
            this.ComboConexiones,
            this.toolStripSeparator9,
            this.BBuscador,
            this.BBuscaAvanzado,
            this.BSeguir,
            this.BBuscadorTablas,
            this.toolStripSeparator1,
            this.Bpropiedades,
            this.toolStripSeparator2,
            this.BNuevaTabla,
            this.toolStripSeparator10,
            this.Bnuevo,
            this.BAbrir,
            this.toolStripSeparator11,
            this.BComparar,
            this.BDBComparer,
            this.BModeloador});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(713, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // BConexiones
            // 
            this.BConexiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BConexiones.Image = ((System.Drawing.Image)(resources.GetObject("BConexiones.Image")));
            this.BConexiones.ImageTransparentColor = System.Drawing.Color.Black;
            this.BConexiones.Name = "BConexiones";
            this.BConexiones.Size = new System.Drawing.Size(24, 24);
            this.BConexiones.Text = "Administrar Conexiones";
            this.BConexiones.Click += new System.EventHandler(this.Conecciones);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 24);
            this.toolStripLabel1.Text = "Grupo";
            // 
            // ComboGrupos
            // 
            this.ComboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupos.Name = "ComboGrupos";
            this.ComboGrupos.Size = new System.Drawing.Size(221, 27);
            this.ComboGrupos.DropDown += new System.EventHandler(this.ComboGrupos_DropDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(58, 24);
            this.toolStripLabel2.Text = "Conexion";
            // 
            // ComboConexiones
            // 
            this.ComboConexiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexiones.Name = "ComboConexiones";
            this.ComboConexiones.Size = new System.Drawing.Size(221, 27);
            this.ComboConexiones.DropDown += new System.EventHandler(this.ComboConexiones_DropDown);
            this.ComboConexiones.SelectedIndexChanged += new System.EventHandler(this.ComboConexiones_SelectedIndexChanged);
            this.ComboConexiones.Click += new System.EventHandler(this.ComboConexiones_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // BBuscador
            // 
            this.BBuscador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBuscador.Image = ((System.Drawing.Image)(resources.GetObject("BBuscador.Image")));
            this.BBuscador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBuscador.Name = "BBuscador";
            this.BBuscador.Size = new System.Drawing.Size(24, 24);
            this.BBuscador.Text = "Buscador de Objetos";
            this.BBuscador.Click += new System.EventHandler(this.BBuscador_Click);
            // 
            // BBuscaAvanzado
            // 
            this.BBuscaAvanzado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBuscaAvanzado.Image = ((System.Drawing.Image)(resources.GetObject("BBuscaAvanzado.Image")));
            this.BBuscaAvanzado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBuscaAvanzado.Name = "BBuscaAvanzado";
            this.BBuscaAvanzado.Size = new System.Drawing.Size(24, 24);
            this.BBuscaAvanzado.Text = "Busqueda avanzada";
            this.BBuscaAvanzado.Click += new System.EventHandler(this.BBuscaAvanzado_Click);
            // 
            // BSeguir
            // 
            this.BSeguir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSeguir.Image = ((System.Drawing.Image)(resources.GetObject("BSeguir.Image")));
            this.BSeguir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSeguir.Name = "BSeguir";
            this.BSeguir.Size = new System.Drawing.Size(24, 24);
            this.BSeguir.Text = "Seguir Objeto";
            this.BSeguir.Click += new System.EventHandler(this.BSeguir_Click);
            // 
            // BBuscadorTablas
            // 
            this.BBuscadorTablas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBuscadorTablas.Image = ((System.Drawing.Image)(resources.GetObject("BBuscadorTablas.Image")));
            this.BBuscadorTablas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBuscadorTablas.Name = "BBuscadorTablas";
            this.BBuscadorTablas.Size = new System.Drawing.Size(24, 24);
            this.BBuscadorTablas.Text = "Buscar tablas";
            this.BBuscadorTablas.Click += new System.EventHandler(this.BBuscadorTablas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // Bpropiedades
            // 
            this.Bpropiedades.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bpropiedades.Image = ((System.Drawing.Image)(resources.GetObject("Bpropiedades.Image")));
            this.Bpropiedades.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bpropiedades.Name = "Bpropiedades";
            this.Bpropiedades.Size = new System.Drawing.Size(24, 24);
            this.Bpropiedades.Text = "Mostrar ventana de  propiedades";
            this.Bpropiedades.Click += new System.EventHandler(this.Bpropiedades_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // BNuevaTabla
            // 
            this.BNuevaTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BNuevaTabla.Image = ((System.Drawing.Image)(resources.GetObject("BNuevaTabla.Image")));
            this.BNuevaTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BNuevaTabla.Name = "BNuevaTabla";
            this.BNuevaTabla.Size = new System.Drawing.Size(24, 24);
            this.BNuevaTabla.Text = "Crear Tabla";
            this.BNuevaTabla.Click += new System.EventHandler(this.BNuevaTabla_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // Bnuevo
            // 
            this.Bnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bnuevo.Image = ((System.Drawing.Image)(resources.GetObject("Bnuevo.Image")));
            this.Bnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bnuevo.Name = "Bnuevo";
            this.Bnuevo.Size = new System.Drawing.Size(24, 24);
            this.Bnuevo.Text = "Editor de  consultas";
            this.Bnuevo.Click += new System.EventHandler(this.Bnuevo_Click);
            // 
            // BAbrir
            // 
            this.BAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAbrir.Image = ((System.Drawing.Image)(resources.GetObject("BAbrir.Image")));
            this.BAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAbrir.Name = "BAbrir";
            this.BAbrir.Size = new System.Drawing.Size(24, 24);
            this.BAbrir.Text = "Abrir Archivo";
            this.BAbrir.Click += new System.EventHandler(this.BAbrir_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 27);
            // 
            // BComparar
            // 
            this.BComparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BComparar.Image = ((System.Drawing.Image)(resources.GetObject("BComparar.Image")));
            this.BComparar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BComparar.Name = "BComparar";
            this.BComparar.Size = new System.Drawing.Size(24, 24);
            this.BComparar.Text = "Comparar Codigo";
            this.BComparar.Click += new System.EventHandler(this.BComparar_Click);
            // 
            // BDBComparer
            // 
            this.BDBComparer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDBComparer.Image = ((System.Drawing.Image)(resources.GetObject("BDBComparer.Image")));
            this.BDBComparer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDBComparer.Name = "BDBComparer";
            this.BDBComparer.Size = new System.Drawing.Size(24, 24);
            this.BDBComparer.Text = "Comparar Bases de Datos";
            this.BDBComparer.Click += new System.EventHandler(this.BDBComparer_Click);
            // 
            // BModeloador
            // 
            this.BModeloador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BModeloador.Image = ((System.Drawing.Image)(resources.GetObject("BModeloador.Image")));
            this.BModeloador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BModeloador.Name = "BModeloador";
            this.BModeloador.Size = new System.Drawing.Size(24, 24);
            this.BModeloador.Text = "Modelador";
            this.BModeloador.Click += new System.EventHandler(this.BModeloador_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(713, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "VIEWER6.ICO");
            this.imageList1.Images.SetKeyName(1, "ATLConsumer.ico");
            this.imageList1.Images.SetKeyName(2, "FORM02C.ICO");
            this.imageList1.Images.SetKeyName(3, "DIR02B.ICO");
            this.imageList1.Images.SetKeyName(4, "Tabla.png");
            this.imageList1.Images.SetKeyName(5, "Trasar2.jpg");
            this.imageList1.Images.SetKeyName(6, "trriger.jpg");
            // 
            // cProjectManager1
            // 
            this.cProjectManager1.OnProjectHistoruChange += new SQLDeveloper.Modulos.ProyectAdmin.CProjectManagerEvent(this.LoadHistoryproyects);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(713, 453);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Developer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BConexiones;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboGrupos;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ComboConexiones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BBuscador;
        private System.Windows.Forms.ToolStripButton Bpropiedades;
        private System.Windows.Forms.ToolStripButton BNuevaTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton Bnuevo;
        private System.Windows.Forms.ToolStripButton BAbrir;
        private System.Windows.Forms.ToolStripMenuItem gestorDeTabuladoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTemas;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton BComparar;
        private Modulos.ProyectAdmin.CProjectManager cProjectManager1;
        private System.Windows.Forms.ToolStripMenuItem MenuProyectos;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevoProyecto;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrirProyecto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuProyectoReciente;
        private System.Windows.Forms.ToolStripButton BBuscaAvanzado;
        private System.Windows.Forms.ToolStripMenuItem generadorLiberiaCToolStripMenuItem;
        private ManagerConnect.ConfiguradorApp configuradorApp1;
        private System.Windows.Forms.ToolStripButton BDBComparer;
        private System.Windows.Forms.ToolStripButton BSeguir;
        private System.Windows.Forms.ToolStripButton BBuscadorTablas;
        private System.Windows.Forms.ToolStripMenuItem analizadorDeAplicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BModeloador;
    }
}



   