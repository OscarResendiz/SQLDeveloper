namespace SPGenerator
{
    partial class AsisGenLLave
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
            this.CHGenLLave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CHGenLLave
            // 
            this.CHGenLLave.AutoSize = true;
            this.CHGenLLave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHGenLLave.ForeColor = System.Drawing.Color.Black;
            this.CHGenLLave.Location = new System.Drawing.Point(196, 183);
            this.CHGenLLave.Name = "CHGenLLave";
            this.CHGenLLave.Size = new System.Drawing.Size(250, 24);
            this.CHGenLLave.TabIndex = 0;
            this.CHGenLLave.Text = "Generar llave automáticamente";
            this.CHGenLLave.UseVisualStyleBackColor = true;
            // 
            // AsisGenLLave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.CHGenLLave);
            this.Name = "AsisGenLLave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CHGenLLave;
    }
}
