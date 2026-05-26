namespace LaraverTools.Formularios
{
    partial class FormLaravel
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
            this.modeloDatos1 = new LaraverTools.Modelo.ModeloDatos();
            this.cArbol1 = new LaraverTools.Arbol.CArbol();
            ((System.ComponentModel.ISupportInitialize)(this.modeloDatos1)).BeginInit();
            this.SuspendLayout();
            // 
            // modeloDatos1
            // 
            this.modeloDatos1.DataSetName = "ModeloDatos";
            this.modeloDatos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cArbol1
            // 
            this.cArbol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cArbol1.Location = new System.Drawing.Point(0, 0);
            this.cArbol1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cArbol1.Modelo = null;
            this.cArbol1.Name = "cArbol1";
            this.cArbol1.Size = new System.Drawing.Size(311, 724);
            this.cArbol1.TabIndex = 0;
            this.cArbol1.OnVerCodigo += new EditorManager.OnShowEditorGenericoEvent(this.cArbol1_OnVerCodigo);
            // 
            // FormLaravel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 724);
            this.Controls.Add(this.cArbol1);
            this.Name = "FormLaravel";
            this.Text = "FormLaravel";
            ((System.ComponentModel.ISupportInitialize)(this.modeloDatos1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Arbol.CArbol cArbol1;
        private Modelo.ModeloDatos modeloDatos1;
    }
}