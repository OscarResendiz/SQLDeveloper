namespace SQLDeveloper.Modulos.Comparador
{
    partial class FormEsperar
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
            this.waitControl1 = new WaitControl.WaitControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // waitControl1
            // 
            this.waitControl1.Animar = true;
            this.waitControl1.BackColor = System.Drawing.Color.Red;
            this.waitControl1.Location = new System.Drawing.Point(2, 12);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.Red;
            this.waitControl1.SegundoColor = System.Drawing.Color.Navy;
            this.waitControl1.Size = new System.Drawing.Size(446, 22);
            this.waitControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormEsperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 46);
            this.ControlBox = false;
            this.Controls.Add(this.waitControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEsperar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEsperar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEsperar_FormClosing);
            this.Load += new System.EventHandler(this.FormEsperar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.Timer timer1;
    }
}