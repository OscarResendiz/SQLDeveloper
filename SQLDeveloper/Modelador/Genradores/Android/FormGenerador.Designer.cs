namespace Modelador.Genradores.Android
{
    partial class FormGenerador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerador));
            this.label1 = new System.Windows.Forms.Label();
            this.TDirectorio = new System.Windows.Forms.TextBox();
            this.BBucar = new System.Windows.Forms.Button();
            this.TPackage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BGenerar = new System.Windows.Forms.Button();
            this.BCerrar = new System.Windows.Forms.Button();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directorio destino";
            // 
            // TDirectorio
            // 
            this.TDirectorio.Location = new System.Drawing.Point(111, 127);
            this.TDirectorio.Name = "TDirectorio";
            this.TDirectorio.Size = new System.Drawing.Size(261, 20);
            this.TDirectorio.TabIndex = 1;
            // 
            // BBucar
            // 
            this.BBucar.Image = ((System.Drawing.Image)(resources.GetObject("BBucar.Image")));
            this.BBucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBucar.Location = new System.Drawing.Point(378, 121);
            this.BBucar.Name = "BBucar";
            this.BBucar.Size = new System.Drawing.Size(35, 31);
            this.BBucar.TabIndex = 2;
            this.BBucar.UseVisualStyleBackColor = true;
            this.BBucar.Click += new System.EventHandler(this.BBucar_Click);
            // 
            // TPackage
            // 
            this.TPackage.Location = new System.Drawing.Point(73, 168);
            this.TPackage.Name = "TPackage";
            this.TPackage.Size = new System.Drawing.Size(350, 20);
            this.TPackage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "package";
            // 
            // TDatabase
            // 
            this.TDatabase.Location = new System.Drawing.Point(162, 211);
            this.TDatabase.Name = "TDatabase";
            this.TDatabase.Size = new System.Drawing.Size(261, 20);
            this.TDatabase.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre de la base de datos";
            // 
            // BGenerar
            // 
            this.BGenerar.Image = ((System.Drawing.Image)(resources.GetObject("BGenerar.Image")));
            this.BGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BGenerar.Location = new System.Drawing.Point(339, 274);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(84, 42);
            this.BGenerar.TabIndex = 7;
            this.BGenerar.Text = "Genrar";
            this.BGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BGenerar.UseVisualStyleBackColor = true;
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click);
            // 
            // BCerrar
            // 
            this.BCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(19, 274);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(84, 42);
            this.BCerrar.TabIndex = 8;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(19, 245);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(404, 23);
            this.Progreso.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(438, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormGenerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCerrar;
            this.ClientSize = new System.Drawing.Size(438, 338);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Progreso);
            this.Controls.Add(this.BCerrar);
            this.Controls.Add(this.BGenerar);
            this.Controls.Add(this.TDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TPackage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BBucar);
            this.Controls.Add(this.TDirectorio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGenerador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genrador de Codigo Kotlin Android";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TDirectorio;
        private System.Windows.Forms.Button BBucar;
        private System.Windows.Forms.TextBox TPackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BGenerar;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}