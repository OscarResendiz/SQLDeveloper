namespace SQLDeveloper.Modulos.BuscadorSeguidor
{
    partial class CBuscadorSeguidor
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
            this.cBuscadorAvanzado1 = new SQLDeveloper.Modulos.Buscador.CBuscadorAvanzado();
            this.lecxer1 = new Compiler.Lexer.Lecxer(this.components);
            // 
            // cBuscadorAvanzado1
            // 
            this.cBuscadorAvanzado1.OnMotorChange += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnMotorChange);
            this.cBuscadorAvanzado1.OnFiltroChange += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFiltroChange);
            this.cBuscadorAvanzado1.OnObjetoEncontrado += new SQLDeveloper.Modulos.Buscador.OnObjetoEncontradoEvent(this.cBuscadorAvanzado1_OnObjetoEncontrado);
            this.cBuscadorAvanzado1.OnInicioBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnInicioBusqueda);
            this.cBuscadorAvanzado1.OnFinBusqueda += new SQLDeveloper.Modulos.Buscador.OnBusquedaAvanzadaEvent(this.cBuscadorAvanzado1_OnFinBusqueda);
            // 
            // lecxer1
            // 
            this.lecxer1.Cadena = "";

        }

        #endregion

        private Buscador.CBuscadorAvanzado cBuscadorAvanzado1;
        private Compiler.Lexer.Lecxer lecxer1;

    }
}
