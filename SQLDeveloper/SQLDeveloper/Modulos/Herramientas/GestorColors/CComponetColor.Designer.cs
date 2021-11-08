namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class CComponetColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CComponetColor));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BColor = new System.Windows.Forms.Button();
            this.PanelColor = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(42, 14);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(44, 13);
            this.LNombre.TabIndex = 0;
            this.LNombre.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(124, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 39);
            this.panel1.TabIndex = 1;
            // 
            // BColor
            // 
            this.BColor.Image = ((System.Drawing.Image)(resources.GetObject("BColor.Image")));
            this.BColor.Location = new System.Drawing.Point(3, 3);
            this.BColor.Name = "BColor";
            this.BColor.Size = new System.Drawing.Size(53, 35);
            this.BColor.TabIndex = 0;
            this.BColor.UseVisualStyleBackColor = true;
            this.BColor.Click += new System.EventHandler(this.BColor_Click);
            // 
            // PanelColor
            // 
            this.PanelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelColor.Location = new System.Drawing.Point(3, 7);
            this.PanelColor.Name = "PanelColor";
            this.PanelColor.Size = new System.Drawing.Size(33, 27);
            this.PanelColor.TabIndex = 2;
            // 
            // CComponetColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelColor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LNombre);
            this.Name = "CComponetColor";
            this.Size = new System.Drawing.Size(184, 39);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BColor;
        private System.Windows.Forms.Panel PanelColor;

    }
}
