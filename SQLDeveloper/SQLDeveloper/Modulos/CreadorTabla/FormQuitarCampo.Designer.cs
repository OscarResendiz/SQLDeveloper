namespace SQLDeveloper.Modulos.CreadorTabla
{
    partial class FormQuitarCampo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuitarCampo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.ComboCampos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BUniques = new System.Windows.Forms.ToolStripButton();
            this.BDeafult = new System.Windows.Forms.Button();
            this.Bchecks = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 61);
            this.panel2.TabIndex = 3;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(256, 6);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 43);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(12, 7);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 43);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BDeafult);
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.ComboCampos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 76);
            this.panel1.TabIndex = 2;
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(53, 6);
            this.TTabla.Name = "TTabla";
            this.TTabla.ReadOnly = true;
            this.TTabla.Size = new System.Drawing.Size(258, 20);
            this.TTabla.TabIndex = 1;
            // 
            // ComboCampos
            // 
            this.ComboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCampos.FormattingEnabled = true;
            this.ComboCampos.Location = new System.Drawing.Point(53, 47);
            this.ComboCampos.Name = "ComboCampos";
            this.ComboCampos.Size = new System.Drawing.Size(209, 21);
            this.ComboCampos.TabIndex = 5;
            this.ComboCampos.SelectedIndexChanged += new System.EventHandler(this.ComboCampos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Campo";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 101);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(360, 249);
            this.propertyGrid1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BUniques,
            this.Bchecks});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(360, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BUniques
            // 
            this.BUniques.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BUniques.Image = ((System.Drawing.Image)(resources.GetObject("BUniques.Image")));
            this.BUniques.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BUniques.Name = "BUniques";
            this.BUniques.Size = new System.Drawing.Size(23, 22);
            this.BUniques.Text = "Uniques";
            this.BUniques.Click += new System.EventHandler(this.BUniques_Click);
            // 
            // BDeafult
            // 
            this.BDeafult.Enabled = false;
            this.BDeafult.Location = new System.Drawing.Point(268, 47);
            this.BDeafult.Name = "BDeafult";
            this.BDeafult.Size = new System.Drawing.Size(83, 23);
            this.BDeafult.TabIndex = 6;
            this.BDeafult.Text = "Quitar Deafult";
            this.BDeafult.UseVisualStyleBackColor = true;
            this.BDeafult.Click += new System.EventHandler(this.BDeafult_Click);
            // 
            // Bchecks
            // 
            this.Bchecks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bchecks.Image = ((System.Drawing.Image)(resources.GetObject("Bchecks.Image")));
            this.Bchecks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bchecks.Name = "Bchecks";
            this.Bchecks.Size = new System.Drawing.Size(23, 22);
            this.Bchecks.Text = "Administrar Reglas (checks)";
            this.Bchecks.Click += new System.EventHandler(this.Bchecks_Click);
            // 
            // FormQuitarCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(360, 411);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuitarCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar campo";
            this.Load += new System.EventHandler(this.FormQuitarCampo_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboCampos;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BUniques;
        private System.Windows.Forms.Button BDeafult;
        private System.Windows.Forms.ToolStripButton Bchecks;
    }
}