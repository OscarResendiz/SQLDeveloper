namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormAgregarCampo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarCampo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBDefault = new System.Windows.Forms.RadioButton();
            this.RBCalculado = new System.Windows.Forms.RadioButton();
            this.TValor = new System.Windows.Forms.TextBox();
            this.CHInicializado = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TIncremento = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.TValorInicial = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.CHAutoIncremental = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CHNulos = new System.Windows.Forms.CheckBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TLongitud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.LLongitud = new System.Windows.Forms.Label();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIncremento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TValorInicial)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 39);
            this.panel1.TabIndex = 0;
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(53, 6);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(395, 20);
            this.TTabla.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 61);
            this.panel2.TabIndex = 1;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(356, 7);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 43);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(12, 7);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 43);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 206);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBDefault);
            this.groupBox3.Controls.Add(this.RBCalculado);
            this.groupBox3.Controls.Add(this.TValor);
            this.groupBox3.Controls.Add(this.CHInicializado);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 57);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Avanzado";
            // 
            // RBDefault
            // 
            this.RBDefault.AutoSize = true;
            this.RBDefault.Checked = true;
            this.RBDefault.Location = new System.Drawing.Point(239, 17);
            this.RBDefault.Name = "RBDefault";
            this.RBDefault.Size = new System.Drawing.Size(102, 17);
            this.RBDefault.TabIndex = 14;
            this.RBDefault.TabStop = true;
            this.RBDefault.Text = "Valor por default";
            this.RBDefault.UseVisualStyleBackColor = true;
            // 
            // RBCalculado
            // 
            this.RBCalculado.AutoSize = true;
            this.RBCalculado.Location = new System.Drawing.Point(341, 17);
            this.RBCalculado.Name = "RBCalculado";
            this.RBCalculado.Size = new System.Drawing.Size(107, 17);
            this.RBCalculado.TabIndex = 13;
            this.RBCalculado.Text = "Campo calculado";
            this.RBCalculado.UseVisualStyleBackColor = true;
            // 
            // TValor
            // 
            this.TValor.Location = new System.Drawing.Point(93, 17);
            this.TValor.Name = "TValor";
            this.TValor.Size = new System.Drawing.Size(140, 20);
            this.TValor.TabIndex = 12;
            // 
            // CHInicializado
            // 
            this.CHInicializado.AutoSize = true;
            this.CHInicializado.Location = new System.Drawing.Point(6, 19);
            this.CHInicializado.Name = "CHInicializado";
            this.CHInicializado.Size = new System.Drawing.Size(79, 17);
            this.CHInicializado.TabIndex = 9;
            this.CHInicializado.Text = "Valor inicial";
            this.CHInicializado.UseVisualStyleBackColor = true;
            this.CHInicializado.CheckedChanged += new System.EventHandler(this.CHInicializado_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TIncremento);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TValorInicial);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CHAutoIncremental);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autoincremental (Identidad)";
            // 
            // TIncremento
            // 
            this.TIncremento.Location = new System.Drawing.Point(343, 27);
            this.TIncremento.Name = "TIncremento";
            this.TIncremento.Size = new System.Drawing.Size(70, 20);
            this.TIncremento.TabIndex = 4;
            this.TIncremento.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Incremento";
            // 
            // TValorInicial
            // 
            this.TValorInicial.Location = new System.Drawing.Point(181, 27);
            this.TValorInicial.Name = "TValorInicial";
            this.TValorInicial.Size = new System.Drawing.Size(85, 20);
            this.TValorInicial.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Inicia en";
            // 
            // CHAutoIncremental
            // 
            this.CHAutoIncremental.AutoSize = true;
            this.CHAutoIncremental.Location = new System.Drawing.Point(6, 27);
            this.CHAutoIncremental.Name = "CHAutoIncremental";
            this.CHAutoIncremental.Size = new System.Drawing.Size(116, 17);
            this.CHAutoIncremental.TabIndex = 0;
            this.CHAutoIncremental.Text = "Es autoincremental";
            this.CHAutoIncremental.UseVisualStyleBackColor = true;
            this.CHAutoIncremental.CheckedChanged += new System.EventHandler(this.CHAutoIncremental_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHNulos);
            this.groupBox1.Controls.Add(this.TNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TLongitud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LLongitud);
            this.groupBox1.Controls.Add(this.ComboTipo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 86);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
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
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(9, 36);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(132, 20);
            this.TNombre.TabIndex = 1;
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
            // FormAgregarCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(461, 306);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgregarCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar campo";
            this.Load += new System.EventHandler(this.FormAgregarCampo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIncremento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TValorInicial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CHAutoIncremental;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHNulos;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TLongitud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LLongitud;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TValor;
        private System.Windows.Forms.CheckBox CHInicializado;
        private System.Windows.Forms.NumericUpDown TIncremento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TValorInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RBDefault;
        private System.Windows.Forms.RadioButton RBCalculado;
    }
}