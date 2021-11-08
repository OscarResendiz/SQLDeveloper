namespace SQLDeveloper.Modulos.ProyectAdmin
{
    partial class CProjectManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CProjectManager));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.HistoryData = new System.Data.DataSet();
            this.ProjetFiles = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjetFiles)).BeginInit();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SQLDeveloper";
            this.notifyIcon1.Visible = true;
            // 
            // HistoryData
            // 
            this.HistoryData.DataSetName = "NewDataSet";
            this.HistoryData.Tables.AddRange(new System.Data.DataTable[] {
            this.ProjetFiles});
            // 
            // ProjetFiles
            // 
            this.ProjetFiles.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.ProjetFiles.TableName = "ProjetFiles";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "FileName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Path";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Fecha";
            this.dataColumn3.DataType = typeof(System.DateTime);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjetFiles)).EndInit();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Data.DataSet HistoryData;
        private System.Data.DataTable ProjetFiles;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
    }
}
