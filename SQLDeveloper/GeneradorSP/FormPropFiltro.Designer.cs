namespace GeneradorSP
{
    partial class FormPropFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropFiltro));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.ComboParametros = new System.Windows.Forms.ComboBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBDiferente = new System.Windows.Forms.RadioButton();
            this.RBMenorIgual = new System.Windows.Forms.RadioButton();
            this.RBMayoIgual = new System.Windows.Forms.RadioButton();
            this.RBMenor = new System.Windows.Forms.RadioButton();
            this.RBMayor = new System.Windows.Forms.RadioButton();
            this.RBLike = new System.Windows.Forms.RadioButton();
            this.RBIgual = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Campo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parámetro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(58, 20);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(100, 20);
            this.TNombre.TabIndex = 4;
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(58, 47);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(100, 20);
            this.TTipo.TabIndex = 5;
            // 
            // ComboParametros
            // 
            this.ComboParametros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboParametros.FormattingEnabled = true;
            this.ComboParametros.Location = new System.Drawing.Point(71, 73);
            this.ComboParametros.Name = "ComboParametros";
            this.ComboParametros.Size = new System.Drawing.Size(121, 21);
            this.ComboParametros.TabIndex = 6;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(216, 8);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(91, 43);
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
            this.BCancelar.Location = new System.Drawing.Point(216, 60);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(91, 43);
            this.BCancelar.TabIndex = 9;
            this.BCancelar.Text = "Cancear";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
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
            this.groupBox1.Location = new System.Drawing.Point(3, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 55);
            this.groupBox1.TabIndex = 10;
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
            // FormPropFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 187);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.ComboParametros);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del filtro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.ComboBox ComboParametros;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBDiferente;
        private System.Windows.Forms.RadioButton RBMenorIgual;
        private System.Windows.Forms.RadioButton RBMayoIgual;
        private System.Windows.Forms.RadioButton RBMenor;
        private System.Windows.Forms.RadioButton RBMayor;
        private System.Windows.Forms.RadioButton RBLike;
        private System.Windows.Forms.RadioButton RBIgual;
        private System.Windows.Forms.Timer timer1;
        private Opacador.FormOpacador formOpacador1;
    }
}