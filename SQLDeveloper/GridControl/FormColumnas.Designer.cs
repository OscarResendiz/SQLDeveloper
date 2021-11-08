namespace GridControl
{
    partial class FormColumnas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColumnas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BAplicar = new System.Windows.Forms.Button();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.controlColumns5 = new GridControl.ControlColumns();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 63);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BCerrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(367, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 63);
            this.panel3.TabIndex = 3;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(15, 6);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(96, 45);
            this.BCerrar.TabIndex = 1;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BAplicar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 63);
            this.panel2.TabIndex = 2;
            // 
            // BAplicar
            // 
            this.BAplicar.Image = ((System.Drawing.Image)(resources.GetObject("BAplicar.Image")));
            this.BAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAplicar.Location = new System.Drawing.Point(12, 6);
            this.BAplicar.Name = "BAplicar";
            this.BAplicar.Size = new System.Drawing.Size(96, 45);
            this.BAplicar.TabIndex = 0;
            this.BAplicar.Text = "Aplicar";
            this.BAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAplicar.UseVisualStyleBackColor = true;
            this.BAplicar.Click += new System.EventHandler(this.BAplicar_Click);
            // 
            // Contenedor
            // 
            this.Contenedor.AutoScroll = true;
            this.Contenedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Contenedor.Controls.Add(this.controlColumns5);
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(488, 227);
            this.Contenedor.TabIndex = 1;
            // 
            // controlColumns5
            // 
            this.controlColumns5.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlColumns5.Location = new System.Drawing.Point(0, 0);
            this.controlColumns5.Name = "controlColumns5";
            this.controlColumns5.Size = new System.Drawing.Size(484, 104);
            this.controlColumns5.TabIndex = 4;
            this.controlColumns5.Tabla = null;
            // 
            // FormColumnas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 290);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.panel1);
            this.Name = "FormColumnas";
            this.Text = "Mostrar Columnas";
            this.Load += new System.EventHandler(this.FormColumnas_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Contenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Button BAplicar;
        private System.Windows.Forms.Panel Contenedor;
        private ControlColumns controlColumns5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}