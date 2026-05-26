namespace SPGenerator
{
    partial class AsisSelCampos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsisSelCampos));
            this.ListaParametros = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TTop = new System.Windows.Forms.TextBox();
            this.CHDstinct = new System.Windows.Forms.CheckBox();
            this.ListaCampos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CHTop = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BQuitar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaParametros
            // 
            this.ListaParametros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaParametros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaParametros.FormattingEnabled = true;
            this.ListaParametros.Location = new System.Drawing.Point(0, 13);
            this.ListaParametros.Name = "ListaParametros";
            this.ListaParametros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaParametros.Size = new System.Drawing.Size(332, 338);
            this.ListaParametros.TabIndex = 19;
            this.ListaParametros.DoubleClick += new System.EventHandler(this.ListaParametros_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Campos seleccionados";
            // 
            // TTop
            // 
            this.TTop.Location = new System.Drawing.Point(61, 27);
            this.TTop.Name = "TTop";
            this.TTop.ReadOnly = true;
            this.TTop.Size = new System.Drawing.Size(68, 20);
            this.TTop.TabIndex = 17;
            this.TTop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TTop_KeyDown);
            this.TTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TTop_KeyPress);
            // 
            // CHDstinct
            // 
            this.CHDstinct.AutoSize = true;
            this.CHDstinct.Location = new System.Drawing.Point(12, 3);
            this.CHDstinct.Name = "CHDstinct";
            this.CHDstinct.Size = new System.Drawing.Size(95, 17);
            this.CHDstinct.TabIndex = 15;
            this.CHDstinct.Text = "Activar distinct";
            this.CHDstinct.UseVisualStyleBackColor = true;
            // 
            // ListaCampos
            // 
            this.ListaCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCampos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaCampos.FormattingEnabled = true;
            this.ListaCampos.Location = new System.Drawing.Point(0, 13);
            this.ListaCampos.Name = "ListaCampos";
            this.ListaCampos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCampos.Size = new System.Drawing.Size(337, 338);
            this.ListaCampos.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Campos de la tabla";
            // 
            // CHTop
            // 
            this.CHTop.AutoSize = true;
            this.CHTop.Location = new System.Drawing.Point(12, 30);
            this.CHTop.Name = "CHTop";
            this.CHTop.Size = new System.Drawing.Size(45, 17);
            this.CHTop.TabIndex = 24;
            this.CHTop.Text = "Top";
            this.CHTop.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BQuitar
            // 
            this.BQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar.Image")));
            this.BQuitar.Location = new System.Drawing.Point(12, 172);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(75, 36);
            this.BQuitar.TabIndex = 21;
            this.BQuitar.UseVisualStyleBackColor = true;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.Location = new System.Drawing.Point(12, 72);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(75, 36);
            this.BAgregar.TabIndex = 20;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 351);
            this.panel1.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.ListaCampos);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(337, 351);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.BAgregar);
            this.panel3.Controls.Add(this.BQuitar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(337, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 351);
            this.panel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(12, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.ListaParametros);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(449, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 351);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(781, 43);
            this.panel5.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Navy;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(781, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Seleccion de Campos";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.CHDstinct);
            this.panel6.Controls.Add(this.TTop);
            this.panel6.Controls.Add(this.CHTop);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.ForeColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(0, 394);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(781, 59);
            this.panel6.TabIndex = 27;
            // 
            // AsisSelCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Name = "AsisSelCampos";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.ListBox ListaParametros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TTop;
        private System.Windows.Forms.CheckBox CHDstinct;
        private System.Windows.Forms.ListBox ListaCampos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CHTop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
