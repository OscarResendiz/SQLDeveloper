namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    partial class FormSeleccionarSPs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionarSPs));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.waitControl1 = new WaitControl.WaitControl();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TimerLLena = new System.Windows.Forms.Timer(this.components);
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.cBuscadorAvanzado1 = new SQLDeveloper.Modulos.Buscador.CBuscadorAvanzado();
            this.TimerBuscar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.TNombre);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.ListaObjetos);
            this.splitContainer1.Panel2.Controls.Add(this.waitControl1);
            this.splitContainer1.Size = new System.Drawing.Size(284, 507);
            this.splitContainer1.SplitterDistance = 63;
            this.splitContainer1.TabIndex = 0;
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
            this.ListaObjetos.Location = new System.Drawing.Point(0, 10);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.ShowNodeToolTips = true;
            this.ListaObjetos.Size = new System.Drawing.Size(284, 430);
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
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 17);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(182, 20);
            this.TNombre.TabIndex = 3;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LResultado
            // 
            this.LResultado.Name = "LResultado";
            this.LResultado.Size = new System.Drawing.Size(117, 17);
            this.LResultado.Text = "Objetos encontrados";
            // 
            // cBuscadorAvanzado1
            // 
            this.cBuscadorAvanzado1.OnObjetoEncontrado += new SQLDeveloper.Modulos.Buscador.OnObjetoEncontradoEvent(this.cBuscadorAvanzado1_OnObjetoEncontrado);
            this.cBuscadorAvanzado1.OnInicioBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnInicioBusqueda);
            this.cBuscadorAvanzado1.OnFinBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFinBusqueda);
            // 
            // TimerBuscar
            // 
            this.TimerBuscar.Interval = 500;
            this.TimerBuscar.Tick += new System.EventHandler(this.TimerBuscar_Tick);
            // 
            // FormSeleccionarSPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSeleccionarSPs";
            this.Text = "Busqueda Avanzada";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.ImageList imageList1;
        private Modulos.Buscador.CBuscadorAvanzado cBuscadorAvanzado1;
        private System.Windows.Forms.Timer TimerLLena;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LResultado;
        private System.Windows.Forms.Timer TimerBuscar;
    }
}