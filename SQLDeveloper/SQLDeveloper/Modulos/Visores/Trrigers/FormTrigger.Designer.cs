namespace SQLDeveloper.Modulos.Visores.Trrigers
{
    partial class FormTrigger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrigger));
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList1;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 0);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.Size = new System.Drawing.Size(284, 476);
            this.ListaObjetos.StateImageList = this.imageList1;
            this.ListaObjetos.TabIndex = 0;
            this.ListaObjetos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListaObjetos_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Tabla.png");
            this.imageList1.Images.SetKeyName(1, "Vista.ico");
            this.imageList1.Images.SetKeyName(2, "funcion.png");
            this.imageList1.Images.SetKeyName(3, "SP.ICO");
            this.imageList1.Images.SetKeyName(4, "trriger.jpg");
            this.imageList1.Images.SetKeyName(5, "Shaded Right Tab.ico");
            this.imageList1.Images.SetKeyName(6, "Table Field Insert.jpg");
            this.imageList1.Images.SetKeyName(7, "UpdateTable.png");
            this.imageList1.Images.SetKeyName(8, "deletetable.jpg");
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVer,
            this.MenuEliminar});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(133, 48);
            // 
            // MenuVer
            // 
            this.MenuVer.Image = ((System.Drawing.Image)(resources.GetObject("MenuVer.Image")));
            this.MenuVer.Name = "MenuVer";
            this.MenuVer.Size = new System.Drawing.Size(132, 22);
            this.MenuVer.Text = "Ver Codigo";
            this.MenuVer.Click += new System.EventHandler(this.MenuVer_Click);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEliminar.Image")));
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(132, 22);
            this.MenuEliminar.Text = "Eliminar";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // FormTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 476);
            this.Controls.Add(this.ListaObjetos);
            this.Name = "FormTrigger";
            this.Text = "Trrigers";
            this.Load += new System.EventHandler(this.FormTrriger_Load);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuVer;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
    }
}