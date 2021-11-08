namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    partial class CProcesoAvance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CProcesoAvance));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TMensaje = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.waitControl1 = new WaitControl.WaitControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TMensaje);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 245);
            this.panel1.TabIndex = 0;
            // 
            // TMensaje
            // 
            this.TMensaje.BackColor = System.Drawing.Color.Black;
            this.TMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TMensaje.ForeColor = System.Drawing.Color.White;
            this.TMensaje.Location = new System.Drawing.Point(0, 0);
            this.TMensaje.Multiline = true;
            this.TMensaje.Name = "TMensaje";
            this.TMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TMensaje.Size = new System.Drawing.Size(515, 245);
            this.TMensaje.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 48);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LStatus);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(100, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel5.Size = new System.Drawing.Size(319, 48);
            this.panel5.TabIndex = 5;
            // 
            // LStatus
            // 
            this.LStatus.AutoSize = true;
            this.LStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStatus.ForeColor = System.Drawing.Color.Red;
            this.LStatus.Location = new System.Drawing.Point(0, 10);
            this.LStatus.Name = "LStatus";
            this.LStatus.Size = new System.Drawing.Size(20, 24);
            this.LStatus.TabIndex = 2;
            this.LStatus.Text = "_";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCancelar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 48);
            this.panel4.TabIndex = 4;
            // 
            // BCancelar
            // 
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(3, 6);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(93, 36);
            this.BCancelar.TabIndex = 3;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BCerrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(419, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(96, 48);
            this.panel3.TabIndex = 1;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(3, 7);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(83, 36);
            this.BCerrar.TabIndex = 0;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 50;
            this.waitControl1.Animar = true;
            this.waitControl1.BackColor = System.Drawing.Color.Gray;
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitControl1.Location = new System.Drawing.Point(0, 245);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.Gray;
            this.waitControl1.SegundoColor = System.Drawing.Color.Navy;
            this.waitControl1.Size = new System.Drawing.Size(515, 16);
            this.waitControl1.TabIndex = 2;
            // 
            // CProcesoAvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.waitControl1);
            this.Controls.Add(this.panel2);
            this.Name = "CProcesoAvance";
            this.Size = new System.Drawing.Size(515, 309);
            this.Load += new System.EventHandler(this.FormProcesoAvance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCerrar;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.TextBox TMensaje;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LStatus;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}   