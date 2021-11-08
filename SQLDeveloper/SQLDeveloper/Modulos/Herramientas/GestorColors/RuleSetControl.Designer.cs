namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class RuleSetControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TDelimitadores = new System.Windows.Forms.TextBox();
            this.CHignorecase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delimitadores";
            // 
            // TDelimitadores
            // 
            this.TDelimitadores.Location = new System.Drawing.Point(94, 20);
            this.TDelimitadores.Name = "TDelimitadores";
            this.TDelimitadores.Size = new System.Drawing.Size(216, 20);
            this.TDelimitadores.TabIndex = 1;
            this.TDelimitadores.TextChanged += new System.EventHandler(this.TDelimitadores_TextChanged);
            // 
            // CHignorecase
            // 
            this.CHignorecase.AutoSize = true;
            this.CHignorecase.Location = new System.Drawing.Point(21, 57);
            this.CHignorecase.Name = "CHignorecase";
            this.CHignorecase.Size = new System.Drawing.Size(252, 17);
            this.CHignorecase.TabIndex = 2;
            this.CHignorecase.Text = "Ignorar sensibilidad de mayúsculas y minúsculas";
            this.CHignorecase.UseVisualStyleBackColor = true;
            this.CHignorecase.CheckedChanged += new System.EventHandler(this.CHignorecase_CheckedChanged);
            // 
            // RuleSetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CHignorecase);
            this.Controls.Add(this.TDelimitadores);
            this.Controls.Add(this.label1);
            this.Name = "RuleSetControl";
            this.Size = new System.Drawing.Size(459, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TDelimitadores;
        private System.Windows.Forms.CheckBox CHignorecase;
    }
}
