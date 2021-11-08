namespace ManagerConnect
{
    partial class FormNuevaConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevaConexion));
            this.label1 = new System.Windows.Forms.Label();
            this.ComboGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboMotor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo";
            // 
            // ComboGrupo
            // 
            this.ComboGrupo.FormattingEnabled = true;
            this.ComboGrupo.Location = new System.Drawing.Point(54, 16);
            this.ComboGrupo.Name = "ComboGrupo";
            this.ComboGrupo.Size = new System.Drawing.Size(194, 21);
            this.ComboGrupo.TabIndex = 1;
            this.ComboGrupo.Tag = "Seleccione o ingrese el nombre del grupo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motor ";
            // 
            // ComboMotor
            // 
            this.ComboMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMotor.FormattingEnabled = true;
            this.ComboMotor.Location = new System.Drawing.Point(55, 55);
            this.ComboMotor.Name = "ComboMotor";
            this.ComboMotor.Size = new System.Drawing.Size(150, 21);
            this.ComboMotor.TabIndex = 3;
            this.ComboMotor.Tag = "Seleccione el motor de base de datos";
            this.ComboMotor.SelectedIndexChanged += new System.EventHandler(this.ComboMotor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(55, 88);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(193, 20);
            this.TNombre.TabIndex = 9;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(263, 19);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(86, 35);
            this.BAceptar.TabIndex = 4;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(263, 70);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(86, 35);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BConfig
            // 
            this.BConfig.Enabled = false;
            this.BConfig.Image = ((System.Drawing.Image)(resources.GetObject("BConfig.Image")));
            this.BConfig.Location = new System.Drawing.Point(211, 48);
            this.BConfig.Name = "BConfig";
            this.BConfig.Size = new System.Drawing.Size(37, 33);
            this.BConfig.TabIndex = 10;
            this.BConfig.Tag = "Configurar Conexión";
            this.BConfig.UseVisualStyleBackColor = true;
            this.BConfig.Click += new System.EventHandler(this.BConfig_Click);
            // 
            // FormNuevaConexion
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(357, 120);
            this.ControlBox = false;
            this.Controls.Add(this.BConfig);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.ComboMotor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboGrupo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNuevaConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva conexion";
            this.Load += new System.EventHandler(this.FormNuevaConexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboMotor;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Button BConfig;
    }
}