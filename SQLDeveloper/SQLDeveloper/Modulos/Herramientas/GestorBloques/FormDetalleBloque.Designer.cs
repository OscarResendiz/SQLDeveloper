namespace SQLDeveloper.Modulos.Herramientas.GestorBloques
{
    partial class FormDetalleBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleBloque));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TTextoInicial = new System.Windows.Forms.TextBox();
            this.TTextoFinal = new System.Windows.Forms.TextBox();
            this.TCadenaRemplazo = new System.Windows.Forms.TextBox();
            this.ChRemplazo = new System.Windows.Forms.CheckBox();
            this.CHTabulador = new System.Windows.Forms.CheckBox();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.TLongitudMinima = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TLongitudMinima)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Texto final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cadena de remplazo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Longitud minima";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 15);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(221, 20);
            this.TNombre.TabIndex = 7;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // TTextoInicial
            // 
            this.TTextoInicial.Location = new System.Drawing.Point(81, 41);
            this.TTextoInicial.Name = "TTextoInicial";
            this.TTextoInicial.Size = new System.Drawing.Size(202, 20);
            this.TTextoInicial.TabIndex = 8;
            this.TTextoInicial.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // TTextoFinal
            // 
            this.TTextoFinal.Location = new System.Drawing.Point(81, 69);
            this.TTextoFinal.Name = "TTextoFinal";
            this.TTextoFinal.Size = new System.Drawing.Size(202, 20);
            this.TTextoFinal.TabIndex = 9;
            this.TTextoFinal.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // TCadenaRemplazo
            // 
            this.TCadenaRemplazo.Location = new System.Drawing.Point(122, 95);
            this.TCadenaRemplazo.Name = "TCadenaRemplazo";
            this.TCadenaRemplazo.Size = new System.Drawing.Size(161, 20);
            this.TCadenaRemplazo.TabIndex = 10;
            this.TCadenaRemplazo.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // ChRemplazo
            // 
            this.ChRemplazo.AutoSize = true;
            this.ChRemplazo.Location = new System.Drawing.Point(12, 126);
            this.ChRemplazo.Name = "ChRemplazo";
            this.ChRemplazo.Size = new System.Drawing.Size(251, 17);
            this.ChRemplazo.TabIndex = 11;
            this.ChRemplazo.Text = "Usar el resto de la linea como texto de remplazo";
            this.ChRemplazo.UseVisualStyleBackColor = true;
            this.ChRemplazo.CheckedChanged += new System.EventHandler(this.ChRemplazo_CheckedChanged);
            // 
            // CHTabulador
            // 
            this.CHTabulador.AutoSize = true;
            this.CHTabulador.Location = new System.Drawing.Point(15, 180);
            this.CHTabulador.Name = "CHTabulador";
            this.CHTabulador.Size = new System.Drawing.Size(122, 17);
            this.CHTabulador.TabIndex = 13;
            this.CHTabulador.Text = "Aplica a tabuladores";
            this.CHTabulador.UseVisualStyleBackColor = true;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(311, 72);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(94, 42);
            this.BCancelar.TabIndex = 15;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Enabled = false;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(311, 18);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(94, 42);
            this.BAceptar.TabIndex = 14;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            // 
            // TLongitudMinima
            // 
            this.TLongitudMinima.Location = new System.Drawing.Point(101, 154);
            this.TLongitudMinima.Name = "TLongitudMinima";
            this.TLongitudMinima.Size = new System.Drawing.Size(120, 20);
            this.TLongitudMinima.TabIndex = 16;
            this.TLongitudMinima.ValueChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // FormDetalleBloque
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(417, 209);
            this.ControlBox = false;
            this.Controls.Add(this.TLongitudMinima);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.CHTabulador);
            this.Controls.Add(this.ChRemplazo);
            this.Controls.Add(this.TCadenaRemplazo);
            this.Controls.Add(this.TTextoFinal);
            this.Controls.Add(this.TTextoInicial);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDetalleBloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle";
            ((System.ComponentModel.ISupportInitialize)(this.TLongitudMinima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TTextoInicial;
        private System.Windows.Forms.TextBox TTextoFinal;
        private System.Windows.Forms.TextBox TCadenaRemplazo;
        private System.Windows.Forms.CheckBox ChRemplazo;
        private System.Windows.Forms.CheckBox CHTabulador;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.NumericUpDown TLongitudMinima;
    }
}