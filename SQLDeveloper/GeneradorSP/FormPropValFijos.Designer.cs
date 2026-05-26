namespace GeneradorSP
{
    partial class FormPropValFijos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropValFijos));
            this.TTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.TValor = new System.Windows.Forms.TextBox();
            this.RBValor = new System.Windows.Forms.RadioButton();
            this.RBTabla = new System.Windows.Forms.RadioButton();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaFiltros = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BQuitar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.ListaCampos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboCampo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaOrdenar = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BQuitar2 = new System.Windows.Forms.Button();
            this.BAgregar2 = new System.Windows.Forms.Button();
            this.ListaCampo2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(54, 44);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(257, 20);
            this.TTipo.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tipo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(54, 12);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(257, 20);
            this.TNombre.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre";
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(329, 76);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 42);
            this.BCancelar.TabIndex = 24;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(329, 15);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 42);
            this.BAceptar.TabIndex = 23;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            // 
            // TValor
            // 
            this.TValor.Location = new System.Drawing.Point(63, 70);
            this.TValor.Name = "TValor";
            this.TValor.Size = new System.Drawing.Size(100, 20);
            this.TValor.TabIndex = 26;
            // 
            // RBValor
            // 
            this.RBValor.AutoSize = true;
            this.RBValor.BackColor = System.Drawing.Color.Transparent;
            this.RBValor.Location = new System.Drawing.Point(7, 72);
            this.RBValor.Name = "RBValor";
            this.RBValor.Size = new System.Drawing.Size(49, 17);
            this.RBValor.TabIndex = 27;
            this.RBValor.TabStop = true;
            this.RBValor.Text = "Valor";
            this.RBValor.UseVisualStyleBackColor = false;
            // 
            // RBTabla
            // 
            this.RBTabla.AutoSize = true;
            this.RBTabla.BackColor = System.Drawing.Color.Transparent;
            this.RBTabla.Location = new System.Drawing.Point(7, 101);
            this.RBTabla.Name = "RBTabla";
            this.RBTabla.Size = new System.Drawing.Size(103, 17);
            this.RBTabla.TabIndex = 28;
            this.RBTabla.TabStop = true;
            this.RBTabla.Text = "Desde una tabla";
            this.RBTabla.UseVisualStyleBackColor = false;
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(10, 124);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(145, 20);
            this.TTabla.TabIndex = 30;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Black;
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.Location = new System.Drawing.Point(161, 119);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(52, 42);
            this.BBuscar.TabIndex = 31;
            this.BBuscar.Tag = "Buscar tabla";
            this.BBuscar.Text = "...";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // BCrear
            // 
            this.BCrear.BackColor = System.Drawing.Color.Black;
            this.BCrear.Image = ((System.Drawing.Image)(resources.GetObject("BCrear.Image")));
            this.BCrear.Location = new System.Drawing.Point(219, 119);
            this.BCrear.Name = "BCrear";
            this.BCrear.Size = new System.Drawing.Size(49, 42);
            this.BCrear.TabIndex = 32;
            this.BCrear.Tag = "Crear Tabla";
            this.BCrear.UseVisualStyleBackColor = false;
            this.BCrear.Click += new System.EventHandler(this.BCrear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ListaFiltros);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BQuitar);
            this.panel1.Controls.Add(this.BAgregar);
            this.panel1.Controls.Add(this.ListaCampos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 221);
            this.panel1.TabIndex = 33;
            // 
            // ListaFiltros
            // 
            this.ListaFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaFiltros.FormattingEnabled = true;
            this.ListaFiltros.Location = new System.Drawing.Point(255, 32);
            this.ListaFiltros.Name = "ListaFiltros";
            this.ListaFiltros.Size = new System.Drawing.Size(135, 173);
            this.ListaFiltros.TabIndex = 5;
            this.ListaFiltros.DoubleClick += new System.EventHandler(this.ListaFiltros_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filtros";
            // 
            // BQuitar
            // 
            this.BQuitar.BackColor = System.Drawing.Color.Black;
            this.BQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar.Image")));
            this.BQuitar.Location = new System.Drawing.Point(157, 120);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(75, 40);
            this.BQuitar.TabIndex = 3;
            this.BQuitar.UseVisualStyleBackColor = false;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.Black;
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.Location = new System.Drawing.Point(157, 51);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(75, 40);
            this.BAgregar.TabIndex = 2;
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // ListaCampos
            // 
            this.ListaCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaCampos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaCampos.FormattingEnabled = true;
            this.ListaCampos.Location = new System.Drawing.Point(3, 32);
            this.ListaCampos.Name = "ListaCampos";
            this.ListaCampos.Size = new System.Drawing.Size(137, 173);
            this.ListaCampos.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Campos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Campo a asignar";
            // 
            // ComboCampo
            // 
            this.ComboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampo.FormattingEnabled = true;
            this.ComboCampo.Location = new System.Drawing.Point(105, 400);
            this.ComboCampo.Name = "ComboCampo";
            this.ComboCampo.Size = new System.Drawing.Size(205, 21);
            this.ComboCampo.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ListaOrdenar);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.BQuitar2);
            this.panel2.Controls.Add(this.BAgregar2);
            this.panel2.Controls.Add(this.ListaCampo2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(7, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 180);
            this.panel2.TabIndex = 36;
            // 
            // ListaOrdenar
            // 
            this.ListaOrdenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaOrdenar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaOrdenar.FormattingEnabled = true;
            this.ListaOrdenar.Location = new System.Drawing.Point(253, 26);
            this.ListaOrdenar.Name = "ListaOrdenar";
            this.ListaOrdenar.Size = new System.Drawing.Size(137, 134);
            this.ListaOrdenar.TabIndex = 6;
            this.ListaOrdenar.DoubleClick += new System.EventHandler(this.ListaOrdenar_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ordenar por";
            // 
            // BQuitar2
            // 
            this.BQuitar2.BackColor = System.Drawing.Color.Black;
            this.BQuitar2.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar2.Image")));
            this.BQuitar2.Location = new System.Drawing.Point(157, 98);
            this.BQuitar2.Name = "BQuitar2";
            this.BQuitar2.Size = new System.Drawing.Size(75, 40);
            this.BQuitar2.TabIndex = 4;
            this.BQuitar2.UseVisualStyleBackColor = false;
            this.BQuitar2.Click += new System.EventHandler(this.BQuitar2_Click);
            // 
            // BAgregar2
            // 
            this.BAgregar2.BackColor = System.Drawing.Color.Black;
            this.BAgregar2.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar2.Image")));
            this.BAgregar2.Location = new System.Drawing.Point(157, 39);
            this.BAgregar2.Name = "BAgregar2";
            this.BAgregar2.Size = new System.Drawing.Size(75, 40);
            this.BAgregar2.TabIndex = 3;
            this.BAgregar2.UseVisualStyleBackColor = false;
            this.BAgregar2.Click += new System.EventHandler(this.BAgregar2_Click);
            // 
            // ListaCampo2
            // 
            this.ListaCampo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaCampo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaCampo2.FormattingEnabled = true;
            this.ListaCampo2.Location = new System.Drawing.Point(9, 26);
            this.ListaCampo2.Name = "ListaCampo2";
            this.ListaCampo2.Size = new System.Drawing.Size(137, 134);
            this.ListaCampo2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Campos";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Gray;
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 10;
            this.formOpacador1.Visible = true;
            // 
            // FormPropValFijos
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(435, 619);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ComboCampo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BCrear);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.TTabla);
            this.Controls.Add(this.RBTabla);
            this.Controls.Add(this.RBValor);
            this.Controls.Add(this.TValor);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropValFijos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del campo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TValor;
        private System.Windows.Forms.RadioButton RBValor;
        private System.Windows.Forms.RadioButton RBTabla;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListaFiltros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.ListBox ListaCampos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboCampo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox ListaCampo2;
        private System.Windows.Forms.ListBox ListaOrdenar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BQuitar2;
        private System.Windows.Forms.Button BAgregar2;
        private System.Windows.Forms.Timer timer1;
        private Opacador.FormOpacador formOpacador1;
    }
}