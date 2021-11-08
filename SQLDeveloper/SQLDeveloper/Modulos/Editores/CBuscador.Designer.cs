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
            this.panel5 = new System.Windows.Forms.Panel();
            this.BResaltar = new System.Windows.Forms.Button();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BAnterior = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(302, 158);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.CHPalabraCompleta);
            this.panel7.Controls.Add(this.CHMayuscMinus);
            this.panel7.Controls.Add(this.CHRemplazar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 85);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(302, 73);
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
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 85);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BResaltar);
            this.panel5.Controls.Add(this.BSiguiente);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(96, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(202, 48);
            this.panel5.TabIndex = 6;
            // 
            // BResaltar
            // 
            this.BResaltar.Image = ((System.Drawing.Image)(resources.GetObject("BResaltar.Image")));
            this.BResaltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BResaltar.Location = new System.Drawing.Point(7, 6);
            this.BResaltar.Name = "BResaltar";
            this.BResaltar.Size = new System.Drawing.Size(92, 38);
            this.BResaltar.TabIndex = 0;
            this.BResaltar.Text = "Resaltar";
            this.BResaltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BResaltar.UseVisualStyleBackColor = true;
            this.BResaltar.Click += new System.EventHandler(this.BResaltar_Click);
            // 
            // BSiguiente
            // 
            this.BSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BSiguiente.Image")));
            this.BSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSiguiente.Location = new System.Drawing.Point(105, 4);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(89, 41);
            this.BSiguiente.TabIndex = 3;
            this.BSiguiente.Text = "Siguiente";
            this.BSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BSiguiente.UseVisualStyleBackColor = true;
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BAnterior);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 48);
            this.panel4.TabIndex = 5;
            // 
            // BAnterior
            // 
            this.BAnterior.Image = ((System.Drawing.Image)(resources.GetObject("BAnterior.Image")));
            this.BAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAnterior.Location = new System.Drawing.Point(8, 6);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(82, 40);
            this.BAnterior.TabIndex = 2;
            this.BAnterior.Text = "Anterior";
            this.BAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAnterior.UseVisualStyleBackColor = true;
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TBuscar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.panel3.Size = new System.Drawing.Size(298, 33);
            this.panel3.TabIndex = 4;
            // 
            // TBuscar
            // 
            this.TBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBuscar.Location = new System.Drawing.Point(90, 10);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(203, 20);
            this.TBuscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto a Buscar: ";
            // 
            // PanelRemplazar
            // 
            this.PanelRemplazar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelRemplazar.Controls.Add(this.panel10);
            this.PanelRemplazar.Controls.Add(this.panel9);
            this.PanelRemplazar.Controls.Add(this.panel8);
            this.PanelRemplazar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelRemplazar.Location = new System.Drawing.Point(0, 158);
            this.PanelRemplazar.Name = "PanelRemplazar";
            this.PanelRemplazar.Size = new System.Drawing.Size(302, 81);
            this.PanelRemplazar.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.BRemplazar);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(189, 36);
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
            this.panel8.Size = new System.Drawing.Size(298, 36);
            this.panel8.TabIndex = 0;
            // 
            // TRemplazar
            // 
            this.TRemplazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRemplazar.Location = new System.Drawing.Point(112, 10);
            this.TRemplazar.Name = "TRemplazar";
            this.TRemplazar.Size = new System.Drawing.Size(181, 20);
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
            this.PanelResaltar.Location = new System.Drawing.Point(0, 239);
            this.PanelResaltar.Name = "PanelResaltar";
            this.PanelResaltar.Size = new System.Drawing.Size(302, 224);
            this.PanelResaltar.TabIndex = 7;
            // 
            // CBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelResaltar);
            this.Controls.Add(this.PanelRemplazar);
            this.Controls.Add(this.panel1);
            this.Name = "CBuscador";
            this.Size = new System.Drawing.Size(302, 463);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PanelRemplazar.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox CHRemplazar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelRemplazar;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BRemplazar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BRemplazarTodo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox TRemplazar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelResaltar;
        private System.Windows.Forms.Button BResaltar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox CHPalabraCompleta;
        private System.Windows.Forms.CheckBox CHMayuscMinus;
    }
}
