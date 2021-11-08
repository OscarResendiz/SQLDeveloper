namespace SQLDeveloper.Modulos.Editores
{
    partial class CResaltar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CResaltar));
            this.CHResaltar = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BCerrar = new System.Windows.Forms.ToolStripButton();
            this.BBajar = new System.Windows.Forms.ToolStripButton();
            this.BSubir = new System.Windows.Forms.ToolStripButton();
            this.BSiguiente = new System.Windows.Forms.ToolStripButton();
            this.BColor = new System.Windows.Forms.ToolStripButton();
            this.Banterior = new System.Windows.Forms.ToolStripButton();
            this.BBricar = new System.Windows.Forms.ToolStripButton();
            this.TComentario = new System.Windows.Forms.ToolStripTextBox();
            this.TimerBrincar = new System.Windows.Forms.Timer(this.components);
            this.TTexto = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CHResaltar
            // 
            this.CHResaltar.AutoSize = true;
            this.CHResaltar.Checked = true;
            this.CHResaltar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHResaltar.Dock = System.Windows.Forms.DockStyle.Left;
            this.CHResaltar.Location = new System.Drawing.Point(0, 0);
            this.CHResaltar.Name = "CHResaltar";
            this.CHResaltar.Size = new System.Drawing.Size(15, 26);
            this.CHResaltar.TabIndex = 0;
            this.CHResaltar.UseVisualStyleBackColor = true;
            this.CHResaltar.CheckedChanged += new System.EventHandler(this.CHResaltar_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BCerrar,
            this.BBajar,
            this.BSubir,
            this.BSiguiente,
            this.BColor,
            this.Banterior,
            this.BBricar,
            this.TComentario});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(5, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(516, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BCerrar
            // 
            this.BCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(24, 24);
            this.BCerrar.Text = "Quitar";
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BBajar
            // 
            this.BBajar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBajar.Image = ((System.Drawing.Image)(resources.GetObject("BBajar.Image")));
            this.BBajar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBajar.Name = "BBajar";
            this.BBajar.Size = new System.Drawing.Size(24, 24);
            this.BBajar.Text = "Bajar";
            this.BBajar.Click += new System.EventHandler(this.BBajar_Click);
            // 
            // BSubir
            // 
            this.BSubir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSubir.Image = ((System.Drawing.Image)(resources.GetObject("BSubir.Image")));
            this.BSubir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSubir.Name = "BSubir";
            this.BSubir.Size = new System.Drawing.Size(24, 24);
            this.BSubir.Text = "Subir";
            this.BSubir.Click += new System.EventHandler(this.BSubir_Click);
            // 
            // BSiguiente
            // 
            this.BSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BSiguiente.Image")));
            this.BSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(24, 24);
            this.BSiguiente.Text = "Buscar Siguiente";
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // BColor
            // 
            this.BColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BColor.Image = ((System.Drawing.Image)(resources.GetObject("BColor.Image")));
            this.BColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BColor.Name = "BColor";
            this.BColor.Size = new System.Drawing.Size(24, 24);
            this.BColor.Text = "Cambiar color";
            this.BColor.Click += new System.EventHandler(this.BColor_Click);
            // 
            // Banterior
            // 
            this.Banterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Banterior.Image = ((System.Drawing.Image)(resources.GetObject("Banterior.Image")));
            this.Banterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Banterior.Name = "Banterior";
            this.Banterior.Size = new System.Drawing.Size(24, 24);
            this.Banterior.Text = "Buscar Anterior";
            this.Banterior.Click += new System.EventHandler(this.Banterior_Click);
            // 
            // BBricar
            // 
            this.BBricar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBricar.Image = ((System.Drawing.Image)(resources.GetObject("BBricar.Image")));
            this.BBricar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBricar.Name = "BBricar";
            this.BBricar.Size = new System.Drawing.Size(24, 24);
            this.BBricar.Text = "Parpadear";
            this.BBricar.Click += new System.EventHandler(this.BBricar_Click);
            // 
            // TComentario
            // 
            this.TComentario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TComentario.Name = "TComentario";
            this.TComentario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TComentario.Size = new System.Drawing.Size(200, 27);
            // 
            // TimerBrincar
            // 
            this.TimerBrincar.Interval = 500;
            this.TimerBrincar.Tick += new System.EventHandler(this.TimerBrincar_Tick);
            // 
            // TTexto
            // 
            this.TTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TTexto.Location = new System.Drawing.Point(15, 0);
            this.TTexto.Name = "TTexto";
            this.TTexto.ReadOnly = true;
            this.TTexto.Size = new System.Drawing.Size(501, 20);
            this.TTexto.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TTexto);
            this.panel2.Controls.Add(this.CHResaltar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 26);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // CResaltar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "CResaltar";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(526, 62);
            this.BackColorChanged += new System.EventHandler(this.PanelColor_BackColorChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CHResaltar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BCerrar;
        private System.Windows.Forms.ToolStripButton BSiguiente;
        private System.Windows.Forms.ToolStripButton BColor;
        private System.Windows.Forms.ToolStripButton Banterior;
        private System.Windows.Forms.ToolStripButton BBricar;
        private System.Windows.Forms.Timer TimerBrincar;
        private System.Windows.Forms.ToolStripButton BSubir;
        private System.Windows.Forms.ToolStripButton BBajar;
        private System.Windows.Forms.TextBox TTexto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripTextBox TComentario;
    }
}
