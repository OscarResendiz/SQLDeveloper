namespace Modelador.Arbol
{
    partial class CArbol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CArbol));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(294, 486);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeView1_KeyPress);
            this.treeView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyUp);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
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
            this.imageList1.Images.SetKeyName(28, "campo.jpeg");
            // 
            // CArbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "CArbol";
            this.Size = new System.Drawing.Size(294, 486);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
