namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class DigitsControl
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
            this.TNombre = new System.Windows.Forms.TextBox();
            this.CHNegritas = new System.Windows.Forms.CheckBox();
            this.CHCursiva = new System.Windows.Forms.CheckBox();
            this.ColorCmponet = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(65, 17);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(176, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // CHNegritas
            // 
            this.CHNegritas.AutoSize = true;
            this.CHNegritas.Location = new System.Drawing.Point(18, 60);
            this.CHNegritas.Name = "CHNegritas";
            this.CHNegritas.Size = new System.Drawing.Size(65, 17);
            this.CHNegritas.TabIndex = 2;
            this.CHNegritas.Text = "Negritas";
            this.CHNegritas.UseVisualStyleBackColor = true;
            this.CHNegritas.CheckedChanged += new System.EventHandler(this.CHNegritas_CheckedChanged);
            // 
            // CHCursiva
            // 
            this.CHCursiva.AutoSize = true;
            this.CHCursiva.Location = new System.Drawing.Point(18, 93);
            this.CHCursiva.Name = "CHCursiva";
            this.CHCursiva.Size = new System.Drawing.Size(61, 17);
            this.CHCursiva.TabIndex = 3;
            this.CHCursiva.Text = "Cursiva";
            this.CHCursiva.UseVisualStyleBackColor = true;
            this.CHCursiva.CheckedChanged += new System.EventHandler(this.CHCursiva_CheckedChanged);
            // 
            // ColorCmponet
            // 
            this.ColorCmponet.Color = System.Drawing.SystemColors.Control;
            this.ColorCmponet.Location = new System.Drawing.Point(18, 126);
            this.ColorCmponet.Name = "ColorCmponet";
            this.ColorCmponet.Nombre = "Color";
            this.ColorCmponet.Size = new System.Drawing.Size(142, 39);
            this.ColorCmponet.TabIndex = 4;
            this.ColorCmponet.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorCmponet_OnColorCahnge);
            // 
            // DigitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ColorCmponet);
            this.Controls.Add(this.CHCursiva);
            this.Controls.Add(this.CHNegritas);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.Name = "DigitsControl";
            this.Size = new System.Drawing.Size(389, 253);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.CheckBox CHNegritas;
        private System.Windows.Forms.CheckBox CHCursiva;
        private CComponetColor ColorCmponet;
    }
}
