namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    partial class FormBuscadorObjetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscadorObjetos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LResultado = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BAgregar = new System.Windows.Forms.Button();
            this.ListaObjetos = new System.Windows.Forms.CheckedListBox();
            this.TimerLLena = new System.Windows.Forms.Timer(this.components);
            this.panel10 = new System.Windows.Forms.Panel();
            this.TFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBuscadorAvanzado1 = new SQLDeveloper.Modulos.Buscador.CBuscadorAvanzado();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 69);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ComboTipo);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 34);
            this.panel3.TabIndex = 6;
            // 
            // ComboTipo
            // 
            this.ComboTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(50, 0);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(256, 21);
            this.ComboTipo.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(50, 34);
            this.panel9.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TNombre);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel5.Size = new System.Drawing.Size(306, 39);
            this.panel5.TabIndex = 5;
            // 
            // TNombre
            // 
            this.TNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TNombre.Location = new System.Drawing.Point(50, 5);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(256, 20);
            this.TNombre.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(50, 34);
            this.panel8.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(306, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 69);
            this.panel4.TabIndex = 4;
            // 
            // BBuscar
            // 
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBuscar.Location = new System.Drawing.Point(3, 15);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(86, 40);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LResultado);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 47);
            this.panel2.TabIndex = 1;
            // 
            // LResultado
            // 
            this.LResultado.AutoSize = true;
            this.LResultado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LResultado.Location = new System.Drawing.Point(95, 34);
            this.LResultado.Name = "LResultado";
            this.LResultado.Size = new System.Drawing.Size(0, 13);
            this.LResultado.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BCerrar);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(306, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(94, 47);
            this.panel7.TabIndex = 3;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(1, 0);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(88, 44);
            this.BCerrar.TabIndex = 1;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BAgregar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(95, 47);
            this.panel6.TabIndex = 2;
            // 
            // BAgregar
            // 
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(3, 0);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(88, 44);
            this.BAgregar.TabIndex = 0;
            this.BAgregar.Text = "Agregar";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.FormattingEnabled = true;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 107);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.Size = new System.Drawing.Size(400, 281);
            this.ListaObjetos.TabIndex = 2;
            // 
            // TimerLLena
            // 
            this.TimerLLena.Enabled = true;
            this.TimerLLena.Tick += new System.EventHandler(this.TimerLLena_Tick);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.TFiltro);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 69);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(400, 38);
            this.panel10.TabIndex = 3;
            // 
            // TFiltro
            // 
            this.TFiltro.Location = new System.Drawing.Point(75, 10);
            this.TFiltro.Name = "TFiltro";
            this.TFiltro.Size = new System.Drawing.Size(305, 20);
            this.TFiltro.TabIndex = 1;
            this.TFiltro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filtro interno:";
            // 
            // cBuscadorAvanzado1
            // 
            this.cBuscadorAvanzado1.OnObjetoEncontrado += new SQLDeveloper.Modulos.Buscador.OnObjetoEncontradoEvent(this.cBuscadorAvanzado1_OnObjetoEncontrado);
            this.cBuscadorAvanzado1.OnInicioBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnInicioBusqueda);
            this.cBuscadorAvanzado1.OnFinBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFinBusqueda);
            // 
            // FormBuscadorObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 435);
            this.Controls.Add(this.ListaObjetos);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBuscadorObjetos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Objetos";
            this.Load += new System.EventHandler(this.FormBuscadorObjetos_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.CheckedListBox ListaObjetos;
        private Buscador.CBuscadorAvanzado cBuscadorAvanzado1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Timer TimerLLena;
        private System.Windows.Forms.Label LResultado;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox TFiltro;
        private System.Windows.Forms.Label label3;
    }
}   