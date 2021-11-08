namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class KeyWordControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyWordControl));
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChCursiva = new System.Windows.Forms.CheckBox();
            this.ChNegrita = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColorWords = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.Lista = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Bagregar = new System.Windows.Forms.ToolStripButton();
            this.BEliminar = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 7);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(176, 20);
            this.TNombre.TabIndex = 5;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // ChCursiva
            // 
            this.ChCursiva.AutoSize = true;
            this.ChCursiva.Location = new System.Drawing.Point(6, 75);
            this.ChCursiva.Name = "ChCursiva";
            this.ChCursiva.Size = new System.Drawing.Size(61, 17);
            this.ChCursiva.TabIndex = 23;
            this.ChCursiva.Text = "Cursiva";
            this.ChCursiva.UseVisualStyleBackColor = true;
            this.ChCursiva.CheckedChanged += new System.EventHandler(this.ChCursiva_CheckedChanged);
            // 
            // ChNegrita
            // 
            this.ChNegrita.AutoSize = true;
            this.ChNegrita.Location = new System.Drawing.Point(6, 43);
            this.ChNegrita.Name = "ChNegrita";
            this.ChNegrita.Size = new System.Drawing.Size(65, 17);
            this.ChNegrita.TabIndex = 22;
            this.ChNegrita.Text = "Negritas";
            this.ChNegrita.UseVisualStyleBackColor = true;
            this.ChNegrita.CheckedChanged += new System.EventHandler(this.ChNegrita_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ColorWords);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.ChNegrita);
            this.panel1.Controls.Add(this.ChCursiva);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 147);
            this.panel1.TabIndex = 28;
            // 
            // ColorWords
            // 
            this.ColorWords.Color = System.Drawing.SystemColors.Control;
            this.ColorWords.Location = new System.Drawing.Point(3, 98);
            this.ColorWords.Name = "ColorWords";
            this.ColorWords.Nombre = "Color";
            this.ColorWords.Size = new System.Drawing.Size(151, 39);
            this.ColorWords.TabIndex = 24;
            this.ColorWords.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorWords_OnColorCahnge);
            // 
            // Lista
            // 
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(0, 172);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(499, 210);
            this.Lista.TabIndex = 29;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bagregar,
            this.BEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 147);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(499, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Bagregar
            // 
            this.Bagregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bagregar.Image = ((System.Drawing.Image)(resources.GetObject("Bagregar.Image")));
            this.Bagregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bagregar.Name = "Bagregar";
            this.Bagregar.Size = new System.Drawing.Size(23, 22);
            this.Bagregar.Text = "toolStripButton1";
            this.Bagregar.Click += new System.EventHandler(this.Bagregar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(23, 22);
            this.BEliminar.Text = "toolStripButton2";
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // KeyWordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "KeyWordControl";
            this.Size = new System.Drawing.Size(499, 382);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChCursiva;
        private System.Windows.Forms.CheckBox ChNegrita;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Bagregar;
        private System.Windows.Forms.ToolStripButton BEliminar;
        private CComponetColor ColorWords;
    }
}
