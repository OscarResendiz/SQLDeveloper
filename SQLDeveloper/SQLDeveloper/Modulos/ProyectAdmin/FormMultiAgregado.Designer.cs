namespace SQLDeveloper.Modulos.ProyectAdmin
{
    partial class FormMultiAgregado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiAgregado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Texto = new System.Windows.Forms.TextBox();
            this.BKProseso = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.BAgregar);
            this.panel1.Controls.Add(this.BCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 86);
            this.panel1.TabIndex = 0;
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(12, 13);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(89, 43);
            this.BCerrar.TabIndex = 0;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(220, 13);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(89, 43);
            this.BAgregar.TabIndex = 1;
            this.BAgregar.Text = "Agregar";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 63);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(321, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // Texto
            // 
            this.Texto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Texto.Location = new System.Drawing.Point(0, 0);
            this.Texto.Multiline = true;
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(321, 372);
            this.Texto.TabIndex = 1;
            // 
            // BKProseso
            // 
            this.BKProseso.WorkerReportsProgress = true;
            this.BKProseso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKProseso_DoWork);
            this.BKProseso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKProseso_ProgressChanged);
            this.BKProseso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKProseso_RunWorkerCompleted);
            // 
            // FormMultiAgregado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 458);
            this.ControlBox = false;
            this.Controls.Add(this.Texto);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMultiAgregado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar multiples objetos";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.TextBox Texto;
        private System.ComponentModel.BackgroundWorker BKProseso;
    }
}