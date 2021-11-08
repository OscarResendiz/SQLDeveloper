namespace SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores
{
    partial class GeneradorCSharp
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
            this.BkGenerador = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            // 
            // BkGenerador
            // 
            this.BkGenerador.WorkerReportsProgress = true;
            this.BkGenerador.WorkerSupportsCancellation = true;
            this.BkGenerador.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkGenerador_DoWork);
            this.BkGenerador.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkGenerador_ProgressChanged);
            this.BkGenerador.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkGenerador_RunWorkerCompleted);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BkGenerador;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
