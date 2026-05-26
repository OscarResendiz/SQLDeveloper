using System.Drawing;
using System.Windows.Forms;

namespace SPGenerator.Componentes
{
    partial class CCampoRelacion
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
            this.TCampo = new System.Windows.Forms.TextBox();
            this.ComboCampo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TCampo
            // 
            this.TCampo.Dock = System.Windows.Forms.DockStyle.Left;
            this.TCampo.Location = new System.Drawing.Point(0, 0);
            this.TCampo.Name = "TCampo";
            this.TCampo.ReadOnly = true;
            this.TCampo.Size = new System.Drawing.Size(185, 20);
            this.TCampo.TabIndex = 0;
            // 
            // ComboCampo
            // 
            this.ComboCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampo.FormattingEnabled = true;
            this.ComboCampo.Location = new System.Drawing.Point(185, 0);
            this.ComboCampo.Name = "ComboCampo";
            this.ComboCampo.Size = new System.Drawing.Size(198, 21);
            this.ComboCampo.TabIndex = 1;
            // 
            // CCampoRelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComboCampo);
            this.Controls.Add(this.TCampo);
            this.Name = "CCampoRelacion";
            this.Size = new System.Drawing.Size(383, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TCampo;
        private System.Windows.Forms.ComboBox ComboCampo;
    }
}
