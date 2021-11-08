namespace SQLDeveloper.Modulos.ProyectAdmin
{
    partial class FormComentario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComentario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BAceptar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BFuente = new System.Windows.Forms.ToolStripButton();
            this.BColor = new System.Windows.Forms.ToolStripButton();
            this.BBakColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BIzquierda = new System.Windows.Forms.ToolStripButton();
            this.Bcentrado = new System.Windows.Forms.ToolStripButton();
            this.BDerecha = new System.Windows.Forms.ToolStripButton();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 60);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(365, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 60);
            this.panel3.TabIndex = 1;
            // 
            // BAceptar
            // 
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(3, 6);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(88, 42);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 60);
            this.panel2.TabIndex = 0;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(3, 6);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(88, 42);
            this.BCancelar.TabIndex = 0;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(465, 263);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BFuente,
            this.BColor,
            this.BBakColor,
            this.toolStripSeparator1,
            this.BIzquierda,
            this.Bcentrado,
            this.BDerecha});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(465, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BFuente
            // 
            this.BFuente.Image = ((System.Drawing.Image)(resources.GetObject("BFuente.Image")));
            this.BFuente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BFuente.Name = "BFuente";
            this.BFuente.Size = new System.Drawing.Size(63, 22);
            this.BFuente.Text = "Fuente";
            this.BFuente.Click += new System.EventHandler(this.BFuente_Click);
            // 
            // BColor
            // 
            this.BColor.Image = ((System.Drawing.Image)(resources.GetObject("BColor.Image")));
            this.BColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BColor.Name = "BColor";
            this.BColor.Size = new System.Drawing.Size(56, 22);
            this.BColor.Text = "Color";
            this.BColor.Click += new System.EventHandler(this.BColor_Click);
            // 
            // BBakColor
            // 
            this.BBakColor.Image = ((System.Drawing.Image)(resources.GetObject("BBakColor.Image")));
            this.BBakColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBakColor.Name = "BBakColor";
            this.BBakColor.Size = new System.Drawing.Size(107, 22);
            this.BBakColor.Text = "Color de fondo";
            this.BBakColor.Click += new System.EventHandler(this.BBakColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BIzquierda
            // 
            this.BIzquierda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BIzquierda.Image = ((System.Drawing.Image)(resources.GetObject("BIzquierda.Image")));
            this.BIzquierda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BIzquierda.Name = "BIzquierda";
            this.BIzquierda.Size = new System.Drawing.Size(23, 22);
            this.BIzquierda.Text = "toolStripButton1";
            this.BIzquierda.Click += new System.EventHandler(this.BIzquierda_Click);
            // 
            // Bcentrado
            // 
            this.Bcentrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bcentrado.Image = ((System.Drawing.Image)(resources.GetObject("Bcentrado.Image")));
            this.Bcentrado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bcentrado.Name = "Bcentrado";
            this.Bcentrado.Size = new System.Drawing.Size(23, 22);
            this.Bcentrado.Text = "toolStripButton2";
            this.Bcentrado.Click += new System.EventHandler(this.Bcentrado_Click);
            // 
            // BDerecha
            // 
            this.BDerecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDerecha.Image = ((System.Drawing.Image)(resources.GetObject("BDerecha.Image")));
            this.BDerecha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDerecha.Name = "BDerecha";
            this.BDerecha.Size = new System.Drawing.Size(23, 22);
            this.BDerecha.Text = "toolStripButton3";
            this.BDerecha.Click += new System.EventHandler(this.BDerecha_Click);
            // 
            // FormComentario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(465, 348);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComentario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comentarios";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BFuente;
        private System.Windows.Forms.ToolStripButton BColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BIzquierda;
        private System.Windows.Forms.ToolStripButton Bcentrado;
        private System.Windows.Forms.ToolStripButton BDerecha;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton BBakColor;
    }
}