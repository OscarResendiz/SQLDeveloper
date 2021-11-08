namespace SQLDeveloper.Modulos.Comparador
{
    partial class FormSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelector));
            this.Combo1 = new System.Windows.Forms.ComboBox();
            this.LPrimero = new System.Windows.Forms.Label();
            this.LSegundo = new System.Windows.Forms.Label();
            this.Combo2 = new System.Windows.Forms.ComboBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Combo1
            // 
            this.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo1.FormattingEnabled = true;
            this.Combo1.Location = new System.Drawing.Point(15, 47);
            this.Combo1.Name = "Combo1";
            this.Combo1.Size = new System.Drawing.Size(171, 21);
            this.Combo1.TabIndex = 0;
            // 
            // LPrimero
            // 
            this.LPrimero.AutoSize = true;
            this.LPrimero.Location = new System.Drawing.Point(12, 31);
            this.LPrimero.Name = "LPrimero";
            this.LPrimero.Size = new System.Drawing.Size(61, 13);
            this.LPrimero.TabIndex = 1;
            this.LPrimero.Text = "OpcionUno";
            // 
            // LSegundo
            // 
            this.LSegundo.AutoSize = true;
            this.LSegundo.Location = new System.Drawing.Point(209, 31);
            this.LSegundo.Name = "LSegundo";
            this.LSegundo.Size = new System.Drawing.Size(60, 13);
            this.LSegundo.TabIndex = 3;
            this.LSegundo.Text = "OpcionDos";
            // 
            // Combo2
            // 
            this.Combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo2.FormattingEnabled = true;
            this.Combo2.Location = new System.Drawing.Point(212, 47);
            this.Combo2.Name = "Combo2";
            this.Combo2.Size = new System.Drawing.Size(171, 21);
            this.Combo2.TabIndex = 2;
            // 
            // BAceptar
            // 
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(299, 100);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(84, 37);
            this.BAceptar.TabIndex = 4;
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
            this.BCancelar.Location = new System.Drawing.Point(15, 100);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(84, 37);
            this.BCancelar.TabIndex = 5;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // FormSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(396, 149);
            this.ControlBox = false;
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.LSegundo);
            this.Controls.Add(this.Combo2);
            this.Controls.Add(this.LPrimero);
            this.Controls.Add(this.Combo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Combo1;
        private System.Windows.Forms.Label LPrimero;
        private System.Windows.Forms.Label LSegundo;
        private System.Windows.Forms.ComboBox Combo2;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
    }
}