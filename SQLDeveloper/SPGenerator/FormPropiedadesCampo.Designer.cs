namespace SPGenerator
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
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tlongitud = new System.Windows.Forms.TextBox();
            this.CHDefault = new System.Windows.Forms.CheckBox();
            this.TDefault = new System.Windows.Forms.TextBox();
            this.CHIncremental = new System.Windows.Forms.CheckBox();
            this.CHNulos = new System.Windows.Forms.CheckBox();
            this.CHCalculado = new System.Windows.Forms.CheckBox();
            this.TCalculado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TDocuementacion = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TNombre.Location = new System.Drawing.Point(55, 12);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(207, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TNombre_KeyDown);
            this.TNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // ComboTipos
            // 
            this.ComboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ComboTipos.FormattingEnabled = true;
            this.ComboTipos.Location = new System.Drawing.Point(55, 43);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(207, 21);
            this.ComboTipos.TabIndex = 3;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Longitud";
            // 
            // Tlongitud
            // 
            this.Tlongitud.Enabled = false;
            this.Tlongitud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Tlongitud.Location = new System.Drawing.Point(59, 70);
            this.Tlongitud.Name = "Tlongitud";
            this.Tlongitud.Size = new System.Drawing.Size(203, 20);
            this.Tlongitud.TabIndex = 5;
            this.Tlongitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tlongitud_KeyPress);
            // 
            // CHDefault
            // 
            this.CHDefault.AutoSize = true;
            this.CHDefault.BackColor = System.Drawing.Color.Transparent;
            this.CHDefault.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHDefault.Location = new System.Drawing.Point(5, 115);
            this.CHDefault.Name = "CHDefault";
            this.CHDefault.Size = new System.Drawing.Size(103, 17);
            this.CHDefault.TabIndex = 6;
            this.CHDefault.Text = "Valor por default";
            this.CHDefault.UseVisualStyleBackColor = false;
            this.CHDefault.CheckedChanged += new System.EventHandler(this.CHDefault_CheckedChanged);
            // 
            // TDefault
            // 
            this.TDefault.Enabled = false;
            this.TDefault.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TDefault.Location = new System.Drawing.Point(114, 115);
            this.TDefault.Name = "TDefault";
            this.TDefault.Size = new System.Drawing.Size(148, 20);
            this.TDefault.TabIndex = 7;
            // 
            // CHIncremental
            // 
            this.CHIncremental.AutoSize = true;
            this.CHIncremental.BackColor = System.Drawing.Color.Transparent;
            this.CHIncremental.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHIncremental.Location = new System.Drawing.Point(5, 139);
            this.CHIncremental.Name = "CHIncremental";
            this.CHIncremental.Size = new System.Drawing.Size(131, 17);
            this.CHIncremental.TabIndex = 8;
            this.CHIncremental.Text = "Valor auto incremental";
            this.CHIncremental.UseVisualStyleBackColor = false;
            // 
            // CHNulos
            // 
            this.CHNulos.AutoSize = true;
            this.CHNulos.BackColor = System.Drawing.Color.Transparent;
            this.CHNulos.Checked = true;
            this.CHNulos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHNulos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHNulos.Location = new System.Drawing.Point(6, 94);
            this.CHNulos.Name = "CHNulos";
            this.CHNulos.Size = new System.Drawing.Size(125, 17);
            this.CHNulos.TabIndex = 9;
            this.CHNulos.Text = "Permitir valores nulos";
            this.CHNulos.UseVisualStyleBackColor = false;
            // 
            // CHCalculado
            // 
            this.CHCalculado.AutoSize = true;
            this.CHCalculado.BackColor = System.Drawing.Color.Transparent;
            this.CHCalculado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CHCalculado.Location = new System.Drawing.Point(5, 162);
            this.CHCalculado.Name = "CHCalculado";
            this.CHCalculado.Size = new System.Drawing.Size(108, 17);
            this.CHCalculado.TabIndex = 10;
            this.CHCalculado.Text = "Campo calculado";
            this.CHCalculado.UseVisualStyleBackColor = false;
            this.CHCalculado.CheckedChanged += new System.EventHandler(this.CHCalculado_CheckedChanged);
            // 
            // TCalculado
            // 
            this.TCalculado.Enabled = false;
            this.TCalculado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TCalculado.Location = new System.Drawing.Point(114, 162);
            this.TCalculado.Name = "TCalculado";
            this.TCalculado.Size = new System.Drawing.Size(148, 20);
            this.TCalculado.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(2, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Documentación";
            // 
            // TDocuementacion
            // 
            this.TDocuementacion.Location = new System.Drawing.Point(5, 207);
            this.TDocuementacion.Multiline = true;
            this.TDocuementacion.Name = "TDocuementacion";
            this.TDocuementacion.Size = new System.Drawing.Size(366, 100);
            this.TDocuementacion.TabIndex = 13;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Enabled = false;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(283, 26);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 38);
            this.BAceptar.TabIndex = 14;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(283, 82);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 38);
            this.BCancelar.TabIndex = 15;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPropiedadesCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(383, 316);
            this.ControlBox = false;
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TDocuementacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TCalculado);
            this.Controls.Add(this.CHCalculado);
            this.Controls.Add(this.CHNulos);
            this.Controls.Add(this.CHIncremental);
            this.Controls.Add(this.TDefault);
            this.Controls.Add(this.CHDefault);
            this.Controls.Add(this.Tlongitud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboTipos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropiedadesCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del campo";
            this.Load += new System.EventHandler(this.FormPropiedadesCampo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboTipos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tlongitud;
        private System.Windows.Forms.CheckBox CHDefault;
        private System.Windows.Forms.TextBox TDefault;
        private System.Windows.Forms.CheckBox CHIncremental;
        private System.Windows.Forms.CheckBox CHNulos;
        private System.Windows.Forms.CheckBox CHCalculado;
        private System.Windows.Forms.TextBox TCalculado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TDocuementacion;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Timer timer1;
    }
}