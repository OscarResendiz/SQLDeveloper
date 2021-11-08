namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    partial class CAnalizadorDependencias
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cBuscadorDependencias1 = new SQLDeveloper.Modulos.BuscadorDependencias.CBuscadorDependencias();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // cBuscadorDependencias1
            // 
            this.cBuscadorDependencias1.ObjetoInicial = null;
            this.cBuscadorDependencias1.OnObjetoEncontrado += new SQLDeveloper.Modulos.BuscadorDependencias.OnObjetoDependenciaEncontradoEvent(this.cBuscadorDependencias1_OnObjetoEncontrado);
            this.cBuscadorDependencias1.OnObjetoAnalizado += new SQLDeveloper.Modulos.BuscadorDependencias.OnObjetoDependenciaEncontradoEvent(this.cBuscadorDependencias1_OnObjetoAnalizado);
            this.cBuscadorDependencias1.OnFinBusqueda += new SQLDeveloper.Modulos.BuscadorDependencias.OnBusquedaDependenciaEvent(this.cBuscadorDependencias1_OnFinBusqueda);
            this.cBuscadorDependencias1.OnMensaje += new SQLDeveloper.Modulos.BuscadorDependencias.OnObjetoDependenciaMensajeEvent(this.cBuscadorDependencias1_OnMensaje);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

        }

        #endregion

        private BuscadorDependencias.CBuscadorDependencias cBuscadorDependencias1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}
   