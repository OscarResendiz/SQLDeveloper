namespace MotorDB
{
    partial class FormDlgConfigSqlServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDlgConfigSqlServer));
            this.ComboBases = new System.Windows.Forms.ComboBox();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.ComboAutentication = new System.Windows.Forms.ComboBox();
            this.ComboServidores = new System.Windows.Forms.ComboBox();
            this.CHContraseña = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BKBUscarServidores = new System.ComponentModel.BackgroundWorker();
            this.BKBuscarBases = new System.ComponentModel.BackgroundWorker();
            this.TimerValidador = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBases
            // 
            this.ComboBases.FormattingEnabled = true;
            this.ComboBases.Location = new System.Drawing.Point(187, 306);
            this.ComboBases.Name = "ComboBases";
            this.ComboBases.Size = new System.Drawing.Size(263, 21);
            this.ComboBases.TabIndex = 23;
            this.ComboBases.DropDown += new System.EventHandler(this.ComboBases_DropDown);
            this.ComboBases.SelectedIndexChanged += new System.EventHandler(this.ComboBases_SelectedIndexChanged);
            // 
            // TPassword
            // 
            this.TPassword.Location = new System.Drawing.Point(187, 248);
            this.TPassword.Name = "TPassword";
            this.TPassword.PasswordChar = '*';
            this.TPassword.Size = new System.Drawing.Size(263, 20);
            this.TPassword.TabIndex = 22;
            // 
            // TUsuario
            // 
            this.TUsuario.Location = new System.Drawing.Point(187, 211);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(263, 20);
            this.TUsuario.TabIndex = 21;
            // 
            // ComboAutentication
            // 
            this.ComboAutentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAutentication.FormattingEnabled = true;
            this.ComboAutentication.Items.AddRange(new object[] {
            "Autenticación de Windows",
            "Autenticación de SQL Server"});
            this.ComboAutentication.Location = new System.Drawing.Point(187, 168);
            this.ComboAutentication.Name = "ComboAutentication";
            this.ComboAutentication.Size = new System.Drawing.Size(263, 21);
            this.ComboAutentication.TabIndex = 20;
            this.ComboAutentication.SelectedIndexChanged += new System.EventHandler(this.ComboAutentication_SelectedIndexChanged);
            // 
            // ComboServidores
            // 
            this.ComboServidores.FormattingEnabled = true;
            this.ComboServidores.Location = new System.Drawing.Point(187, 127);
            this.ComboServidores.Name = "ComboServidores";
            this.ComboServidores.Size = new System.Drawing.Size(263, 21);
            this.ComboServidores.TabIndex = 19;
            this.ComboServidores.DropDown += new System.EventHandler(this.ComboServidores_DropDown);
            // 
            // CHContraseña
            // 
            this.CHContraseña.AutoSize = true;
            this.CHContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CHContraseña.Location = new System.Drawing.Point(187, 274);
            this.CHContraseña.Name = "CHContraseña";
            this.CHContraseña.Size = new System.Drawing.Size(197, 24);
            this.CHContraseña.TabIndex = 18;
            this.CHContraseña.Text = "Recordar contraseña";
            this.CHContraseña.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nombre del usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Base de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Autenticacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre del servidor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 82);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Nombre de la coneccion ";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(221, 94);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(229, 20);
            this.TNombre.TabIndex = 25;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(327, 359);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(85, 37);
            this.BAceptar.TabIndex = 26;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(52, 359);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(85, 37);
            this.BCancelar.TabIndex = 27;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BKBUscarServidores
            // 
            this.BKBUscarServidores.WorkerReportsProgress = true;
            this.BKBUscarServidores.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKBUscarServidores_DoWork);
            this.BKBUscarServidores.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKBUscarServidores_ProgressChanged);
            this.BKBUscarServidores.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKBUscarServidores_RunWorkerCompleted);
            // 
            // BKBuscarBases
            // 
            this.BKBuscarBases.WorkerReportsProgress = true;
            this.BKBuscarBases.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKBuscarBases_DoWork);
            this.BKBuscarBases.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKBuscarBases_ProgressChanged);
            this.BKBuscarBases.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKBuscarBases_RunWorkerCompleted);
            // 
            // TimerValidador
            // 
            this.TimerValidador.Enabled = true;
            this.TimerValidador.Tick += new System.EventHandler(this.TimerValidador_Tick);
            // 
            // FormDlgConfigSqlServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(500, 409);
            this.ControlBox = false;
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboBases);
            this.Controls.Add(this.TPassword);
            this.Controls.Add(this.TUsuario);
            this.Controls.Add(this.ComboAutentication);
            this.Controls.Add(this.ComboServidores);
            this.Controls.Add(this.CHContraseña);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDlgConfigSqlServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server";
            this.Load += new System.EventHandler(this.FormDlgConfigSqlServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBases;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.ComboBox ComboAutentication;
        private System.Windows.Forms.ComboBox ComboServidores;
        private System.Windows.Forms.CheckBox CHContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.ComponentModel.BackgroundWorker BKBUscarServidores;
        private System.ComponentModel.BackgroundWorker BKBuscarBases;
        private System.Windows.Forms.Timer TimerValidador;
    }
}