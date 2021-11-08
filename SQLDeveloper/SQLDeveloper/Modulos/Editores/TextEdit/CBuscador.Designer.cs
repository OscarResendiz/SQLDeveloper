namespace SQLDeveloper.Modulos.Editores
{
    partial class CBuscador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBuscador));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.CHPalabraCompleta = new System.Windows.Forms.CheckBox();
            this.CHMayuscMinus = new System.Windows.Forms.CheckBox();
            this.CHRemplazar = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.BAnterior = new System.Windows.Forms.ToolStripButton();
            this.TBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.BSiguiente = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BResaltar = new System.Windows.Forms.ToolStripButton();
            this.BmarcarTodo = new System.Windows.Forms.ToolStripButton();
            this.PanelRemplazar = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BRemplazar = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BRemplazarTodo = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.TRemplazar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelResaltar = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CHTodos = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.PanelRemplazar.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 110);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.CHPalabraCompleta);
            this.panel7.Controls.Add(this.CHMayuscMinus);
            this.panel7.Controls.Add(this.CHRemplazar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(280, 72);
            this.panel7.TabIndex = 5;
            // 
            // CHPalabraCompleta
            // 
            this.CHPalabraCompleta.AutoSize = true;
            this.CHPalabraCompleta.Location = new System.Drawing.Point(10, 23);
            this.CHPalabraCompleta.Name = "CHPalabraCompleta";
            this.CHPalabraCompleta.Size = new System.Drawing.Size(118, 17);
            this.CHPalabraCompleta.TabIndex = 4;
            this.CHPalabraCompleta.Text = "Palabras completas";
            this.CHPalabraCompleta.UseVisualStyleBackColor = true;
            // 
            // CHMayuscMinus
            // 
            this.CHMayuscMinus.AutoSize = true;
            this.CHMayuscMinus.Location = new System.Drawing.Point(10, 4);
            this.CHMayuscMinus.Name = "CHMayuscMinus";
            this.CHMayuscMinus.Size = new System.Drawing.Size(197, 17);
            this.CHMayuscMinus.TabIndex = 3;
            this.CHMayuscMinus.Text = "Sensible a Mayúsculas y minúsculas";
            this.CHMayuscMinus.UseVisualStyleBackColor = true;
            // 
            // CHRemplazar
            // 
            this.CHRemplazar.AutoSize = true;
            this.CHRemplazar.Location = new System.Drawing.Point(10, 46);
            this.CHRemplazar.Name = "CHRemplazar";
            this.CHRemplazar.Size = new System.Drawing.Size(76, 17);
            this.CHRemplazar.TabIndex = 2;
            this.CHRemplazar.Text = "Remplazar";
            this.CHRemplazar.UseVisualStyleBackColor = true;
            this.CHRemplazar.CheckedChanged += new System.EventHandler(this.CHRemplazar_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 34);
            this.panel2.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.BAnterior,
            this.TBuscar,
            this.BSiguiente,
            this.toolStripSeparator1,
            this.BResaltar,
            this.BmarcarTodo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(276, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 28);
            this.toolStripLabel1.Text = "Buscar";
            // 
            // BAnterior
            // 
            this.BAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAnterior.Image = ((System.Drawing.Image)(resources.GetObject("BAnterior.Image")));
            this.BAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(28, 28);
            this.BAnterior.Text = "toolStripButton1";
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            // 
            // TBuscar
            // 
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(100, 31);
            // 
            // BSiguiente
            // 
            this.BSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BSiguiente.Image")));
            this.BSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(28, 28);
            this.BSiguiente.Text = "toolStripButton2";
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // BResaltar
            // 
            this.BResaltar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BResaltar.Image = ((System.Drawing.Image)(resources.GetObject("BResaltar.Image")));
            this.BResaltar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BResaltar.Name = "BResaltar";
            this.BResaltar.Size = new System.Drawing.Size(28, 28);
            this.BResaltar.Text = "toolStripButton3";
            this.BResaltar.Click += new System.EventHandler(this.BResaltar_Click);
            // 
            // BmarcarTodo
            // 
            this.BmarcarTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BmarcarTodo.Image = ((System.Drawing.Image)(resources.GetObject("BmarcarTodo.Image")));
            this.BmarcarTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BmarcarTodo.Name = "BmarcarTodo";
            this.BmarcarTodo.Size = new System.Drawing.Size(28, 28);
            this.BmarcarTodo.Text = "Resaltar todo";
            this.BmarcarTodo.Click += new System.EventHandler(this.BmarcarTodo_Click);
            // 
            // PanelRemplazar
            // 
            this.PanelRemplazar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelRemplazar.Controls.Add(this.panel10);
            this.PanelRemplazar.Controls.Add(this.panel9);
            this.PanelRemplazar.Controls.Add(this.panel8);
            this.PanelRemplazar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelRemplazar.Location = new System.Drawing.Point(0, 110);
            this.PanelRemplazar.Name = "PanelRemplazar";
            this.PanelRemplazar.Size = new System.Drawing.Size(280, 81);
            this.PanelRemplazar.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.BRemplazar);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(167, 36);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(109, 41);
            this.panel10.TabIndex = 2;
            // 
            // BRemplazar
            // 
            this.BRemplazar.Image = ((System.Drawing.Image)(resources.GetObject("BRemplazar.Image")));
            this.BRemplazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BRemplazar.Location = new System.Drawing.Point(12, 5);
            this.BRemplazar.Name = "BRemplazar";
            this.BRemplazar.Size = new System.Drawing.Size(92, 34);
            this.BRemplazar.TabIndex = 0;
            this.BRemplazar.Text = "Siguiente";
            this.BRemplazar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BRemplazar.UseVisualStyleBackColor = true;
            this.BRemplazar.Click += new System.EventHandler(this.BRemplazar_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BRemplazarTodo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 36);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(100, 41);
            this.panel9.TabIndex = 1;
            // 
            // BRemplazarTodo
            // 
            this.BRemplazarTodo.Image = ((System.Drawing.Image)(resources.GetObject("BRemplazarTodo.Image")));
            this.BRemplazarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BRemplazarTodo.Location = new System.Drawing.Point(8, 5);
            this.BRemplazarTodo.Name = "BRemplazarTodo";
            this.BRemplazarTodo.Size = new System.Drawing.Size(77, 34);
            this.BRemplazarTodo.TabIndex = 1;
            this.BRemplazarTodo.Text = "Todo";
            this.BRemplazarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BRemplazarTodo.UseVisualStyleBackColor = true;
            this.BRemplazarTodo.Click += new System.EventHandler(this.BRemplazarTodo_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.TRemplazar);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.panel8.Size = new System.Drawing.Size(276, 36);
            this.panel8.TabIndex = 0;
            // 
            // TRemplazar
            // 
            this.TRemplazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRemplazar.Location = new System.Drawing.Point(112, 10);
            this.TRemplazar.Name = "TRemplazar";
            this.TRemplazar.Size = new System.Drawing.Size(159, 20);
            this.TRemplazar.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Remplazar texto con:";
            // 
            // PanelResaltar
            // 
            this.PanelResaltar.AutoScroll = true;
            this.PanelResaltar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelResaltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelResaltar.Location = new System.Drawing.Point(0, 208);
            this.PanelResaltar.Name = "PanelResaltar";
            this.PanelResaltar.Size = new System.Drawing.Size(280, 255);
            this.PanelResaltar.TabIndex = 7;
            // 
            // CHTodos
            // 
            this.CHTodos.AutoSize = true;
            this.CHTodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.CHTodos.Location = new System.Drawing.Point(0, 191);
            this.CHTodos.Name = "CHTodos";
            this.CHTodos.Size = new System.Drawing.Size(280, 17);
            this.CHTodos.TabIndex = 8;
            this.CHTodos.Text = "Todos";
            this.CHTodos.UseVisualStyleBackColor = true;
            this.CHTodos.CheckedChanged += new System.EventHandler(this.CHTodos_CheckedChanged);
            // 
            // CBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelResaltar);
            this.Controls.Add(this.CHTodos);
            this.Controls.Add(this.PanelRemplazar);
            this.Controls.Add(this.panel1);
            this.Name = "CBuscador";
            this.Size = new System.Drawing.Size(280, 463);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PanelRemplazar.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox CHRemplazar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PanelRemplazar;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BRemplazar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BRemplazarTodo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox TRemplazar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelResaltar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox CHPalabraCompleta;
        private System.Windows.Forms.CheckBox CHMayuscMinus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton BAnterior;
        private System.Windows.Forms.ToolStripTextBox TBuscar;
        private System.Windows.Forms.ToolStripButton BSiguiente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BResaltar;
        private System.Windows.Forms.ToolStripButton BmarcarTodo;
        private System.Windows.Forms.CheckBox CHTodos;
    }
}
