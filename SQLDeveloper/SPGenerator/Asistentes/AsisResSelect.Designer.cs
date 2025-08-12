namespace SPGenerator
{
    partial class AsisResSelect
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ListaParametros = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TNomSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Resumen del asistente para crear procedimientos almacenados de Selecci´´on";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ListaParametros
            // 
            this.ListaParametros.BackColor = System.Drawing.Color.White;
            this.ListaParametros.ForeColor = System.Drawing.Color.Black;
            this.ListaParametros.FormattingEnabled = true;
            this.ListaParametros.Location = new System.Drawing.Point(121, 177);
            this.ListaParametros.Name = "ListaParametros";
            this.ListaParametros.Size = new System.Drawing.Size(456, 147);
            this.ListaParametros.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(118, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Parámetros";
            // 
            // TNomSP
            // 
            this.TNomSP.BackColor = System.Drawing.Color.White;
            this.TNomSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TNomSP.Location = new System.Drawing.Point(315, 124);
            this.TNomSP.Name = "TNomSP";
            this.TNomSP.ReadOnly = true;
            this.TNomSP.Size = new System.Drawing.Size(262, 20);
            this.TNomSP.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(118, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre del procedimiento almacenado";
            // 
            // TTabla
            // 
            this.TTabla.BackColor = System.Drawing.Color.White;
            this.TTabla.ForeColor = System.Drawing.Color.Black;
            this.TTabla.Location = new System.Drawing.Point(220, 95);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(357, 20);
            this.TTabla.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(118, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre de la tabla";
            // 
            // AsisResSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ListaParametros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TNomSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TTabla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Name = "AsisResSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextColor.CTextColor cTextColor1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox ListaParametros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TNomSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label2;
    }
}
