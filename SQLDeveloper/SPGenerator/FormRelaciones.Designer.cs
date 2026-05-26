namespace SPGenerator
{
    partial class FormRelaciones
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelaciones));
            this.label1 = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TRelacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTablaPrimaria = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CHEliminar = new System.Windows.Forms.CheckBox();
            this.CHActualizar = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cRelacionTabla1 = new SPGenerator.Componentes.CRelacionTabla();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la tabla";
            // 
            // TTabla
            // 
            this.TTabla.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TTabla.Location = new System.Drawing.Point(108, 12);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(226, 20);
            this.TTabla.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de la relación";
            // 
            // TRelacion
            // 
            this.TRelacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TRelacion.Location = new System.Drawing.Point(122, 70);
            this.TRelacion.Name = "TRelacion";
            this.TRelacion.Size = new System.Drawing.Size(212, 20);
            this.TRelacion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tabla de claves principales";
            // 
            // TTablaPrimaria
            // 
            this.TTablaPrimaria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TTablaPrimaria.Location = new System.Drawing.Point(148, 44);
            this.TTablaPrimaria.Name = "TTablaPrimaria";
            this.TTablaPrimaria.ReadOnly = true;
            this.TTablaPrimaria.Size = new System.Drawing.Size(186, 20);
            this.TTablaPrimaria.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(340, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CHEliminar);
            this.panel1.Controls.Add(this.CHActualizar);
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TRelacion);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TTablaPrimaria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 144);
            this.panel1.TabIndex = 12;
            // 
            // CHEliminar
            // 
            this.CHEliminar.AutoSize = true;
            this.CHEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHEliminar.Location = new System.Drawing.Point(9, 121);
            this.CHEliminar.Name = "CHEliminar";
            this.CHEliminar.Size = new System.Drawing.Size(121, 17);
            this.CHEliminar.TabIndex = 8;
            this.CHEliminar.Text = "Eliminar en cascada";
            this.CHEliminar.UseVisualStyleBackColor = true;
            // 
            // CHActualizar
            // 
            this.CHActualizar.AutoSize = true;
            this.CHActualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHActualizar.Location = new System.Drawing.Point(9, 98);
            this.CHActualizar.Name = "CHActualizar";
            this.CHActualizar.Size = new System.Drawing.Size(131, 17);
            this.CHActualizar.TabIndex = 7;
            this.CHActualizar.Text = "Actualizar en cascada";
            this.CHActualizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 51);
            this.panel2.TabIndex = 13;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(308, 6);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 38);
            this.BCancelar.TabIndex = 17;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Enabled = false;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(3, 6);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 38);
            this.BAceptar.TabIndex = 16;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cRelacionTabla1
            // 
            this.cRelacionTabla1.BackColor = System.Drawing.Color.Gray;
            this.cRelacionTabla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRelacionTabla1.Location = new System.Drawing.Point(0, 144);
            this.cRelacionTabla1.Name = "cRelacionTabla1";
            this.cRelacionTabla1.Size = new System.Drawing.Size(403, 251);
            this.cRelacionTabla1.TabIndex = 14;
            // 
            // FormRelaciones
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(403, 446);
            this.ControlBox = false;
            this.Controls.Add(this.cRelacionTabla1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRelaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRelaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRelaciones_FormClosing);
            this.Load += new System.EventHandler(this.FormRelaciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TRelacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTablaPrimaria;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private Componentes.CRelacionTabla cRelacionTabla1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CHEliminar;
        private System.Windows.Forms.CheckBox CHActualizar;
    }
}