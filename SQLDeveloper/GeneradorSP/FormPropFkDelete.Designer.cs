namespace GeneradorSP
{
    partial class FormPropFkDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropFkDelete));
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TTablaPadre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ListaParametros = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListaCampos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RBEliminar = new System.Windows.Forms.RadioButton();
            this.TBExcepcion = new System.Windows.Forms.RadioButton();
            this.TError = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BQuitar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.SuspendLayout();
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(54, 12);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(464, 20);
            this.TNombre.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre";
            // 
            // TTablaPadre
            // 
            this.TTablaPadre.Location = new System.Drawing.Point(54, 38);
            this.TTablaPadre.Name = "TTablaPadre";
            this.TTablaPadre.ReadOnly = true;
            this.TTablaPadre.Size = new System.Drawing.Size(464, 20);
            this.TTablaPadre.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tabla hija";
            // 
            // ListaParametros
            // 
            this.ListaParametros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaParametros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaParametros.FormattingEnabled = true;
            this.ListaParametros.Location = new System.Drawing.Point(308, 159);
            this.ListaParametros.Name = "ListaParametros";
            this.ListaParametros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaParametros.Size = new System.Drawing.Size(205, 238);
            this.ListaParametros.TabIndex = 39;
            this.ListaParametros.DoubleClick += new System.EventHandler(this.ListaParametros_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(310, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Validaciones";
            // 
            // ListaCampos
            // 
            this.ListaCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaCampos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaCampos.FormattingEnabled = true;
            this.ListaCampos.Location = new System.Drawing.Point(5, 159);
            this.ListaCampos.Name = "ListaCampos";
            this.ListaCampos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCampos.Size = new System.Drawing.Size(205, 238);
            this.ListaCampos.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Llaves foráneas";
            // 
            // RBEliminar
            // 
            this.RBEliminar.AutoSize = true;
            this.RBEliminar.BackColor = System.Drawing.Color.Transparent;
            this.RBEliminar.Checked = true;
            this.RBEliminar.Location = new System.Drawing.Point(5, 64);
            this.RBEliminar.Name = "RBEliminar";
            this.RBEliminar.Size = new System.Drawing.Size(157, 17);
            this.RBEliminar.TabIndex = 42;
            this.RBEliminar.TabStop = true;
            this.RBEliminar.Text = "Eliminar registro en cascada";
            this.RBEliminar.UseVisualStyleBackColor = false;
            // 
            // TBExcepcion
            // 
            this.TBExcepcion.AutoSize = true;
            this.TBExcepcion.BackColor = System.Drawing.Color.Transparent;
            this.TBExcepcion.Location = new System.Drawing.Point(5, 87);
            this.TBExcepcion.Name = "TBExcepcion";
            this.TBExcepcion.Size = new System.Drawing.Size(187, 17);
            this.TBExcepcion.TabIndex = 43;
            this.TBExcepcion.Text = "Generar excepción si hay registros";
            this.TBExcepcion.UseVisualStyleBackColor = false;
            // 
            // TError
            // 
            this.TError.Location = new System.Drawing.Point(96, 114);
            this.TError.Name = "TError";
            this.TError.Size = new System.Drawing.Size(422, 20);
            this.TError.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(4, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Mensaje de error";
            // 
            // BQuitar
            // 
            this.BQuitar.BackColor = System.Drawing.Color.Black;
            this.BQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar.Image")));
            this.BQuitar.Location = new System.Drawing.Point(216, 278);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(75, 36);
            this.BQuitar.TabIndex = 41;
            this.BQuitar.UseVisualStyleBackColor = false;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.Black;
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.Location = new System.Drawing.Point(216, 189);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(75, 36);
            this.BAgregar.TabIndex = 40;
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(354, 425);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 42);
            this.BCancelar.TabIndex = 32;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(99, 434);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 42);
            this.BAceptar.TabIndex = 31;
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
            // FormPropFkDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 488);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TError);
            this.Controls.Add(this.TBExcepcion);
            this.Controls.Add(this.RBEliminar);
            this.Controls.Add(this.BQuitar);
            this.Controls.Add(this.BAgregar);
            this.Controls.Add(this.ListaParametros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListaCampos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TTablaPadre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Name = "FormPropFkDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validación de llaves foráneas";
            this.Load += new System.EventHandler(this.FormPropFkDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TTablaPadre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.ListBox ListaParametros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ListaCampos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RBEliminar;
        private System.Windows.Forms.RadioButton TBExcepcion;
        private System.Windows.Forms.TextBox TError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private Opacador.FormOpacador formOpacador1;
    }
}