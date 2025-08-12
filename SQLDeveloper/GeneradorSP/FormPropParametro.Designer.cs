namespace GeneradorSP
{
    partial class FormPropParametro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropParametro));
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBDiferente = new System.Windows.Forms.RadioButton();
            this.RBMenorIgual = new System.Windows.Forms.RadioButton();
            this.RBMayoIgual = new System.Windows.Forms.RadioButton();
            this.RBMenor = new System.Windows.Forms.RadioButton();
            this.RBMayor = new System.Windows.Forms.RadioButton();
            this.RBLike = new System.Windows.Forms.RadioButton();
            this.RBIgual = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TComentario = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 16);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(257, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(62, 48);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(257, 20);
            this.TTipo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBDiferente);
            this.groupBox1.Controls.Add(this.RBMenorIgual);
            this.groupBox1.Controls.Add(this.RBMayoIgual);
            this.groupBox1.Controls.Add(this.RBMenor);
            this.groupBox1.Controls.Add(this.RBMayor);
            this.groupBox1.Controls.Add(this.RBLike);
            this.groupBox1.Controls.Add(this.RBIgual);
            this.groupBox1.Location = new System.Drawing.Point(15, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de filtro";
            // 
            // RBDiferente
            // 
            this.RBDiferente.AutoSize = true;
            this.RBDiferente.Location = new System.Drawing.Point(130, 19);
            this.RBDiferente.Name = "RBDiferente";
            this.RBDiferente.Size = new System.Drawing.Size(34, 17);
            this.RBDiferente.TabIndex = 6;
            this.RBDiferente.Text = "!=";
            this.RBDiferente.UseVisualStyleBackColor = true;
            // 
            // RBMenorIgual
            // 
            this.RBMenorIgual.AutoSize = true;
            this.RBMenorIgual.Location = new System.Drawing.Point(250, 19);
            this.RBMenorIgual.Name = "RBMenorIgual";
            this.RBMenorIgual.Size = new System.Drawing.Size(37, 17);
            this.RBMenorIgual.TabIndex = 5;
            this.RBMenorIgual.Text = "<=";
            this.RBMenorIgual.UseVisualStyleBackColor = true;
            // 
            // RBMayoIgual
            // 
            this.RBMayoIgual.AutoSize = true;
            this.RBMayoIgual.Location = new System.Drawing.Point(207, 19);
            this.RBMayoIgual.Name = "RBMayoIgual";
            this.RBMayoIgual.Size = new System.Drawing.Size(37, 17);
            this.RBMayoIgual.TabIndex = 4;
            this.RBMayoIgual.Text = ">=";
            this.RBMayoIgual.UseVisualStyleBackColor = true;
            // 
            // RBMenor
            // 
            this.RBMenor.AutoSize = true;
            this.RBMenor.Location = new System.Drawing.Point(170, 19);
            this.RBMenor.Name = "RBMenor";
            this.RBMenor.Size = new System.Drawing.Size(31, 17);
            this.RBMenor.TabIndex = 3;
            this.RBMenor.Text = "<";
            this.RBMenor.UseVisualStyleBackColor = true;
            // 
            // RBMayor
            // 
            this.RBMayor.AutoSize = true;
            this.RBMayor.Location = new System.Drawing.Point(93, 19);
            this.RBMayor.Name = "RBMayor";
            this.RBMayor.Size = new System.Drawing.Size(31, 17);
            this.RBMayor.TabIndex = 2;
            this.RBMayor.Text = ">";
            this.RBMayor.UseVisualStyleBackColor = true;
            // 
            // RBLike
            // 
            this.RBLike.AutoSize = true;
            this.RBLike.Location = new System.Drawing.Point(46, 19);
            this.RBLike.Name = "RBLike";
            this.RBLike.Size = new System.Drawing.Size(41, 17);
            this.RBLike.TabIndex = 1;
            this.RBLike.Text = "like";
            this.RBLike.UseVisualStyleBackColor = true;
            // 
            // RBIgual
            // 
            this.RBIgual.AutoSize = true;
            this.RBIgual.Checked = true;
            this.RBIgual.Location = new System.Drawing.Point(6, 19);
            this.RBIgual.Name = "RBIgual";
            this.RBIgual.Size = new System.Drawing.Size(34, 17);
            this.RBIgual.TabIndex = 0;
            this.RBIgual.TabStop = true;
            this.RBIgual.Text = "= ";
            this.RBIgual.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comentarios";
            // 
            // TComentario
            // 
            this.TComentario.Location = new System.Drawing.Point(15, 171);
            this.TComentario.Name = "TComentario";
            this.TComentario.Size = new System.Drawing.Size(304, 20);
            this.TComentario.TabIndex = 7;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(337, 19);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 42);
            this.BAceptar.TabIndex = 8;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(337, 80);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 42);
            this.BCancelar.TabIndex = 9;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
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
            // FormPropParametro
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(439, 210);
            this.ControlBox = false;
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TComentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropParametro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del parametro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBDiferente;
        private System.Windows.Forms.RadioButton RBMenorIgual;
        private System.Windows.Forms.RadioButton RBMayoIgual;
        private System.Windows.Forms.RadioButton RBMenor;
        private System.Windows.Forms.RadioButton RBMayor;
        private System.Windows.Forms.RadioButton RBLike;
        private System.Windows.Forms.RadioButton RBIgual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TComentario;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private Opacador.FormOpacador formOpacador1;
    }
}