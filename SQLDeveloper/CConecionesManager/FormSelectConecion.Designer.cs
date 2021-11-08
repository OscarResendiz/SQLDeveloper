namespace ManagerConnect
{
    partial class FormSelectConecion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectConecion));
            this.label1 = new System.Windows.Forms.Label();
            this.ComboGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboConexion = new System.Windows.Forms.ComboBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BNuevo = new System.Windows.Forms.Button();
            this.Configuracion = new ConfiguradorApp(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo";
            // 
            // ComboGrupo
            // 
            this.ComboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupo.FormattingEnabled = true;
            this.ComboGrupo.Location = new System.Drawing.Point(53, 22);
            this.ComboGrupo.Name = "ComboGrupo";
            this.ComboGrupo.Size = new System.Drawing.Size(215, 21);
            this.ComboGrupo.TabIndex = 1;
            this.ComboGrupo.SelectedIndexChanged += new System.EventHandler(this.ComboGrupo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conexión";
            // 
            // ComboConexion
            // 
            this.ComboConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexion.FormattingEnabled = true;
            this.ComboConexion.Location = new System.Drawing.Point(53, 72);
            this.ComboConexion.Name = "ComboConexion";
            this.ComboConexion.Size = new System.Drawing.Size(215, 21);
            this.ComboConexion.TabIndex = 3;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(288, 15);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(85, 35);
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
            this.BCancelar.Location = new System.Drawing.Point(288, 65);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(85, 35);
            this.BCancelar.TabIndex = 5;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BNuevo
            // 
            this.BNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BNuevo.Image")));
            this.BNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevo.Location = new System.Drawing.Point(217, 116);
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Size = new System.Drawing.Size(156, 35);
            this.BNuevo.TabIndex = 7;
            this.BNuevo.Text = "Crear nueva conexiión";
            this.BNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BNuevo.UseVisualStyleBackColor = true;
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
            // 
            // FormSelectConecion
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(379, 163);
            this.ControlBox = false;
            this.Controls.Add(this.BNuevo);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.ComboConexion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboGrupo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSelectConecion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectar";
            this.Load += new System.EventHandler(this.FormSelectConecion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboConexion;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BNuevo;
        private ConfiguradorApp Configuracion;
    }
}