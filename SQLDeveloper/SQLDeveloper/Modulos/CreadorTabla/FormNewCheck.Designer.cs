namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormNewCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCheck));
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TRegla = new System.Windows.Forms.TextBox();
            this.Bacpetar = new System.Windows.Forms.Button();
            this.Bcancelar = new System.Windows.Forms.Button();
            this.BEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 9);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(230, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Regla";
            // 
            // TRegla
            // 
            this.TRegla.Location = new System.Drawing.Point(53, 35);
            this.TRegla.Multiline = true;
            this.TRegla.Name = "TRegla";
            this.TRegla.Size = new System.Drawing.Size(239, 67);
            this.TRegla.TabIndex = 3;
            // 
            // Bacpetar
            // 
            this.Bacpetar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Bacpetar.Image = ((System.Drawing.Image)(resources.GetObject("Bacpetar.Image")));
            this.Bacpetar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bacpetar.Location = new System.Drawing.Point(12, 108);
            this.Bacpetar.Name = "Bacpetar";
            this.Bacpetar.Size = new System.Drawing.Size(89, 37);
            this.Bacpetar.TabIndex = 4;
            this.Bacpetar.Text = "Aceptar";
            this.Bacpetar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bacpetar.UseVisualStyleBackColor = true;
            this.Bacpetar.Click += new System.EventHandler(this.Bacpetar_Click);
            // 
            // Bcancelar
            // 
            this.Bcancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Bcancelar.Image = ((System.Drawing.Image)(resources.GetObject("Bcancelar.Image")));
            this.Bcancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bcancelar.Location = new System.Drawing.Point(217, 108);
            this.Bcancelar.Name = "Bcancelar";
            this.Bcancelar.Size = new System.Drawing.Size(89, 37);
            this.Bcancelar.TabIndex = 5;
            this.Bcancelar.Text = "Cancelar";
            this.Bcancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bcancelar.UseVisualStyleBackColor = true;
            // 
            // BEditor
            // 
            this.BEditor.Image = ((System.Drawing.Image)(resources.GetObject("BEditor.Image")));
            this.BEditor.Location = new System.Drawing.Point(298, 35);
            this.BEditor.Name = "BEditor";
            this.BEditor.Size = new System.Drawing.Size(43, 37);
            this.BEditor.TabIndex = 6;
            this.BEditor.Tag = "Editor de reglas";
            this.BEditor.UseVisualStyleBackColor = true;
            this.BEditor.Click += new System.EventHandler(this.BEditor_Click);
            // 
            // FormNewCheck
            // 
            this.AcceptButton = this.Bacpetar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Bcancelar;
            this.ClientSize = new System.Drawing.Size(353, 154);
            this.Controls.Add(this.BEditor);
            this.Controls.Add(this.Bcancelar);
            this.Controls.Add(this.Bacpetar);
            this.Controls.Add(this.TRegla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Check";
            this.Load += new System.EventHandler(this.FormNewCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TRegla;
        private System.Windows.Forms.Button Bacpetar;
        private System.Windows.Forms.Button Bcancelar;
        private System.Windows.Forms.Button BEditor;
    }
}