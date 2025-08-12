namespace GeneradorSP.CrearTablas
{
    partial class FormCrearTabla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearTabla));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TDocumentacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BAgregarCampo = new System.Windows.Forms.ToolStripButton();
            this.BEliminarCampos = new System.Windows.Forms.ToolStripButton();
            this.BEditarCampo = new System.Windows.Forms.ToolStripButton();
            this.BLLavePrimaria = new System.Windows.Forms.ToolStripButton();
            this.BAgregarLaveForanea = new System.Windows.Forms.ToolStripButton();
            this.BEliminarLLaveForanea = new System.Windows.Forms.ToolStripButton();
            this.BGuardar = new System.Windows.Forms.ToolStripButton();
            this.BCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cTabla1 = new Componentes.CTabla();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.TDocumentacion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 98);
            this.panel1.TabIndex = 0;
            // 
            // TDocumentacion
            // 
            this.TDocumentacion.Location = new System.Drawing.Point(6, 54);
            this.TDocumentacion.Multiline = true;
            this.TDocumentacion.Name = "TDocumentacion";
            this.TDocumentacion.Size = new System.Drawing.Size(248, 41);
            this.TDocumentacion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Documentación";
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(6, 16);
            this.TTabla.Name = "TTabla";
            this.TTabla.Size = new System.Drawing.Size(234, 20);
            this.TTabla.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la tabla";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BAgregarCampo,
            this.BEliminarCampos,
            this.BEditarCampo,
            this.BLLavePrimaria,
            this.BAgregarLaveForanea,
            this.BEliminarLLaveForanea,
            this.BGuardar,
            this.BCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(266, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BAgregarCampo
            // 
            this.BAgregarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregarCampo.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarCampo.Image")));
            this.BAgregarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregarCampo.Name = "BAgregarCampo";
            this.BAgregarCampo.Size = new System.Drawing.Size(23, 22);
            this.BAgregarCampo.Text = "agregar campo";
            this.BAgregarCampo.Click += new System.EventHandler(this.BAgregarCampo_Click);
            // 
            // BEliminarCampos
            // 
            this.BEliminarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEliminarCampos.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarCampos.Image")));
            this.BEliminarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEliminarCampos.Name = "BEliminarCampos";
            this.BEliminarCampos.Size = new System.Drawing.Size(23, 22);
            this.BEliminarCampos.Text = "eliminar campos";
            this.BEliminarCampos.Click += new System.EventHandler(this.BEliminarCampos_Click);
            // 
            // BEditarCampo
            // 
            this.BEditarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEditarCampo.Image = ((System.Drawing.Image)(resources.GetObject("BEditarCampo.Image")));
            this.BEditarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEditarCampo.Name = "BEditarCampo";
            this.BEditarCampo.Size = new System.Drawing.Size(23, 22);
            this.BEditarCampo.Text = "Editar campo";
            this.BEditarCampo.Click += new System.EventHandler(this.BEditarCampo_Click);
            // 
            // BLLavePrimaria
            // 
            this.BLLavePrimaria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BLLavePrimaria.Image = ((System.Drawing.Image)(resources.GetObject("BLLavePrimaria.Image")));
            this.BLLavePrimaria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BLLavePrimaria.Name = "BLLavePrimaria";
            this.BLLavePrimaria.Size = new System.Drawing.Size(23, 22);
            this.BLLavePrimaria.Text = "Llave primaria";
            this.BLLavePrimaria.Click += new System.EventHandler(this.BLLavePrimaria_Click);
            // 
            // BAgregarLaveForanea
            // 
            this.BAgregarLaveForanea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BAgregarLaveForanea.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarLaveForanea.Image")));
            this.BAgregarLaveForanea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BAgregarLaveForanea.Name = "BAgregarLaveForanea";
            this.BAgregarLaveForanea.Size = new System.Drawing.Size(23, 22);
            this.BAgregarLaveForanea.Text = "Agregar llave foránea";
            this.BAgregarLaveForanea.Click += new System.EventHandler(this.BAgregarLaveForanea_Click);
            // 
            // BEliminarLLaveForanea
            // 
            this.BEliminarLLaveForanea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BEliminarLLaveForanea.Image = ((System.Drawing.Image)(resources.GetObject("BEliminarLLaveForanea.Image")));
            this.BEliminarLLaveForanea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BEliminarLLaveForanea.Name = "BEliminarLLaveForanea";
            this.BEliminarLLaveForanea.Size = new System.Drawing.Size(23, 22);
            this.BEliminarLLaveForanea.Text = "Eliminar llave foránea";
            this.BEliminarLLaveForanea.Click += new System.EventHandler(this.BEliminarLLaveForanea_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BGuardar.Image")));
            this.BGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(23, 22);
            this.BGuardar.Text = "Crear Tabla";
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCerrar
            // 
            this.BCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(23, 22);
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.cTabla1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 217);
            this.panel2.TabIndex = 3;
            // 
            // cTabla1
            // 
            this.cTabla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTabla1.Location = new System.Drawing.Point(0, 0);
            this.cTabla1.Name = "cTabla1";
            this.cTabla1.Size = new System.Drawing.Size(266, 217);
            this.cTabla1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormCrearTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 340);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCrearTabla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear tabla";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BAgregarCampo;
        private System.Windows.Forms.ToolStripButton BEliminarCampos;
        private System.Windows.Forms.ToolStripButton BEditarCampo;
        private System.Windows.Forms.ToolStripButton BLLavePrimaria;
        private System.Windows.Forms.ToolStripButton BAgregarLaveForanea;
        private System.Windows.Forms.ToolStripButton BEliminarLLaveForanea;
        private System.Windows.Forms.ToolStripButton BGuardar;
        private System.Windows.Forms.ToolStripButton BCerrar;
        private System.Windows.Forms.Panel panel2;
        private Componentes.CTabla cTabla1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TDocumentacion;
        private System.Windows.Forms.Label label2;
    }
}