namespace GeneradorSP
{
    partial class AsisResSelect
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cTextColor1 = new TextColor.CTextColor(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(781, 453);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // cTextColor1
            // 
            this.cTextColor1.BackColor = System.Drawing.Color.Black;
            this.cTextColor1.ColorCadena = System.Drawing.Color.White;
            this.cTextColor1.ColorComentario = System.Drawing.Color.Red;
            this.cTextColor1.ColorIdentificador = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorNumero = System.Drawing.Color.Cyan;
            this.cTextColor1.ColorOtro = System.Drawing.Color.Red;
            this.cTextColor1.ColorPalabraRserevada = System.Drawing.Color.Navy;
            this.cTextColor1.ColorSimbolo = System.Drawing.Color.Lime;
            this.cTextColor1.ColorVariable = System.Drawing.Color.Red;
            this.cTextColor1.RichTextBox = this.richTextBox1;
            this.cTextColor1.Tiempo = 500;
            this.cTextColor1.OnCambiaFoco += new TextColor.OnCambiaFocoEvent(this.cTextColor1_OnCambiaFoco);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 406);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // AsisResSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "AsisResSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private TextColor.CTextColor cTextColor1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
