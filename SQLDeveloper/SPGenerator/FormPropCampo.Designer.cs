namespace SPGenerator
{
    partial class FormPropCampo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropCampo));
            this.TComentario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CHAlias = new System.Windows.Forms.CheckBox();
            this.TAlias = new System.Windows.Forms.TextBox();
            this.CHSum = new System.Windows.Forms.CheckBox();
            this.CHCase = new System.Windows.Forms.CheckBox();
            this.BCase = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TComentario
            // 
            this.TComentario.Location = new System.Drawing.Point(4, 161);
            this.TComentario.Name = "TComentario";
            this.TComentario.Size = new System.Drawing.Size(304, 20);
            this.TComentario.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Comentarios";
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(51, 38);
            this.TTipo.Name = "TTipo";
            this.TTipo.ReadOnly = true;
            this.TTipo.Size = new System.Drawing.Size(257, 20);
            this.TTipo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(51, 6);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(257, 20);
            this.TNombre.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // CHAlias
            // 
            this.CHAlias.AutoSize = true;
            this.CHAlias.BackColor = System.Drawing.Color.Transparent;
            this.CHAlias.ForeColor = System.Drawing.Color.Black;
            this.CHAlias.Location = new System.Drawing.Point(4, 70);
            this.CHAlias.Name = "CHAlias";
            this.CHAlias.Size = new System.Drawing.Size(86, 17);
            this.CHAlias.TabIndex = 19;
            this.CHAlias.Text = "Asignar Alias";
            this.CHAlias.UseVisualStyleBackColor = false;
            // 
            // TAlias
            // 
            this.TAlias.Location = new System.Drawing.Point(87, 70);
            this.TAlias.Name = "TAlias";
            this.TAlias.Size = new System.Drawing.Size(100, 20);
            this.TAlias.TabIndex = 20;
            // 
            // CHSum
            // 
            this.CHSum.AutoSize = true;
            this.CHSum.BackColor = System.Drawing.Color.Transparent;
            this.CHSum.ForeColor = System.Drawing.Color.Black;
            this.CHSum.Location = new System.Drawing.Point(4, 95);
            this.CHSum.Name = "CHSum";
            this.CHSum.Size = new System.Drawing.Size(84, 17);
            this.CHSum.TabIndex = 21;
            this.CHSum.Text = "Sumar (sum)";
            this.CHSum.UseVisualStyleBackColor = false;
            // 
            // CHCase
            // 
            this.CHCase.AutoSize = true;
            this.CHCase.BackColor = System.Drawing.Color.Transparent;
            this.CHCase.ForeColor = System.Drawing.Color.Black;
            this.CHCase.Location = new System.Drawing.Point(4, 118);
            this.CHCase.Name = "CHCase";
            this.CHCase.Size = new System.Drawing.Size(85, 17);
            this.CHCase.TabIndex = 22;
            this.CHCase.Text = "Campo case";
            this.CHCase.UseVisualStyleBackColor = false;
            // 
            // BCase
            // 
            this.BCase.BackColor = System.Drawing.Color.Black;
            this.BCase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCase.Location = new System.Drawing.Point(95, 114);
            this.BCase.Name = "BCase";
            this.BCase.Size = new System.Drawing.Size(43, 23);
            this.BCase.TabIndex = 23;
            this.BCase.Text = "...";
            this.BCase.UseVisualStyleBackColor = false;
            this.BCase.Click += new System.EventHandler(this.BCase_Click);
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(326, 9);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 42);
            this.BAceptar.TabIndex = 17;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(326, 70);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 42);
            this.BCancelar.TabIndex = 18;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPropCampo
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(427, 200);
            this.ControlBox = false;
            this.Controls.Add(this.BCase);
            this.Controls.Add(this.CHCase);
            this.Controls.Add(this.CHSum);
            this.Controls.Add(this.TAlias);
            this.Controls.Add(this.CHAlias);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.TComentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPropCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del campo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.TextBox TComentario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CHAlias;
        private System.Windows.Forms.TextBox TAlias;
        private System.Windows.Forms.CheckBox CHSum;
        private System.Windows.Forms.CheckBox CHCase;
        private System.Windows.Forms.Button BCase;
        private System.Windows.Forms.Timer timer1;
    }
}