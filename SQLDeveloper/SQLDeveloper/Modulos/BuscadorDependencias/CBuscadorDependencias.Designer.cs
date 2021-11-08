namespace SQLDeveloper.Modulos.BuscadorDependencias
{
    partial class CBuscadorDependencias
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
            this.components = new System.ComponentModel.Container();
            this.BuscadorBk = new System.ComponentModel.BackgroundWorker();
            this.lecxer1 = new Compiler.Lexer.Lecxer(this.components);
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            // 
            // BuscadorBk
            // 
            this.BuscadorBk.WorkerReportsProgress = true;
            this.BuscadorBk.WorkerSupportsCancellation = true;
            this.BuscadorBk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BuscadorBk_DoWork);
            this.BuscadorBk.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BuscadorBk_ProgressChanged);
            this.BuscadorBk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BuscadorBk_RunWorkerCompleted);
            // 
            // lecxer1
            // 
            this.lecxer1.Cadena = "";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1});
            this.dataTable1.TableName = "Excluido";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "objeto";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BuscadorBk;
        private Compiler.Lexer.Lecxer lecxer1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
    }
}
