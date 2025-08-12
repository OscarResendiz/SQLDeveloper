namespace SPGenerator
{
    partial class FormNuevoCampo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoCampo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RdbTabla = new System.Windows.Forms.RadioButton();
            this.RdbManual = new System.Windows.Forms.RadioButton();
            this.PnlManual = new System.Windows.Forms.Panel();
            this.Tlongitud = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombreCampo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.PnlTabla = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DlstCampos = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ListaObjetos = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.PnlManual.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PnlTabla.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.RdbTabla);
            this.panel1.Controls.Add(this.RdbManual);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 40);
            this.panel1.TabIndex = 0;
            // 
            // RdbTabla
            // 
            this.RdbTabla.AutoSize = true;
            this.RdbTabla.Location = new System.Drawing.Point(111, 12);
            this.RdbTabla.Name = "RdbTabla";
            this.RdbTabla.Size = new System.Drawing.Size(103, 17);
            this.RdbTabla.TabIndex = 1;
            this.RdbTabla.Text = "Desde una tabla";
            this.RdbTabla.UseVisualStyleBackColor = true;
            this.RdbTabla.CheckedChanged += new System.EventHandler(this.RdbManual_CheckedChanged);
            // 
            // RdbManual
            // 
            this.RdbManual.AutoSize = true;
            this.RdbManual.Checked = true;
            this.RdbManual.Location = new System.Drawing.Point(12, 12);
            this.RdbManual.Name = "RdbManual";
            this.RdbManual.Size = new System.Drawing.Size(60, 17);
            this.RdbManual.TabIndex = 0;
            this.RdbManual.TabStop = true;
            this.RdbManual.Text = "Manual";
            this.RdbManual.UseVisualStyleBackColor = true;
            this.RdbManual.CheckedChanged += new System.EventHandler(this.RdbManual_CheckedChanged);
            // 
            // PnlManual
            // 
            this.PnlManual.BackColor = System.Drawing.Color.Transparent;
            this.PnlManual.Controls.Add(this.Tlongitud);
            this.PnlManual.Controls.Add(this.label3);
            this.PnlManual.Controls.Add(this.ComboTipos);
            this.PnlManual.Controls.Add(this.label2);
            this.PnlManual.Controls.Add(this.TxtNombreCampo);
            this.PnlManual.Controls.Add(this.label1);
            this.PnlManual.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlManual.ForeColor = System.Drawing.Color.Black;
            this.PnlManual.Location = new System.Drawing.Point(0, 40);
            this.PnlManual.Name = "PnlManual";
            this.PnlManual.Size = new System.Drawing.Size(503, 72);
            this.PnlManual.TabIndex = 1;
            // 
            // Tlongitud
            // 
            this.Tlongitud.Enabled = false;
            this.Tlongitud.Location = new System.Drawing.Point(397, 31);
            this.Tlongitud.Name = "Tlongitud";
            this.Tlongitud.Size = new System.Drawing.Size(86, 20);
            this.Tlongitud.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Longitud";
            // 
            // ComboTipos
            // 
            this.ComboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipos.FormattingEnabled = true;
            this.ComboTipos.Location = new System.Drawing.Point(200, 30);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(191, 21);
            this.ComboTipos.TabIndex = 4;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // TxtNombreCampo
            // 
            this.TxtNombreCampo.Location = new System.Drawing.Point(3, 30);
            this.TxtNombreCampo.Name = "TxtNombreCampo";
            this.TxtNombreCampo.Size = new System.Drawing.Size(191, 20);
            this.TxtNombreCampo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 67);
            this.panel2.TabIndex = 2;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(391, 17);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 38);
            this.BCancelar.TabIndex = 17;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Enabled = false;
            this.BAceptar.ForeColor = System.Drawing.Color.White;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(12, 17);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(92, 38);
            this.BAceptar.TabIndex = 16;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // PnlTabla
            // 
            this.PnlTabla.BackColor = System.Drawing.Color.Transparent;
            this.PnlTabla.Controls.Add(this.panel5);
            this.PnlTabla.Controls.Add(this.panel3);
            this.PnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabla.Enabled = false;
            this.PnlTabla.ForeColor = System.Drawing.Color.Black;
            this.PnlTabla.Location = new System.Drawing.Point(0, 112);
            this.PnlTabla.Name = "PnlTabla";
            this.PnlTabla.Size = new System.Drawing.Size(503, 311);
            this.PnlTabla.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DlstCampos);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(261, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 311);
            this.panel5.TabIndex = 1;
            // 
            // DlstCampos
            // 
            this.DlstCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.DlstCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DlstCampos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DlstCampos.FormattingEnabled = true;
            this.DlstCampos.Location = new System.Drawing.Point(0, 13);
            this.DlstCampos.Name = "DlstCampos";
            this.DlstCampos.Size = new System.Drawing.Size(242, 298);
            this.DlstCampos.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Campo";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.ListaObjetos);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 311);
            this.panel3.TabIndex = 0;
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaObjetos.FormattingEnabled = true;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 49);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.Size = new System.Drawing.Size(261, 262);
            this.ListaObjetos.TabIndex = 4;
            this.ListaObjetos.SelectedIndexChanged += new System.EventHandler(this.ListaObjetos_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(261, 49);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre Tabla";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormNuevoCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(503, 490);
            this.ControlBox = false;
            this.Controls.Add(this.PnlTabla);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlManual);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Name = "FormNuevoCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar nuevo campo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNuevoCampo_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlManual.ResumeLayout(false);
            this.PnlManual.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PnlTabla.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RdbTabla;
        private System.Windows.Forms.RadioButton RdbManual;
        private System.Windows.Forms.Panel PnlManual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombreCampo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboTipos;
        private System.Windows.Forms.TextBox Tlongitud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel PnlTabla;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private AnimatedWaitTextBox animatedWaitTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox DlstCampos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ListaObjetos;
        private System.Windows.Forms.Timer timer1;
    }
}