namespace GeneradorSP.Componentes
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
            TCampo = new TextBox();
            ComboCampo = new ComboBox();
            SuspendLayout();
            // 
            // TCampo
            // 
            TCampo.Dock = DockStyle.Left;
            TCampo.Location = new Point(0, 0);
            TCampo.Margin = new Padding(4, 3, 4, 3);
            TCampo.Name = "TCampo";
            TCampo.ReadOnly = true;
            TCampo.Size = new Size(215, 23);
            TCampo.TabIndex = 0;
            // 
            // ComboCampo
            // 
            ComboCampo.Dock = DockStyle.Fill;
            ComboCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboCampo.FormattingEnabled = true;
            ComboCampo.Location = new Point(215, 0);
            ComboCampo.Margin = new Padding(4, 3, 4, 3);
            ComboCampo.Name = "ComboCampo";
            ComboCampo.Size = new Size(232, 23);
            ComboCampo.TabIndex = 1;
            ComboCampo.DropDown += ComboCampo_DropDown;
            // 
            // CCampoRelacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ComboCampo);
            Controls.Add(TCampo);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CCampoRelacion";
            Size = new Size(447, 25);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TCampo;
        private System.Windows.Forms.ComboBox ComboCampo;
    }
}
