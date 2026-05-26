namespace SPGenerator
{
    partial class AsisResDelete
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
            this.ListaParametros = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TNomSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaParametros
            // 
            this.ListaParametros.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListaParametros.ForeColor = System.Drawing.Color.Black;
            this.ListaParametros.FormattingEnabled = true;
            this.ListaParametros.Location = new System.Drawing.Point(49, 146);
            this.ListaParametros.Name = "ListaParametros";
            this.ListaParametros.Size = new System.Drawing.Size(456, 147);
            this.ListaParametros.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(46, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Parámetros";
            // 
            // TNomSP
            // 
            this.TNomSP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TNomSP.ForeColor = System.Drawing.Color.Black;
            this.TNomSP.Location = new System.Drawing.Point(243, 93);
            this.TNomSP.Name = "TNomSP";
            this.TNomSP.ReadOnly = true;
            this.TNomSP.Size = new System.Drawing.Size(262, 20);
            this.TNomSP.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(46, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nombre del procedimiento almacenado";
            // 
            // TTabla
            // 
            this.TTabla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TTabla.ForeColor = System.Drawing.Color.Black;
            this.TTabla.Location = new System.Drawing.Point(148, 64);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(357, 20);
            this.TTabla.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(46, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombre de la tabla";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 43);
            this.panel1.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Navy;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(781, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Resumen del asistente para crear procedimientos almacenados de actualización";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AsisResDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ListaParametros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TNomSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TTabla);
            this.Controls.Add(this.label2);
            this.Name = "AsisResDelete";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListaParametros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TNomSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
