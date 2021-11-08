namespace Modelador.UI
{
    partial class FormPropiedadesCampo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropiedadesCampo));
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboTipoDato = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TLongitud = new System.Windows.Forms.NumericUpDown();
            this.ChPk = new System.Windows.Forms.CheckBox();
            this.ChNull = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChCalculado = new System.Windows.Forms.CheckBox();
            this.TFormula = new System.Windows.Forms.TextBox();
            this.ChDefault = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TDefault = new System.Windows.Forms.TextBox();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.PanelDefault = new System.Windows.Forms.Panel();
            this.PanelFormula = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TComentarios = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).BeginInit();
            this.PanelDefault.SuspendLayout();
            this.PanelFormula.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Campo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(60, 22);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(208, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de dato";
            // 
            // ComboTipoDato
            // 
            this.ComboTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipoDato.FormattingEnabled = true;
            this.ComboTipoDato.Location = new System.Drawing.Point(90, 98);
            this.ComboTipoDato.Name = "ComboTipoDato";
            this.ComboTipoDato.Size = new System.Drawing.Size(178, 21);
            this.ComboTipoDato.TabIndex = 3;
            this.ComboTipoDato.SelectedIndexChanged += new System.EventHandler(this.ComboTipoDato_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Longitud";
            // 
            // TLongitud
            // 
            this.TLongitud.Location = new System.Drawing.Point(70, 133);
            this.TLongitud.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.TLongitud.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.TLongitud.Name = "TLongitud";
            this.TLongitud.Size = new System.Drawing.Size(120, 20);
            this.TLongitud.TabIndex = 5;
            // 
            // ChPk
            // 
            this.ChPk.AutoSize = true;
            this.ChPk.Location = new System.Drawing.Point(19, 179);
            this.ChPk.Name = "ChPk";
            this.ChPk.Size = new System.Drawing.Size(91, 17);
            this.ChPk.TabIndex = 6;
            this.ChPk.Text = "Llave primaria";
            this.ChPk.UseVisualStyleBackColor = true;
            // 
            // ChNull
            // 
            this.ChNull.AutoSize = true;
            this.ChNull.Checked = true;
            this.ChNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChNull.Location = new System.Drawing.Point(19, 203);
            this.ChNull.Name = "ChNull";
            this.ChNull.Size = new System.Drawing.Size(90, 17);
            this.ChNull.TabIndex = 7;
            this.ChNull.Text = "Acepta Nulos";
            this.ChNull.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Formula";
            // 
            // ChCalculado
            // 
            this.ChCalculado.AutoSize = true;
            this.ChCalculado.Location = new System.Drawing.Point(7, 19);
            this.ChCalculado.Name = "ChCalculado";
            this.ChCalculado.Size = new System.Drawing.Size(109, 17);
            this.ChCalculado.TabIndex = 9;
            this.ChCalculado.Text = "Campo Calculado";
            this.ChCalculado.UseVisualStyleBackColor = true;
            this.ChCalculado.CheckedChanged += new System.EventHandler(this.ChCalculado_CheckedChanged);
            // 
            // TFormula
            // 
            this.TFormula.Location = new System.Drawing.Point(53, 8);
            this.TFormula.Name = "TFormula";
            this.TFormula.Size = new System.Drawing.Size(202, 20);
            this.TFormula.TabIndex = 10;
            // 
            // ChDefault
            // 
            this.ChDefault.AutoSize = true;
            this.ChDefault.Location = new System.Drawing.Point(141, 19);
            this.ChDefault.Name = "ChDefault";
            this.ChDefault.Size = new System.Drawing.Size(87, 17);
            this.ChDefault.TabIndex = 11;
            this.ChDefault.Text = "Valor Default";
            this.ChDefault.UseVisualStyleBackColor = true;
            this.ChDefault.CheckedChanged += new System.EventHandler(this.ChDefault_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre del default";
            // 
            // TDefault
            // 
            this.TDefault.Location = new System.Drawing.Point(106, 11);
            this.TDefault.Name = "TDefault";
            this.TDefault.Size = new System.Drawing.Size(146, 20);
            this.TDefault.TabIndex = 13;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(309, 81);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(86, 38);
            this.BCancelar.TabIndex = 15;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(309, 22);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(86, 38);
            this.BAceptar.TabIndex = 14;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            // 
            // PanelDefault
            // 
            this.PanelDefault.Controls.Add(this.label5);
            this.PanelDefault.Controls.Add(this.TDefault);
            this.PanelDefault.Location = new System.Drawing.Point(6, 87);
            this.PanelDefault.Name = "PanelDefault";
            this.PanelDefault.Size = new System.Drawing.Size(316, 45);
            this.PanelDefault.TabIndex = 16;
            // 
            // PanelFormula
            // 
            this.PanelFormula.Controls.Add(this.label4);
            this.PanelFormula.Controls.Add(this.TFormula);
            this.PanelFormula.Location = new System.Drawing.Point(7, 42);
            this.PanelFormula.Name = "PanelFormula";
            this.PanelFormula.Size = new System.Drawing.Size(314, 39);
            this.PanelFormula.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChCalculado);
            this.groupBox1.Controls.Add(this.PanelFormula);
            this.groupBox1.Controls.Add(this.ChDefault);
            this.groupBox1.Controls.Add(this.PanelDefault);
            this.groupBox1.Location = new System.Drawing.Point(12, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 148);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TComentarios
            // 
            this.TComentarios.Location = new System.Drawing.Point(16, 64);
            this.TComentarios.Name = "TComentarios";
            this.TComentarios.Size = new System.Drawing.Size(252, 20);
            this.TComentarios.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Comentarios";
            // 
            // FormPropiedadesCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(402, 402);
            this.ControlBox = false;
            this.Controls.Add(this.TComentarios);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.ChNull);
            this.Controls.Add(this.ChPk);
            this.Controls.Add(this.TLongitud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboTipoDato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPropiedadesCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del campo";
            this.Load += new System.EventHandler(this.FormPropiedadesCampo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLongitud)).EndInit();
            this.PanelDefault.ResumeLayout(false);
            this.PanelDefault.PerformLayout();
            this.PanelFormula.ResumeLayout(false);
            this.PanelFormula.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboTipoDato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TLongitud;
        private System.Windows.Forms.CheckBox ChPk;
        private System.Windows.Forms.CheckBox ChNull;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChCalculado;
        private System.Windows.Forms.TextBox TFormula;
        private System.Windows.Forms.CheckBox ChDefault;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TDefault;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel PanelDefault;
        private System.Windows.Forms.Panel PanelFormula;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TComentarios;
        private System.Windows.Forms.Label label6;
    }
}