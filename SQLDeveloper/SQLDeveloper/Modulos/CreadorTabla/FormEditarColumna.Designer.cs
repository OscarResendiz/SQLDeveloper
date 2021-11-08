namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormEditarColumna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarColumna));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboCampos = new System.Windows.Forms.ComboBox();
            this.LCampo = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.LTabla = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.Baceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LCalculado = new System.Windows.Forms.Label();
            this.Bdefault = new System.Windows.Forms.Button();
            this.CHNulos = new System.Windows.Forms.CheckBox();
            this.TNombreCampo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TLongitud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.LLongitud = new System.Windows.Forms.Label();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ComboCampos);
            this.panel1.Controls.Add(this.LCampo);
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.LTabla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 61);
            this.panel1.TabIndex = 0;
            // 
            // ComboCampos
            // 
            this.ComboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampos.FormattingEnabled = true;
            this.ComboCampos.Location = new System.Drawing.Point(280, 11);
            this.ComboCampos.Name = "ComboCampos";
            this.ComboCampos.Size = new System.Drawing.Size(234, 21);
            this.ComboCampos.TabIndex = 3;
            this.ComboCampos.SelectedIndexChanged += new System.EventHandler(this.ComboCampos_SelectedIndexChanged);
            // 
            // LCampo
            // 
            this.LCampo.AutoSize = true;
            this.LCampo.Location = new System.Drawing.Point(239, 17);
            this.LCampo.Name = "LCampo";
            this.LCampo.Size = new System.Drawing.Size(40, 13);
            this.LCampo.TabIndex = 2;
            this.LCampo.Text = "Campo";
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(55, 12);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(163, 20);
            this.TTabla.TabIndex = 1;
            // 
            // LTabla
            // 
            this.LTabla.AutoSize = true;
            this.LTabla.Location = new System.Drawing.Point(14, 17);
            this.LTabla.Name = "LTabla";
            this.LTabla.Size = new System.Drawing.Size(34, 13);
            this.LTabla.TabIndex = 0;
            this.LTabla.Text = "Tabla";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.Baceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 72);
            this.panel2.TabIndex = 1;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(471, 15);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(89, 36);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // Baceptar
            // 
            this.Baceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Baceptar.Image = ((System.Drawing.Image)(resources.GetObject("Baceptar.Image")));
            this.Baceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Baceptar.Location = new System.Drawing.Point(12, 15);
            this.Baceptar.Name = "Baceptar";
            this.Baceptar.Size = new System.Drawing.Size(89, 36);
            this.Baceptar.TabIndex = 0;
            this.Baceptar.Text = "Aceptar";
            this.Baceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Baceptar.UseVisualStyleBackColor = true;
            this.Baceptar.Click += new System.EventHandler(this.Baceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LCalculado);
            this.groupBox1.Controls.Add(this.Bdefault);
            this.groupBox1.Controls.Add(this.CHNulos);
            this.groupBox1.Controls.Add(this.TNombreCampo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TLongitud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LLongitud);
            this.groupBox1.Controls.Add(this.ComboTipo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 86);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // LCalculado
            // 
            this.LCalculado.AutoSize = true;
            this.LCalculado.ForeColor = System.Drawing.Color.Red;
            this.LCalculado.Location = new System.Drawing.Point(6, 70);
            this.LCalculado.Name = "LCalculado";
            this.LCalculado.Size = new System.Drawing.Size(214, 13);
            this.LCalculado.TabIndex = 8;
            this.LCalculado.Text = "No se puede modificar un Campo Calculado";
            this.LCalculado.Visible = false;
            // 
            // Bdefault
            // 
            this.Bdefault.Enabled = false;
            this.Bdefault.Location = new System.Drawing.Point(454, 30);
            this.Bdefault.Name = "Bdefault";
            this.Bdefault.Size = new System.Drawing.Size(106, 23);
            this.Bdefault.TabIndex = 7;
            this.Bdefault.Text = "Quitar Deafult";
            this.Bdefault.UseVisualStyleBackColor = true;
            this.Bdefault.Click += new System.EventHandler(this.Bdefault_Click);
            // 
            // CHNulos
            // 
            this.CHNulos.AutoSize = true;
            this.CHNulos.Checked = true;
            this.CHNulos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHNulos.Location = new System.Drawing.Point(358, 36);
            this.CHNulos.Name = "CHNulos";
            this.CHNulos.Size = new System.Drawing.Size(90, 17);
            this.CHNulos.TabIndex = 6;
            this.CHNulos.Text = "Acepta Nulos";
            this.CHNulos.UseVisualStyleBackColor = true;
            // 
            // TNombreCampo
            // 
            this.TNombreCampo.Location = new System.Drawing.Point(9, 36);
            this.TNombreCampo.Name = "TNombreCampo";
            this.TNombreCampo.ReadOnly = true;
            this.TNombreCampo.Size = new System.Drawing.Size(132, 20);
            this.TNombreCampo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre ";
            // 
            // TLongitud
            // 
            this.TLongitud.Location = new System.Drawing.Point(284, 37);
            this.TLongitud.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.TLongitud.Name = "TLongitud";
            this.TLongitud.Size = new System.Drawing.Size(68, 20);
            this.TLongitud.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo";
            // 
            // LLongitud
            // 
            this.LLongitud.AutoSize = true;
            this.LLongitud.Location = new System.Drawing.Point(281, 19);
            this.LLongitud.Name = "LLongitud";
            this.LLongitud.Size = new System.Drawing.Size(48, 13);
            this.LLongitud.TabIndex = 4;
            this.LLongitud.Text = "Longitud";
            // 
            // ComboTipo
            // 
            this.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(146, 35);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(121, 21);
            this.ComboTipo.TabIndex = 3;
            this.ComboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_SelectedIndexChanged);
            // 
            // FormEditarColumna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarColumna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Columna";
            this.Load += new System.EventHandler(this.FormEditarColumna_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboCampos;
        private System.Windows.Forms.Label LCampo;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label LTabla;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button Baceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHNulos;
        private System.Windows.Forms.TextBox TNombreCampo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TLongitud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LLongitud;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Button Bdefault;
        private System.Windows.Forms.Label LCalculado;
    }
}