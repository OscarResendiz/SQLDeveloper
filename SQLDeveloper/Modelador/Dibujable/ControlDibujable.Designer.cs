namespace Modelador.Dibujable
{
    partial class ControlDibujable
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // ControlDibujable
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(420, 291);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ControlDibujable_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ControlDibujable_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlDibujable_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlDibujable_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlDibujable_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
