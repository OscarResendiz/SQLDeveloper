namespace SPGenerator
{
    partial class AsisSelParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsisSelParametros));
            this.label2 = new System.Windows.Forms.Label();
            this.ListaCampos = new System.Windows.Forms.ListBox();
            this.CHExcepcion = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TExcepcion = new System.Windows.Forms.TextBox();
            this.ListaParametros = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TComentarios = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BAgregar = new System.Windows.Forms.Button();
            this.BQuitar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.DlstPropiedades = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Campos de la tabla";
            // 
            // ListaCampos
            // 
            this.ListaCampos.BackColor = System.Drawing.Color.White;
            this.ListaCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCampos.ForeColor = System.Drawing.Color.Black;
            this.ListaCampos.FormattingEnabled = true;
            this.ListaCampos.Location = new System.Drawing.Point(0, 13);
            this.ListaCampos.Name = "ListaCampos";
            this.ListaCampos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCampos.Size = new System.Drawing.Size(379, 230);
            this.ListaCampos.TabIndex = 2;
            this.ListaCampos.SelectedIndexChanged += new System.EventHandler(this.ListaCampos_SelectedIndexChanged);
            // 
            // CHExcepcion
            // 
            this.CHExcepcion.AutoSize = true;
            this.CHExcepcion.Location = new System.Drawing.Point(3, 6);
            this.CHExcepcion.Name = "CHExcepcion";
            this.CHExcepcion.Size = new System.Drawing.Size(254, 17);
            this.CHExcepcion.TabIndex = 3;
            this.CHExcepcion.Text = "Generar excepcion si no se encuentran registros";
            this.CHExcepcion.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Texto de la excepcion";
            // 
            // TExcepcion
            // 
            this.TExcepcion.Location = new System.Drawing.Point(121, 29);
            this.TExcepcion.Name = "TExcepcion";
            this.TExcepcion.Size = new System.Drawing.Size(200, 20);
            this.TExcepcion.TabIndex = 5;
            // 
            // ListaParametros
            // 
            this.ListaParametros.BackColor = System.Drawing.Color.White;
            this.ListaParametros.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaParametros.ForeColor = System.Drawing.Color.Black;
            this.ListaParametros.FormattingEnabled = true;
            this.ListaParametros.Location = new System.Drawing.Point(0, 13);
            this.ListaParametros.Name = "ListaParametros";
            this.ListaParametros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaParametros.Size = new System.Drawing.Size(323, 324);
            this.ListaParametros.TabIndex = 7;
            this.ListaParametros.DoubleClick += new System.EventHandler(this.ListaParametros_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 48);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.aToolStripMenuItem.Text = "Agregar nuevo parámetro";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parametros";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TComentarios
            // 
            this.TComentarios.Location = new System.Drawing.Point(74, 54);
            this.TComentarios.Name = "TComentarios";
            this.TComentarios.Size = new System.Drawing.Size(247, 20);
            this.TComentarios.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Comentarios";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 35);
            this.panel1.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Navy;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(781, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Seleccion de parametros";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(781, 337);
            this.panel2.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(379, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(402, 337);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.ListaParametros);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.ForeColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(79, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(323, 337);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.BAgregar);
            this.panel5.Controls.Add(this.BQuitar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(79, 337);
            this.panel5.TabIndex = 0;
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.Black;
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.Location = new System.Drawing.Point(1, 84);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(75, 36);
            this.BAgregar.TabIndex = 8;
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // BQuitar
            // 
            this.BQuitar.BackColor = System.Drawing.Color.Black;
            this.BQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar.Image")));
            this.BQuitar.Location = new System.Drawing.Point(1, 194);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(75, 36);
            this.BQuitar.TabIndex = 9;
            this.BQuitar.UseVisualStyleBackColor = false;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.ListaCampos);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 337);
            this.panel3.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 240);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(379, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.DlstPropiedades);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 243);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(379, 94);
            this.panel8.TabIndex = 3;
            // 
            // DlstPropiedades
            // 
            this.DlstPropiedades.BackColor = System.Drawing.Color.White;
            this.DlstPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DlstPropiedades.ForeColor = System.Drawing.Color.Black;
            this.DlstPropiedades.FormattingEnabled = true;
            this.DlstPropiedades.Location = new System.Drawing.Point(0, 0);
            this.DlstPropiedades.Name = "DlstPropiedades";
            this.DlstPropiedades.Size = new System.Drawing.Size(379, 94);
            this.DlstPropiedades.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.CHExcepcion);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.TExcepcion);
            this.panel7.Controls.Add(this.TComentarios);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(0, 372);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(781, 81);
            this.panel7.TabIndex = 14;
            // 
            // AsisSelParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Name = "AsisSelParametros";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ListaCampos;
        private System.Windows.Forms.CheckBox CHExcepcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TExcepcion;
        private System.Windows.Forms.ListBox ListaParametros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TComentarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ListBox DlstPropiedades;
        private System.Windows.Forms.Splitter splitter1;
    }
}
