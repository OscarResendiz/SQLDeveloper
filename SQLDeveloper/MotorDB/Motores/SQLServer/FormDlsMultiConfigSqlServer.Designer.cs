namespace MotorDB.Motores.SQLServer
{
    partial class FormDlsMultiConfigSqlServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDlsMultiConfigSqlServer));
            this.TimerValidador = new System.Windows.Forms.Timer(this.components);
            this.BKBuscarBases = new System.ComponentModel.BackgroundWorker();
            this.BKBUscarServidores = new System.ComponentModel.BackgroundWorker();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BVerBases = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BProbar = new System.Windows.Forms.Button();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.ListaBases = new System.Windows.Forms.CheckedListBox();
            this.BkTestConeccion = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxtMensaje = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerValidador
            // 
            this.TimerValidador.Enabled = true;
            // 
            // BKBuscarBases
            // 
            this.BKBuscarBases.WorkerReportsProgress = true;
            this.BKBuscarBases.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKBuscarBases_DoWork);
            this.BKBuscarBases.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKBuscarBases_ProgressChanged);
            this.BKBuscarBases.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKBuscarBases_RunWorkerCompleted);
            // 
            // BKBUscarServidores
            // 
            this.BKBUscarServidores.WorkerReportsProgress = true;
            this.BKBUscarServidores.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKBUscarServidores_DoWork);
            this.BKBUscarServidores.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BKBUscarServidores_ProgressChanged);
            this.BKBUscarServidores.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKBUscarServidores_RunWorkerCompleted);
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(3, 4);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(85, 37);
            this.BAceptar.TabIndex = 42;
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
            this.BCancelar.Location = new System.Drawing.Point(4, 3);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(85, 37);
            this.BCancelar.TabIndex = 43;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // TPassword
            // 
            this.TPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TPassword.Location = new System.Drawing.Point(5, 5);
            this.TPassword.Name = "TPassword";
            this.TPassword.PasswordChar = '*';
            this.TPassword.Size = new System.Drawing.Size(292, 20);
            this.TPassword.TabIndex = 38;
            // 
            // TUsuario
            // 
            this.TUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TUsuario.Location = new System.Drawing.Point(5, 5);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(292, 20);
            this.TUsuario.TabIndex = 37;
            // 
            // ComboAutentication
            // 
            this.ComboAutentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboAutentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAutentication.FormattingEnabled = true;
            this.ComboAutentication.Items.AddRange(new object[] {
            "Autenticación de Windows",
            "Autenticación de SQL Server"});
            this.ComboAutentication.Location = new System.Drawing.Point(5, 5);
            this.ComboAutentication.Name = "ComboAutentication";
            this.ComboAutentication.Size = new System.Drawing.Size(292, 21);
            this.ComboAutentication.TabIndex = 36;
            this.ComboAutentication.SelectedIndexChanged += new System.EventHandler(this.ComboAutentication_SelectedIndexChanged);
            // 
            // ComboServidores
            // 
            this.ComboServidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboServidores.FormattingEnabled = true;
            this.ComboServidores.Location = new System.Drawing.Point(5, 5);
            this.ComboServidores.Name = "ComboServidores";
            this.ComboServidores.Size = new System.Drawing.Size(292, 21);
            this.ComboServidores.TabIndex = 35;
            this.ComboServidores.DropDown += new System.EventHandler(this.ComboServidores_DropDown);
            // 
            // CHContraseña
            // 
            this.CHContraseña.AutoSize = true;
            this.CHContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CHContraseña.Location = new System.Drawing.Point(4, 0);
            this.CHContraseña.Name = "CHContraseña";
            this.CHContraseña.Size = new System.Drawing.Size(197, 24);
            this.CHContraseña.TabIndex = 34;
            this.CHContraseña.Text = "Recordar contraseña";
            this.CHContraseña.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Nombre del usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(509, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Base de datos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Autenticacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nombre del servidor";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 82);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(509, 32);
            this.panel4.TabIndex = 45;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ComboServidores);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(207, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(302, 32);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(207, 32);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 114);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(509, 32);
            this.panel7.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ComboAutentication);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(207, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(302, 32);
            this.panel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(207, 32);
            this.panel9.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 146);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(509, 32);
            this.panel10.TabIndex = 47;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.TUsuario);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(207, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(5);
            this.panel11.Size = new System.Drawing.Size(302, 32);
            this.panel11.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label5);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(207, 32);
            this.panel12.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 178);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(509, 32);
            this.panel13.TabIndex = 48;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.TPassword);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(207, 0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(5);
            this.panel14.Size = new System.Drawing.Size(302, 32);
            this.panel14.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label4);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(207, 32);
            this.panel15.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel2);
            this.panel16.Controls.Add(this.panel1);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 210);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(509, 24);
            this.panel16.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BVerBases);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(207, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 24);
            this.panel2.TabIndex = 36;
            // 
            // BVerBases
            // 
            this.BVerBases.Location = new System.Drawing.Point(3, 0);
            this.BVerBases.Name = "BVerBases";
            this.BVerBases.Size = new System.Drawing.Size(133, 23);
            this.BVerBases.TabIndex = 0;
            this.BVerBases.Text = "Ver Bases de Datos";
            this.BVerBases.UseVisualStyleBackColor = true;
            this.BVerBases.Click += new System.EventHandler(this.BVerBases_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CHContraseña);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 24);
            this.panel1.TabIndex = 35;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panel20);
            this.panel17.Controls.Add(this.panel3);
            this.panel17.Controls.Add(this.panel19);
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel17.Location = new System.Drawing.Point(0, 527);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(509, 44);
            this.panel17.TabIndex = 50;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.progressBar1);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(242, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(173, 44);
            this.panel20.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(173, 44);
            this.progressBar1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BProbar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(96, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(146, 44);
            this.panel3.TabIndex = 3;
            // 
            // BProbar
            // 
            this.BProbar.Image = ((System.Drawing.Image)(resources.GetObject("BProbar.Image")));
            this.BProbar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BProbar.Location = new System.Drawing.Point(6, 4);
            this.BProbar.Name = "BProbar";
            this.BProbar.Size = new System.Drawing.Size(135, 37);
            this.BProbar.TabIndex = 2;
            this.BProbar.Text = "Probar conexiones";
            this.BProbar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BProbar.UseVisualStyleBackColor = true;
            this.BProbar.Click += new System.EventHandler(this.BProbar_Click);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.BAceptar);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel19.Location = new System.Drawing.Point(415, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(94, 44);
            this.panel19.TabIndex = 1;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.BCancelar);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(96, 44);
            this.panel18.TabIndex = 0;
            // 
            // ListaBases
            // 
            this.ListaBases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaBases.FormattingEnabled = true;
            this.ListaBases.Location = new System.Drawing.Point(0, 0);
            this.ListaBases.Name = "ListaBases";
            this.ListaBases.Size = new System.Drawing.Size(509, 136);
            this.ListaBases.TabIndex = 51;
            this.ListaBases.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListaBases_ItemCheck);
            // 
            // BkTestConeccion
            // 
            this.BkTestConeccion.WorkerReportsProgress = true;
            this.BkTestConeccion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkTestConeccion_DoWork);
            this.BkTestConeccion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkTestConeccion_ProgressChanged);
            this.BkTestConeccion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkTestConeccion_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 254);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListaBases);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TxtMensaje);
            this.splitContainer1.Size = new System.Drawing.Size(509, 273);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.TabIndex = 52;
            // 
            // TxtMensaje
            // 
            this.TxtMensaje.BackColor = System.Drawing.Color.Black;
            this.TxtMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMensaje.ForeColor = System.Drawing.Color.White;
            this.TxtMensaje.Location = new System.Drawing.Point(0, 0);
            this.TxtMensaje.Multiline = true;
            this.TxtMensaje.Name = "TxtMensaje";
            this.TxtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtMensaje.Size = new System.Drawing.Size(509, 133);
            this.TxtMensaje.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 82);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // FormDlsMultiConfigSqlServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 571);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormDlsMultiConfigSqlServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlServer";
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TimerValidador;
        private System.ComponentModel.BackgroundWorker BKBuscarBases;
        private System.ComponentModel.BackgroundWorker BKBUscarServidores;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.CheckedListBox ListaBases;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BVerBases;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BProbar;
        private System.ComponentModel.BackgroundWorker BkTestConeccion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TxtMensaje;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}   