namespace SPGenerator.Componentes
{
    partial class CCampoTabla
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCampoTabla));
            this.TCampo = new System.Windows.Forms.TextBox();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PNULLS = new System.Windows.Forms.PictureBox();
            this.PPFK = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PNULLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPFK)).BeginInit();
            this.SuspendLayout();
            // 
            // TCampo
            // 
            this.TCampo.BackColor = System.Drawing.Color.White;
            this.TCampo.Dock = System.Windows.Forms.DockStyle.Left;
            this.TCampo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TCampo.ForeColor = System.Drawing.Color.Black;
            this.TCampo.Location = new System.Drawing.Point(31, 0);
            this.TCampo.Name = "TCampo";
            this.TCampo.ReadOnly = true;
            this.TCampo.Size = new System.Drawing.Size(92, 20);
            this.TCampo.TabIndex = 1;
            this.TCampo.Tag = "hola";
            this.TCampo.Enter += new System.EventHandler(this.TCampo_Enter);
            this.TCampo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TCampo_KeyUp);
            this.TCampo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TCampo_MouseMove);
            // 
            // TTipo
            // 
            this.TTipo.BackColor = System.Drawing.Color.White;
            this.TTipo.Dock = System.Windows.Forms.DockStyle.Left;
            this.TTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTipo.ForeColor = System.Drawing.Color.Black;
            this.TTipo.Location = new System.Drawing.Point(123, 0);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(92, 20);
            this.TTipo.TabIndex = 2;
            this.TTipo.Enter += new System.EventHandler(this.TCampo_Enter);
            this.TTipo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TTipo_KeyUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FrontPage_006.ico");
            this.imageList1.Images.SetKeyName(1, "FKPK.ico");
            this.imageList1.Images.SetKeyName(2, "Copia de FrontPage_016.ico");
            this.imageList1.Images.SetKeyName(3, "Tips.png");
            this.imageList1.Images.SetKeyName(4, "window_list.png");
            this.imageList1.Images.SetKeyName(5, "230.ico");
            // 
            // PNULLS
            // 
            this.PNULLS.BackColor = System.Drawing.SystemColors.Control;
            this.PNULLS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNULLS.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNULLS.Location = new System.Drawing.Point(215, 0);
            this.PNULLS.Name = "PNULLS";
            this.PNULLS.Size = new System.Drawing.Size(31, 20);
            this.PNULLS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PNULLS.TabIndex = 3;
            this.PNULLS.TabStop = false;
            this.PNULLS.Click += new System.EventHandler(this.PPFK_Click);
            // 
            // PPFK
            // 
            this.PPFK.BackColor = System.Drawing.SystemColors.Control;
            this.PPFK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PPFK.Dock = System.Windows.Forms.DockStyle.Left;
            this.PPFK.Location = new System.Drawing.Point(0, 0);
            this.PPFK.Name = "PPFK";
            this.PPFK.Size = new System.Drawing.Size(31, 20);
            this.PPFK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PPFK.TabIndex = 0;
            this.PPFK.TabStop = false;
            this.PPFK.Tag = "hola mundo";
            this.PPFK.Click += new System.EventHandler(this.PPFK_Click);
            this.PPFK.DoubleClick += new System.EventHandler(this.PPFK_DoubleClick);
            // 
            // CCampoTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PNULLS);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.TCampo);
            this.Controls.Add(this.PPFK);
            this.Name = "CCampoTabla";
            this.Size = new System.Drawing.Size(246, 20);
            ((System.ComponentModel.ISupportInitialize)(this.PNULLS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPFK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PPFK;
        private System.Windows.Forms.TextBox TCampo;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.PictureBox PNULLS;
        private System.Windows.Forms.ImageList imageList1;
    }
}
