namespace SQLDeveloper.Modulos.ProyectAdmin
{
    partial class FormProyect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProyect));
            this.Lista = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TimerMonitoreo = new System.Windows.Forms.Timer(this.components);
            this.TimerInicial = new System.Windows.Forms.Timer(this.components);
            this.modeloBasico1 = new SQLDeveloper.Modulos.ProyectAdmin.ModeloBasico();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.BBuscar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBasico1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lista
            // 
            this.Lista.AllowDrop = true;
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.ImageIndex = 0;
            this.Lista.ImageList = this.imageList1;
            this.Lista.Location = new System.Drawing.Point(0, 25);
            this.Lista.Name = "Lista";
            this.Lista.SelectedImageIndex = 0;
            this.Lista.Size = new System.Drawing.Size(388, 425);
            this.Lista.StateImageList = this.imageList1;
            this.Lista.TabIndex = 0;
            this.Lista.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterCollapse);
            this.Lista.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterExpand);
            this.Lista.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Lista_ItemDrag);
            this.Lista.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterSelect);
            this.Lista.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Lista_NodeMouseDoubleClick);
            this.Lista.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lista_DragDrop);
            this.Lista.DragEnter += new System.Windows.Forms.DragEventHandler(this.Lista_DragEnter);
            this.Lista.DragOver += new System.Windows.Forms.DragEventHandler(this.Lista_DragOver);
            this.Lista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lista_MouseDown);
            this.Lista.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lista_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database-process-icon.png");
            this.imageList1.Images.SetKeyName(1, "8500.ico");
            this.imageList1.Images.SetKeyName(2, "folder cerrado.png");
            this.imageList1.Images.SetKeyName(3, "folder Abierto.png");
            this.imageList1.Images.SetKeyName(4, "folder rojo.jpg");
            this.imageList1.Images.SetKeyName(5, "calabera.png");
            this.imageList1.Images.SetKeyName(6, "edit_add.png");
            this.imageList1.Images.SetKeyName(7, "Vista.ico");
            this.imageList1.Images.SetKeyName(8, "vista.png");
            this.imageList1.Images.SetKeyName(9, "funcion.png");
            this.imageList1.Images.SetKeyName(10, "SP.ICO");
            this.imageList1.Images.SetKeyName(11, "trriger.jpg");
            this.imageList1.Images.SetKeyName(12, "check.png");
            this.imageList1.Images.SetKeyName(13, "default.png");
            this.imageList1.Images.SetKeyName(14, "FK.ico");
            this.imageList1.Images.SetKeyName(15, "llaves.jpg");
            this.imageList1.Images.SetKeyName(16, "trasar.png");
            this.imageList1.Images.SetKeyName(17, "desconocido.jpg");
            this.imageList1.Images.SetKeyName(18, "calendario.png");
            this.imageList1.Images.SetKeyName(19, "molde2.png");
            this.imageList1.Images.SetKeyName(20, "script2.png");
            this.imageList1.Images.SetKeyName(21, "document.png");
            // 
            // TimerMonitoreo
            // 
            this.TimerMonitoreo.Enabled = true;
            this.TimerMonitoreo.Interval = 300000;
            this.TimerMonitoreo.Tick += new System.EventHandler(this.TimerMonitoreo_Tick);
            // 
            // TimerInicial
            // 
            this.TimerInicial.Enabled = true;
            this.TimerInicial.Interval = 500;
            this.TimerInicial.Tick += new System.EventHandler(this.TimerInicial_Tick);
            // 
            // modeloBasico1
            // 
            this.modeloBasico1.DataSetName = "ModeloBasico";
            this.modeloBasico1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TBuscar,
            this.BBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(388, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Buscar";
            // 
            // TBuscar
            // 
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(150, 25);
            this.TBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBuscar_KeyUp);
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
            // FormProyect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 450);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormProyect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto";
            this.Load += new System.EventHandler(this.FormProyect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modeloBasico1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView Lista;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer TimerMonitoreo;
        private System.Windows.Forms.Timer TimerInicial;
        private ModeloBasico modeloBasico1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TBuscar;
        private System.Windows.Forms.ToolStripButton BBuscar;
    }
}