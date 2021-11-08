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
            this.Banterior = new System.Windows.Forms.ToolStripButton();
            this.BSiguiente = new System.Windows.Forms.ToolStripButton();
            this.BColor = new System.Windows.Forms.ToolStripButton();
            this.BCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BBricar = new System.Windows.Forms.ToolStripButton();
            this.TimerBrincar = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CHResaltar
            // 
            this.CHResaltar.AutoSize = true;
            this.CHResaltar.Checked = true;
            this.CHResaltar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHResaltar.Dock = System.Windows.Forms.DockStyle.Left;
            this.CHResaltar.Location = new System.Drawing.Point(5, 5);
            this.CHResaltar.Name = "CHResaltar";
            this.CHResaltar.Size = new System.Drawing.Size(80, 24);
            this.CHResaltar.TabIndex = 0;
            this.CHResaltar.Text = "checkBox1";
            this.CHResaltar.UseVisualStyleBackColor = true;
            this.CHResaltar.CheckedChanged += new System.EventHandler(this.CHResaltar_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BCerrar,
            this.BSiguiente,
            this.BColor,
            this.Banterior,
            this.BBricar});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(112, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(236, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 24);
            this.panel1.TabIndex = 5;
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
            // TimerBrincar
            // 
            this.TimerBrincar.Interval = 500;
            this.TimerBrincar.Tick += new System.EventHandler(this.TimerBrincar_Tick);
            // 
            // CResaltar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CHResaltar);
            this.Name = "CResaltar";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(353, 34);
            this.BackColorChanged += new System.EventHandler(this.PanelColor_BackColorChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton BBricar;
        private System.Windows.Forms.Timer TimerBrincar;
    }
}
