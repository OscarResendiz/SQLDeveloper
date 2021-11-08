namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormChecks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChecks));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Bagregar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTabla = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListaChecks = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TRegla = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 58);
            this.panel2.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(458, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(109, 58);
            this.panel4.TabIndex = 4;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(11, 6);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(86, 43);
            this.BCerrar.TabIndex = 2;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Bagregar);
            this.panel3.Controls.Add(this.BEliminar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 58);
            this.panel3.TabIndex = 3;
            // 
            // Bagregar
            // 
            this.Bagregar.Image = ((System.Drawing.Image)(resources.GetObject("Bagregar.Image")));
            this.Bagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bagregar.Location = new System.Drawing.Point(12, 6);
            this.Bagregar.Name = "Bagregar";
            this.Bagregar.Size = new System.Drawing.Size(86, 43);
            this.Bagregar.TabIndex = 0;
            this.Bagregar.Text = "Agregar";
            this.Bagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bagregar.UseVisualStyleBackColor = true;
            this.Bagregar.Click += new System.EventHandler(this.Bagregar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(133, 6);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(86, 43);
            this.BEliminar.TabIndex = 1;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTabla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 43);
            this.panel1.TabIndex = 6;
            // 
            // LTabla
            // 
            this.LTabla.AutoSize = true;
            this.LTabla.Location = new System.Drawing.Point(13, 13);
            this.LTabla.Name = "LTabla";
            this.LTabla.Size = new System.Drawing.Size(34, 13);
            this.LTabla.TabIndex = 0;
            this.LTabla.Text = "Tabla";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaChecks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TRegla);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.TNombre);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(567, 323);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 8;
            // 
            // ListaChecks
            // 
            this.ListaChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaChecks.ImageIndex = 0;
            this.ListaChecks.ImageList = this.imageList1;
            this.ListaChecks.Location = new System.Drawing.Point(0, 0);
            this.ListaChecks.Name = "ListaChecks";
            this.ListaChecks.SelectedImageIndex = 0;
            this.ListaChecks.Size = new System.Drawing.Size(216, 323);
            this.ListaChecks.StateImageList = this.imageList1;
            this.ListaChecks.TabIndex = 0;
            this.ListaChecks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaChecks_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check.png");
            this.imageList1.Images.SetKeyName(1, "llaves.jpg");
            this.imageList1.Images.SetKeyName(2, "DIR02B.ICO");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 16);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(177, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Regla";
            // 
            // TRegla
            // 
            this.TRegla.Location = new System.Drawing.Point(53, 60);
            this.TRegla.Multiline = true;
            this.TRegla.Name = "TRegla";
            this.TRegla.ReadOnly = true;
            this.TRegla.Size = new System.Drawing.Size(282, 72);
            this.TRegla.TabIndex = 3;
            // 
            // FormChecks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 424);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChecks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checks";
            this.Load += new System.EventHandler(this.FormChecks_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Bagregar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTabla;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView ListaChecks;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox TRegla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
    }
}