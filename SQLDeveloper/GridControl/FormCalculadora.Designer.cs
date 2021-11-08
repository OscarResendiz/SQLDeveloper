namespace GridControl
{
    partial class FormCalculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculadora));
            this.label2 = new System.Windows.Forms.Label();
            this.ComboCampo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboOperacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BCerrar = new System.Windows.Forms.Button();
            this.BCalcular = new System.Windows.Forms.Button();
            this.TResultado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Campo";
            // 
            // ComboCampo
            // 
            this.ComboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampo.FormattingEnabled = true;
            this.ComboCampo.Location = new System.Drawing.Point(50, 21);
            this.ComboCampo.Name = "ComboCampo";
            this.ComboCampo.Size = new System.Drawing.Size(206, 21);
            this.ComboCampo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operación";
            // 
            // ComboOperacion
            // 
            this.ComboOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboOperacion.FormattingEnabled = true;
            this.ComboOperacion.Location = new System.Drawing.Point(77, 47);
            this.ComboOperacion.Name = "ComboOperacion";
            this.ComboOperacion.Size = new System.Drawing.Size(179, 21);
            this.ComboOperacion.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resultado =";
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(278, 60);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(86, 37);
            this.BCerrar.TabIndex = 8;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BCalcular
            // 
            this.BCalcular.Image = ((System.Drawing.Image)(resources.GetObject("BCalcular.Image")));
            this.BCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCalcular.Location = new System.Drawing.Point(278, 12);
            this.BCalcular.Name = "BCalcular";
            this.BCalcular.Size = new System.Drawing.Size(86, 37);
            this.BCalcular.TabIndex = 9;
            this.BCalcular.Text = "Calcular";
            this.BCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCalcular.UseVisualStyleBackColor = true;
            this.BCalcular.Click += new System.EventHandler(this.BCalcular_Click);
            // 
            // TResultado
            // 
            this.TResultado.Location = new System.Drawing.Point(80, 89);
            this.TResultado.Name = "TResultado";
            this.TResultado.ReadOnly = true;
            this.TResultado.Size = new System.Drawing.Size(176, 20);
            this.TResultado.TabIndex = 10;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 134);
            this.ControlBox = false;
            this.Controls.Add(this.TResultado);
            this.Controls.Add(this.BCalcular);
            this.Controls.Add(this.BCerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboOperacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboCampo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboCampo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboOperacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Button BCalcular;
        private System.Windows.Forms.TextBox TResultado;
    }
}