namespace SPGenerator
{
    partial class FormPropParametro2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropParametro2));
            this.TComentario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.CHNoRepetibles = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TEcepcionNoRepetibles = new System.Windows.Forms.TextBox();
            this.CHVacios = new System.Windows.Forms.CheckBox();
            this.TExcepcionVacios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TComentario
            // 
            this.TComentario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TComentario.Location = new System.Drawing.Point(15, 212);
            this.TComentario.Name = "TComentario";
            this.TComentario.Size = new System.Drawing.Size(304, 20);
            this.TComentario.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Comentarios";
            // 
            // TTipo
            // 
            this.TTipo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TTipo.Location = new System.Drawing.Point(62, 38);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(257, 20);
            this.TTipo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo";
            // 
            // TNombre
            // 
            this.TNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TNombre.Location = new System.Drawing.Point(62, 6);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(257, 20);
            this.TNombre.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(337, 94);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 42);
            this.BCancelar.TabIndex = 17;
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
            this.BAceptar.Location = new System.Drawing.Point(337, 26);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 42);
            this.BAceptar.TabIndex = 16;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // CHNoRepetibles
            // 
            this.CHNoRepetibles.AutoSize = true;
            this.CHNoRepetibles.BackColor = System.Drawing.Color.Transparent;
            this.CHNoRepetibles.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHNoRepetibles.Location = new System.Drawing.Point(15, 70);
            this.CHNoRepetibles.Name = "CHNoRepetibles";
            this.CHNoRepetibles.Size = new System.Drawing.Size(137, 17);
            this.CHNoRepetibles.TabIndex = 18;
            this.CHNoRepetibles.Text = "Validar que no se repita";
            this.CHNoRepetibles.UseVisualStyleBackColor = false;
            this.CHNoRepetibles.CheckedChanged += new System.EventHandler(this.CHNoRepetibles_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Texto de la excepción";
            // 
            // TEcepcionNoRepetibles
            // 
            this.TEcepcionNoRepetibles.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TEcepcionNoRepetibles.Location = new System.Drawing.Point(15, 106);
            this.TEcepcionNoRepetibles.Name = "TEcepcionNoRepetibles";
            this.TEcepcionNoRepetibles.Size = new System.Drawing.Size(289, 20);
            this.TEcepcionNoRepetibles.TabIndex = 20;
            // 
            // CHVacios
            // 
            this.CHVacios.AutoSize = true;
            this.CHVacios.BackColor = System.Drawing.Color.Transparent;
            this.CHVacios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHVacios.Location = new System.Drawing.Point(15, 132);
            this.CHVacios.Name = "CHVacios";
            this.CHVacios.Size = new System.Drawing.Size(94, 17);
            this.CHVacios.TabIndex = 21;
            this.CHVacios.Text = "Permitir vacios";
            this.CHVacios.UseVisualStyleBackColor = false;
            this.CHVacios.CheckedChanged += new System.EventHandler(this.CHVacios_CheckedChanged);
            // 
            // TExcepcionVacios
            // 
            this.TExcepcionVacios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TExcepcionVacios.Location = new System.Drawing.Point(15, 168);
            this.TExcepcionVacios.Name = "TExcepcionVacios";
            this.TExcepcionVacios.Size = new System.Drawing.Size(289, 20);
            this.TExcepcionVacios.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Texto de la excepción";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPropParametro2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 246);
            this.ControlBox = false;
            this.Controls.Add(this.TExcepcionVacios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CHVacios);
            this.Controls.Add(this.TEcepcionNoRepetibles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CHNoRepetibles);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TComentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropParametro2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del parámetro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPropParametro2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.TextBox TComentario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CHNoRepetibles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TEcepcionNoRepetibles;
        private System.Windows.Forms.CheckBox CHVacios;
        private System.Windows.Forms.TextBox TExcepcionVacios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}