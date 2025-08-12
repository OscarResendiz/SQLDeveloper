namespace GeneradorSP.Componentes
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
            components = new System.ComponentModel.Container();
            TCampo = new TextBox();
            TTipo = new TextBox();
            imageList1 = new ImageList(components);
            PNULLS = new PictureBox();
            PPFK = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PNULLS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PPFK).BeginInit();
            SuspendLayout();
            // 
            // TCampo
            // 
            TCampo.BackColor = Color.Black;
            TCampo.Dock = DockStyle.Left;
            TCampo.Font = new Font("Microsoft Sans Serif", 8.25F);
            TCampo.ForeColor = Color.FromArgb(192, 192, 255);
            TCampo.Location = new Point(36, 0);
            TCampo.Margin = new Padding(4, 3, 4, 3);
            TCampo.Name = "TCampo";
            TCampo.ReadOnly = true;
            TCampo.Size = new Size(107, 20);
            TCampo.TabIndex = 1;
            TCampo.Tag = "hola";
            TCampo.Enter += TCampo_Enter;
            TCampo.KeyUp += TCampo_KeyUp;
            TCampo.MouseMove += TCampo_MouseMove;
            // 
            // TTipo
            // 
            TTipo.BackColor = Color.Black;
            TTipo.Dock = DockStyle.Left;
            TTipo.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TTipo.ForeColor = Color.FromArgb(192, 192, 255);
            TTipo.Location = new Point(143, 0);
            TTipo.Margin = new Padding(4, 3, 4, 3);
            TTipo.Name = "TTipo";
            TTipo.ReadOnly = true;
            TTipo.Size = new Size(107, 20);
            TTipo.TabIndex = 2;
            TTipo.Enter += TCampo_Enter;
            TTipo.KeyUp += TTipo_KeyUp;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // PNULLS
            // 
            PNULLS.BackColor = Color.FromArgb(64, 64, 64);
            PNULLS.BorderStyle = BorderStyle.FixedSingle;
            PNULLS.Dock = DockStyle.Left;
            PNULLS.Location = new Point(250, 0);
            PNULLS.Margin = new Padding(4, 3, 4, 3);
            PNULLS.Name = "PNULLS";
            PNULLS.Size = new Size(36, 23);
            PNULLS.SizeMode = PictureBoxSizeMode.StretchImage;
            PNULLS.TabIndex = 3;
            PNULLS.TabStop = false;
            PNULLS.Click += PPFK_Click;
            // 
            // PPFK
            // 
            PPFK.BackColor = Color.FromArgb(64, 64, 64);
            PPFK.BorderStyle = BorderStyle.FixedSingle;
            PPFK.Dock = DockStyle.Left;
            PPFK.Location = new Point(0, 0);
            PPFK.Margin = new Padding(4, 3, 4, 3);
            PPFK.Name = "PPFK";
            PPFK.Size = new Size(36, 23);
            PPFK.SizeMode = PictureBoxSizeMode.StretchImage;
            PPFK.TabIndex = 0;
            PPFK.TabStop = false;
            PPFK.Tag = "hola mundo";
            PPFK.Click += PPFK_Click;
            PPFK.DoubleClick += PPFK_DoubleClick;
            // 
            // CCampoTabla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            Controls.Add(PNULLS);
            Controls.Add(TTipo);
            Controls.Add(TCampo);
            Controls.Add(PPFK);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CCampoTabla";
            Size = new Size(287, 23);
            ((System.ComponentModel.ISupportInitialize)PNULLS).EndInit();
            ((System.ComponentModel.ISupportInitialize)PPFK).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PPFK;
        private System.Windows.Forms.TextBox TCampo;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.PictureBox PNULLS;
        private System.Windows.Forms.ImageList imageList1;
    }
}
