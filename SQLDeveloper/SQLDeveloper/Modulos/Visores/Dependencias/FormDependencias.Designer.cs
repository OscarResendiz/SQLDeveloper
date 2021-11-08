namespace SQLDeveloper.Modulos.Visores.Dependencias
{
    partial class FormDependencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDependencias));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBDepende = new System.Windows.Forms.RadioButton();
            this.RBDependen = new System.Windows.Forms.RadioButton();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.waitControl1 = new WaitControl.WaitControl();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RBDepende);
            this.panel1.Controls.Add(this.RBDependen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 67);
            this.panel1.TabIndex = 0;
            // 
            // RBDepende
            // 
            this.RBDepende.AutoSize = true;
            this.RBDepende.Location = new System.Drawing.Point(12, 35);
            this.RBDepende.Name = "RBDepende";
            this.RBDepende.Size = new System.Drawing.Size(158, 17);
            this.RBDepende.TabIndex = 1;
            this.RBDepende.Text = "Objetos de los que depende";
            this.RBDepende.UseVisualStyleBackColor = true;
            // 
            // RBDependen
            // 
            this.RBDependen.AutoSize = true;
            this.RBDependen.Checked = true;
            this.RBDependen.Location = new System.Drawing.Point(12, 12);
            this.RBDependen.Name = "RBDependen";
            this.RBDependen.Size = new System.Drawing.Size(148, 17);
            this.RBDependen.TabIndex = 0;
            this.RBDependen.TabStop = true;
            this.RBDependen.Text = "Objetos que dependen de";
            this.RBDependen.UseVisualStyleBackColor = true;
            this.RBDependen.CheckedChanged += new System.EventHandler(this.RBDependen_CheckedChanged);
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.ContextMenuStrip = this.Menu;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList1;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 67);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.Size = new System.Drawing.Size(284, 388);
            this.ListaObjetos.StateImageList = this.imageList1;
            this.ListaObjetos.TabIndex = 2;
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
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // waitControl1
            // 
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.SystemColors.Control;
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitControl1.Location = new System.Drawing.Point(0, 455);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.SystemColors.Control;
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(284, 13);
            this.waitControl1.TabIndex = 3;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVer});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(91, 26);
            // 
            // MenuVer
            // 
            this.MenuVer.Image = ((System.Drawing.Image)(resources.GetObject("MenuVer.Image")));
            this.MenuVer.Name = "MenuVer";
            this.MenuVer.Size = new System.Drawing.Size(90, 22);
            this.MenuVer.Text = "Ver";
            this.MenuVer.Click += new System.EventHandler(this.MenuVer_Click);
            // 
            // FormDependencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 468);
            this.Controls.Add(this.ListaObjetos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.waitControl1);
            this.Name = "FormDependencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dependencias";
            this.Load += new System.EventHandler(this.FormDependencias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RBDepende;
        private System.Windows.Forms.RadioButton RBDependen;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.ImageList imageList1;
        private WaitControl.WaitControl waitControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuVer;
    }
}