namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class SpanControl
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
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChCursiva = new System.Windows.Forms.CheckBox();
            this.ChNegritas = new System.Windows.Forms.CheckBox();
            this.ChStopateol = new System.Windows.Forms.CheckBox();
            this.TInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TFin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ColoSpan = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.SuspendLayout();
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(67, 13);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(176, 20);
            this.TNombre.TabIndex = 3;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // ChCursiva
            // 
            this.ChCursiva.AutoSize = true;
            this.ChCursiva.Location = new System.Drawing.Point(20, 163);
            this.ChCursiva.Name = "ChCursiva";
            this.ChCursiva.Size = new System.Drawing.Size(61, 17);
            this.ChCursiva.TabIndex = 21;
            this.ChCursiva.Text = "Cursiva";
            this.ChCursiva.UseVisualStyleBackColor = true;
            this.ChCursiva.CheckedChanged += new System.EventHandler(this.ChCursiva_CheckedChanged);
            // 
            // ChNegritas
            // 
            this.ChNegritas.AutoSize = true;
            this.ChNegritas.Location = new System.Drawing.Point(20, 130);
            this.ChNegritas.Name = "ChNegritas";
            this.ChNegritas.Size = new System.Drawing.Size(65, 17);
            this.ChNegritas.TabIndex = 20;
            this.ChNegritas.Text = "Negritas";
            this.ChNegritas.UseVisualStyleBackColor = true;
            this.ChNegritas.CheckedChanged += new System.EventHandler(this.ChNegritas_CheckedChanged);
            // 
            // ChStopateol
            // 
            this.ChStopateol.AutoSize = true;
            this.ChStopateol.Location = new System.Drawing.Point(20, 195);
            this.ChStopateol.Name = "ChStopateol";
            this.ChStopateol.Size = new System.Drawing.Size(121, 17);
            this.ChStopateol.TabIndex = 25;
            this.ChStopateol.Text = "Abarcar solo la linea";
            this.ChStopateol.UseVisualStyleBackColor = true;
            this.ChStopateol.CheckedChanged += new System.EventHandler(this.ChStopateol_CheckedChanged);
            // 
            // TInicio
            // 
            this.TInicio.Location = new System.Drawing.Point(67, 53);
            this.TInicio.Name = "TInicio";
            this.TInicio.Size = new System.Drawing.Size(176, 20);
            this.TInicio.TabIndex = 27;
            this.TInicio.TextChanged += new System.EventHandler(this.TInicio_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Inicia";
            // 
            // TFin
            // 
            this.TFin.Location = new System.Drawing.Point(67, 91);
            this.TFin.Name = "TFin";
            this.TFin.Size = new System.Drawing.Size(176, 20);
            this.TFin.TabIndex = 29;
            this.TFin.TextChanged += new System.EventHandler(this.TFin_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Termina";
            // 
            // ColoSpan
            // 
            this.ColoSpan.Color = System.Drawing.SystemColors.Control;
            this.ColoSpan.Location = new System.Drawing.Point(20, 229);
            this.ColoSpan.Name = "ColoSpan";
            this.ColoSpan.Nombre = "Color";
            this.ColoSpan.Size = new System.Drawing.Size(137, 39);
            this.ColoSpan.TabIndex = 30;
            this.ColoSpan.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColoSpan_OnColorCahnge);
            // 
            // SpanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ColoSpan);
            this.Controls.Add(this.TFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChStopateol);
            this.Controls.Add(this.ChCursiva);
            this.Controls.Add(this.ChNegritas);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.Name = "SpanControl";
            this.Size = new System.Drawing.Size(429, 284);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChCursiva;
        private System.Windows.Forms.CheckBox ChNegritas;
        private System.Windows.Forms.CheckBox ChStopateol;
        private System.Windows.Forms.TextBox TInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TFin;
        private System.Windows.Forms.Label label4;
        private CComponetColor ColoSpan;
    }
}
