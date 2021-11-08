namespace SQLDeveloper.Modulos.Editores
{
    partial class FormBuscador
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
            this.cBuscador1 = new SQLDeveloper.Modulos.Editores.CBuscador();
            this.SuspendLayout();
            // 
            // cBuscador1
            // 
            this.cBuscador1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBuscador1.Editor = null;
            this.cBuscador1.Location = new System.Drawing.Point(0, 0);
            this.cBuscador1.Name = "cBuscador1";
            this.cBuscador1.Size = new System.Drawing.Size(288, 496);
            this.cBuscador1.TabIndex = 0;
            // 
            // FormBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 496);
            this.Controls.Add(this.cBuscador1);
            this.Name = "FormBuscador";
            this.Text = "Buscar";
            this.ResumeLayout(false);

        }

        #endregion

        private CBuscador cBuscador1;
    }
}