namespace SQLDeveloper.Modulos.Visores.Relaciones
{
    partial class FormRelaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelaciones));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(5, "database-process-icon.png");
            this.imageList1.Images.SetKeyName(6, "Shaded Right Tab.ico");
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList1;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 0);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.Size = new System.Drawing.Size(284, 493);
            this.ListaObjetos.StateImageList = this.imageList1;
            this.ListaObjetos.TabIndex = 5;
            this.ListaObjetos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListaObjetos_MouseUp);
            // 
            // FormRelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 493);
            this.Controls.Add(this.ListaObjetos);
            this.Name = "FormRelaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relaciones de tablas";
            this.Load += new System.EventHandler(this.FormRelaciones_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView ListaObjetos;
    }
}