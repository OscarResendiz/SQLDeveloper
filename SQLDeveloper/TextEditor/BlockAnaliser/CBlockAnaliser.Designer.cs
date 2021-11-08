namespace TextEditor
{
    partial class CBlockAnaliser
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
            this.BKAnaliser = new System.ComponentModel.BackgroundWorker();
            // 
            // BKAnaliser
            // 
            this.BKAnaliser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKAnaliser_DoWork);
            this.BKAnaliser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKAnaliser_RunWorkerCompleted);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BKAnaliser;
    }
}
