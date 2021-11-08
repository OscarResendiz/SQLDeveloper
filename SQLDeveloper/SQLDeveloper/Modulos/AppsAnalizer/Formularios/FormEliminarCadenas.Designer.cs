namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    partial class FormEliminarCadenas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEliminarCadenas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BElimnar = new System.Windows.Forms.Button();
            this.BEliminarArchivos = new System.Windows.Forms.Button();
            this.Lista = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TFiltro = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BFiltro = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 63);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BSalir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(420, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(96, 63);
            this.panel3.TabIndex = 4;
            // 
            // BSalir
            // 
            this.BSalir.Image = global::SQLDeveloper.Recursos.exit32;
            this.BSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BSalir.Location = new System.Drawing.Point(3, 6);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(84, 45);
            this.BSalir.TabIndex = 0;
            this.BSalir.Text = "Cerrar";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BElimnar);
            this.panel2.Controls.Add(this.BEliminarArchivos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 63);
            this.panel2.TabIndex = 3;
            // 
            // BElimnar
            // 
            this.BElimnar.Image = ((System.Drawing.Image)(resources.GetObject("BElimnar.Image")));
            this.BElimnar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BElimnar.Location = new System.Drawing.Point(12, 6);
            this.BElimnar.Name = "BElimnar";
            this.BElimnar.Size = new System.Drawing.Size(87, 45);
            this.BElimnar.TabIndex = 2;
            this.BElimnar.Text = "Eliminar";
            this.BElimnar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BElimnar.UseVisualStyleBackColor = true;
            this.BElimnar.Click += new System.EventHandler(this.button3_Click);
            // 
            // BEliminarArchivos
            // 
            this.BEliminarArchivos.Image = global::SQLDeveloper.Recursos.IconoEliminar;
            this.BEliminarArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminarArchivos.Location = new System.Drawing.Point(122, 6);
            this.BEliminarArchivos.Name = "BEliminarArchivos";
            this.BEliminarArchivos.Size = new System.Drawing.Size(171, 45);
            this.BEliminarArchivos.TabIndex = 1;
            this.BEliminarArchivos.Text = "Eliminar de varios archivos";
            this.BEliminarArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminarArchivos.UseVisualStyleBackColor = true;
            this.BEliminarArchivos.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lista
            // 
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(0, 48);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(516, 567);
            this.Lista.TabIndex = 1;
            this.Lista.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Lista_ItemCheck);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 615);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(516, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(516, 48);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.TFiltro);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(42, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel7.Size = new System.Drawing.Size(396, 48);
            this.panel7.TabIndex = 2;
            // 
            // TFiltro
            // 
            this.TFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TFiltro.Location = new System.Drawing.Point(0, 10);
            this.TFiltro.Name = "TFiltro";
            this.TFiltro.Size = new System.Drawing.Size(396, 20);
            this.TFiltro.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BFiltro);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(438, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(78, 48);
            this.panel6.TabIndex = 1;
            // 
            // BFiltro
            // 
            this.BFiltro.Image = ((System.Drawing.Image)(resources.GetObject("BFiltro.Image")));
            this.BFiltro.Location = new System.Drawing.Point(17, 5);
            this.BFiltro.Name = "BFiltro";
            this.BFiltro.Size = new System.Drawing.Size(49, 37);
            this.BFiltro.TabIndex = 0;
            this.BFiltro.UseVisualStyleBackColor = true;
            this.BFiltro.Click += new System.EventHandler(this.BFiltro_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(42, 48);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtro";
            // 
            // FormEliminarCadenas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 701);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Name = "FormEliminarCadenas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Cadenas";
            this.Load += new System.EventHandler(this.FormEliminarCadenas_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BElimnar;
        private System.Windows.Forms.Button BEliminarArchivos;
        private System.Windows.Forms.CheckedListBox Lista;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox TFiltro;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BFiltro;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
    }
}   