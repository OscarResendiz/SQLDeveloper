namespace SQLDeveloper.Modulos.Visores.Variables
{
    partial class FormVariables
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Lista = new System.Windows.Forms.ListBox();
            this.BkAnalisador = new System.ComponentModel.BackgroundWorker();
            this.lecxer1 = new Compiler.Lexer.Lecxer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Lista);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(309, 491);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 0;
            // 
            // Lista
            // 
            this.Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(0, 36);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(309, 151);
            this.Lista.Sorted = true;
            this.Lista.TabIndex = 0;
            this.Lista.SelectedIndexChanged += new System.EventHandler(this.Lista_SelectedIndexChanged);
            // 
            // BkAnalisador
            // 
            this.BkAnalisador.WorkerReportsProgress = true;
            this.BkAnalisador.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkAnalisador_DoWork);
            this.BkAnalisador.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkAnalisador_ProgressChanged);
            // 
            // lecxer1
            // 
            this.lecxer1.Cadena = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TFiltro);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 36);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtro";
            // 
            // TFiltro
            // 
            this.TFiltro.Location = new System.Drawing.Point(38, 8);
            this.TFiltro.Name = "TFiltro";
            this.TFiltro.Size = new System.Drawing.Size(230, 20);
            this.TFiltro.TabIndex = 1;
            this.TFiltro.TextChanged += new System.EventHandler(this.TFiltro_TextChanged);
            // 
            // FormVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 491);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormVariables";
            this.Text = "FormVariables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVariables_FormClosing);
            this.Load += new System.EventHandler(this.FormVariables_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox Lista;
        private System.ComponentModel.BackgroundWorker BkAnalisador;
        private Compiler.Lexer.Lecxer lecxer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TFiltro;
        private System.Windows.Forms.Label label1;
    }
}