namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    partial class FormLybraryGenrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLybraryGenrator));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Lista = new System.Windows.Forms.TreeView();
            this.modeloNet1 = new SQLDeveloper.Modulos.CSharpLibaryGenerator.ModeloNet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Bnuevo = new System.Windows.Forms.ToolStripButton();
            this.BAbrir = new System.Windows.Forms.ToolStripButton();
            this.BGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BGenerar = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Lmensaje = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.modeloNet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // Lista
            // 
            this.Lista.AllowDrop = true;
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.ImageIndex = 0;
            this.Lista.ImageList = this.imageList1;
            this.Lista.Location = new System.Drawing.Point(0, 25);
            this.Lista.Name = "Lista";
            this.Lista.SelectedImageIndex = 0;
            this.Lista.Size = new System.Drawing.Size(284, 468);
            this.Lista.StateImageList = this.imageList1;
            this.Lista.TabIndex = 1;
            this.Lista.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterCollapse);
            this.Lista.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterExpand);
            this.Lista.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Lista_ItemDrag);
            this.Lista.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Lista_AfterSelect);
            this.Lista.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lista_DragDrop);
            this.Lista.DragEnter += new System.Windows.Forms.DragEventHandler(this.Lista_DragEnter);
            this.Lista.DragOver += new System.Windows.Forms.DragEventHandler(this.Lista_DragOver);
            this.Lista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lista_MouseDown);
            this.Lista.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lista_MouseUp);
            // 
            // modeloNet1
            // 
            this.modeloNet1.DataSetName = "ModeloNet";
            this.modeloNet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bnuevo,
            this.BAbrir,
            this.BGuardar,
            this.toolStripSeparator1,
            this.BGenerar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Bnuevo
            // 
            this.Bnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bnuevo.Image = ((System.Drawing.Image)(resources.GetObject("Bnuevo.Image")));
            this.Bnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bnuevo.Name = "Bnuevo";
            this.Bnuevo.Size = new System.Drawing.Size(23, 22);
            this.Bnuevo.Text = "Nuevo";
            this.Bnuevo.Click += new System.EventHandler(this.Bnuevo_Click);
            // 
            // BAbrir
            // 
            this.BAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAbrir.Image = ((System.Drawing.Image)(resources.GetObject("BAbrir.Image")));
            this.BAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAbrir.Name = "BAbrir";
            this.BAbrir.Size = new System.Drawing.Size(23, 22);
            this.BAbrir.Text = "Abrir";
            this.BAbrir.Click += new System.EventHandler(this.BAbrir_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BGenerar
            // 
            this.BGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGenerar.Image = ((System.Drawing.Image)(resources.GetObject("BGenerar.Image")));
            this.BGenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(23, 22);
            this.BGenerar.Text = "Generar codigo";
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.Lmensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // Lmensaje
            // 
            this.Lmensaje.Name = "Lmensaje";
            this.Lmensaje.Size = new System.Drawing.Size(56, 17);
            this.Lmensaje.Text = "mensajes";
            // 
            // FormLybraryGenrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormLybraryGenrator";
            this.Text = "Genrador de librerias";
            this.Load += new System.EventHandler(this.FormLybraryGenrator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modeloNet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView Lista;
        private ModeloNet modeloNet1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Bnuevo;
        private System.Windows.Forms.ToolStripButton BAbrir;
        private System.Windows.Forms.ToolStripButton BGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BGenerar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel Lmensaje;
    }
}