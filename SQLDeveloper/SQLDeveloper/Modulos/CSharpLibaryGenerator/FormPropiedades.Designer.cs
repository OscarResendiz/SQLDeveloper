namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    partial class FormPropiedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropiedades));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TDirectorio = new System.Windows.Forms.TextBox();
            this.BCarpeta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboSalida = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BCancelar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(334, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(99, 51);
            this.panel3.TabIndex = 1;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(0, 3);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(85, 36);
            this.BCancelar.TabIndex = 0;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 51);
            this.panel2.TabIndex = 0;
            // 
            // BAceptar
            // 
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(12, 3);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(85, 36);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de la libreria";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(119, 12);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(247, 20);
            this.TNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ruta de destino";
            // 
            // TDirectorio
            // 
            this.TDirectorio.Location = new System.Drawing.Point(100, 51);
            this.TDirectorio.Name = "TDirectorio";
            this.TDirectorio.Size = new System.Drawing.Size(266, 20);
            this.TDirectorio.TabIndex = 4;
            // 
            // BCarpeta
            // 
            this.BCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("BCarpeta.Image")));
            this.BCarpeta.Location = new System.Drawing.Point(372, 40);
            this.BCarpeta.Name = "BCarpeta";
            this.BCarpeta.Size = new System.Drawing.Size(43, 41);
            this.BCarpeta.TabIndex = 5;
            this.BCarpeta.UseVisualStyleBackColor = true;
            this.BCarpeta.Click += new System.EventHandler(this.BCarpeta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de Salida";
            // 
            // ComboSalida
            // 
            this.ComboSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSalida.FormattingEnabled = true;
            this.ComboSalida.Items.AddRange(new object[] {
            "Clases LinQ",
            "Clases Genericas"});
            this.ComboSalida.Location = new System.Drawing.Point(94, 96);
            this.ComboSalida.Name = "ComboSalida";
            this.ComboSalida.Size = new System.Drawing.Size(272, 21);
            this.ComboSalida.TabIndex = 7;
            // 
            // FormPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(433, 214);
            this.Controls.Add(this.ComboSalida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BCarpeta);
            this.Controls.Add(this.TDirectorio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPropiedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades";
            this.Load += new System.EventHandler(this.FormPropiedades_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TDirectorio;
        private System.Windows.Forms.Button BCarpeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboSalida;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}