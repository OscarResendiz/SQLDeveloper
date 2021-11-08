namespace GridControl
{
    partial class FormDetalleFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleFiltro));
            this.label1 = new System.Windows.Forms.Label();
            this.ComboCampo = new System.Windows.Forms.ComboBox();
            this.ComboCondicion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TValor = new System.Windows.Forms.TextBox();
            this.ComboTabla = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Campo";
            // 
            // ComboCampo
            // 
            this.ComboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampo.FormattingEnabled = true;
            this.ComboCampo.Location = new System.Drawing.Point(70, 46);
            this.ComboCampo.Name = "ComboCampo";
            this.ComboCampo.Size = new System.Drawing.Size(206, 21);
            this.ComboCampo.TabIndex = 1;
            this.ComboCampo.SelectedIndexChanged += new System.EventHandler(this.ComboCampo_SelectedIndexChanged);
            // 
            // ComboCondicion
            // 
            this.ComboCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCondicion.FormattingEnabled = true;
            this.ComboCondicion.Location = new System.Drawing.Point(70, 82);
            this.ComboCondicion.Name = "ComboCondicion";
            this.ComboCondicion.Size = new System.Drawing.Size(206, 21);
            this.ComboCondicion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Condición";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor";
            // 
            // TValor
            // 
            this.TValor.Location = new System.Drawing.Point(70, 117);
            this.TValor.Name = "TValor";
            this.TValor.Size = new System.Drawing.Size(206, 20);
            this.TValor.TabIndex = 5;
            // 
            // ComboTabla
            // 
            this.ComboTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTabla.FormattingEnabled = true;
            this.ComboTabla.Location = new System.Drawing.Point(70, 12);
            this.ComboTabla.Name = "ComboTabla";
            this.ComboTabla.Size = new System.Drawing.Size(206, 21);
            this.ComboTabla.TabIndex = 7;
            this.ComboTabla.SelectedIndexChanged += new System.EventHandler(this.ComboTabla_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tabla";
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(307, 23);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 39);
            this.BAceptar.TabIndex = 8;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(307, 85);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 41);
            this.BCancelar.TabIndex = 9;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // FormDetalleFiltro
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(411, 155);
            this.ControlBox = false;
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.ComboTabla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TValor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboCondicion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboCampo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetalleFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboCampo;
        private System.Windows.Forms.ComboBox ComboCondicion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TValor;
        private System.Windows.Forms.ComboBox ComboTabla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
    }
}