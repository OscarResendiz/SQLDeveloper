namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    partial class FormAppsAnalizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppsAnalizer));
            this.Lista = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.BBuscar = new System.Windows.Forms.ToolStripButton();
            this.appModel1 = new SQLDeveloper.Modulos.AppsAnalizer.ObjetosModelo.AppModel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cProcesoAvance1 = new SQLDeveloper.Modulos.AppsAnalizer.Formularios.CProcesoAvance();
            this.cHistoryModel1 = new ObjetosModelo.CHistoryModel(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appModel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lista
            // 
            this.Lista.AllowDrop = true;
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.ImageIndex = 0;
            this.Lista.ImageList = this.imageList1;
            this.Lista.Location = new System.Drawing.Point(0, 0);
            this.Lista.Name = "Lista";
            this.Lista.SelectedImageIndex = 0;
            this.Lista.Size = new System.Drawing.Size(284, 340);
            this.Lista.StateImageList = this.imageList1;
            this.Lista.TabIndex = 2;
            this.Lista.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterCollapse);
            this.Lista.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterExpand);
            this.Lista.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Lista_ItemDrag);
            this.Lista.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterSelect);
            this.Lista.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Lista_NodeMouseDoubleClick);
            this.Lista.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lista_DragDrop);
            this.Lista.DragEnter += new System.Windows.Forms.DragEventHandler(this.Lista_DragEnter);
            this.Lista.DragOver += new System.Windows.Forms.DragEventHandler(this.Lista_DragOver);
            this.Lista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Lista_KeyPress);
            this.Lista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Lista_KeyUp);
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
            this.imageList1.Images.SetKeyName(22, "filesave.png");
            this.imageList1.Images.SetKeyName(23, "8500.ico");
            this.imageList1.Images.SetKeyName(24, "calendario.jpg");
            this.imageList1.Images.SetKeyName(25, "Csharp.png");
            this.imageList1.Images.SetKeyName(26, "xml.png");
            this.imageList1.Images.SetKeyName(27, "xsd.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TBuscar,
            this.BBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 3;
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
            // appModel1
            // 
            this.appModel1.DataSetName = "AppModel";
//            this.appModel1.FileName = "";
            this.appModel1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Lista);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cProcesoAvance1);
            this.splitContainer1.Size = new System.Drawing.Size(284, 510);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 4;
            // 
            // cProcesoAvance1
            // 
            this.cProcesoAvance1.Analizador = null;
            this.cProcesoAvance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProcesoAvance1.Location = new System.Drawing.Point(0, 0);
            this.cProcesoAvance1.Name = "cProcesoAvance1";
            this.cProcesoAvance1.Size = new System.Drawing.Size(284, 166);
            this.cProcesoAvance1.TabIndex = 0;
            this.cProcesoAvance1.Titulo = "";
            //
            // ChistoryModelo1
            this.cHistoryModel1.Modelo = null;          
           // 
            // FormAppsAnalizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 535);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormAppsAnalizer";
            this.Text = "Analizador de aplicaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAppsAnalizer_FormClosed);
            this.Load += new System.EventHandler(this.FormAppsAnalizer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appModel1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView Lista;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TBuscar;
        private System.Windows.Forms.ToolStripButton BBuscar;
        private ObjetosModelo.AppModel appModel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ObjetosModelo.CHistoryModel cHistoryModel1;
        private CProcesoAvance cProcesoAvance1;
    }
}   