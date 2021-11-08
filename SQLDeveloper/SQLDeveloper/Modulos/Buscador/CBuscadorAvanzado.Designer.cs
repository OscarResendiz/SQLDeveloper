namespace SQLDeveloper.Modulos.Buscador
{
    partial class CBuscadorAvanzado
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BuscadorBk = new System.ComponentModel.BackgroundWorker();
            // 
            // BuscadorBk
            // 
            this.BuscadorBk.WorkerReportsProgress = true;
            this.BuscadorBk.WorkerSupportsCancellation = true;
            this.BuscadorBk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BuscadorBk_DoWork);
            this.BuscadorBk.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BuscadorBk_ProgressChanged);
            this.BuscadorBk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BuscadorBk_RunWorkerCompleted);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker BuscadorBk;
    }
}
