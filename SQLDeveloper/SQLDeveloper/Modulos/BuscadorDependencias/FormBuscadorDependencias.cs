using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.BuscadorTablas
{
    public partial class FormBuscadorDependencias : Form
    {
        private List<Buscador.CNodoBusqueda> Encontrados = new List<Buscador.CNodoBusqueda>();
        MotorDB.IMotorDB MotorInicial;
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        private string Mensaje = "";
        private DataTable Tabla;
        string Origen;
        public FormBuscadorDependencias(MotorDB.IMotorDB motor)
        {
            InitializeComponent();
            MotorInicial = motor;
            cConecionesManager1.MotorInicial = motor;
            cConecionesManager1.CargaConexiones();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (TBuscar.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el objeto a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //me traigo las conexiones seleccionadas
            List<ManagerConnect.CConexion> conexiones = cConecionesManager1.DameConexionesSeleccionadas();
            if (conexiones.Count() == 0)
            {
                MessageBox.Show("Seleccione las conexiones a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //agrego las conexiones
            cBuscadorDependencias1.DameMotores().Clear();
            foreach (ManagerConnect.CConexion obj in conexiones)
            {

                cBuscadorDependencias1.AgregaMotor(ManagerConnect.ControladorConexiones.DameMotor(obj));
            }
            EnableButtons = false;
            cBuscadorDependencias1.ObjetoInicial = TBuscar.Text;
            cBuscadorDependencias1.Buscar();

        }
        private bool EnableButtons
        {
            set
            {
                BBuscar.Enabled = value;
                BExcluidos.Enabled = value;
                //if(value==false)
                  //  TBuscar.Enabled = true;
                cConecionesManager1.Enabled = value;
                BGenerarReporte.Enabled = value;
            }
            get
            {
                return BBuscar.Enabled;
            }
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            //       CNodoBusqueda nodo = (CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                //         OnVerObjeto(nodo.Motor, nodo.Nombre, nodo.Tipo);
            }

        }
        private void AgregaNodo(Buscador.CNodoBusqueda nodo, Buscador.CObjetoBusquedaAvanzado padre, Buscador.CNodoBusqueda hijo)
        {
            foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            {

                if (n.Nombre.ToUpper().Trim() == padre.Nombre.ToUpper().Trim() && n.Motor.GetDataBseName() == padre.Motor.GetDataBseName() && n.Tipo == padre.Tipo)
                {
                    try
                    {
                        Buscador.CNodoBusqueda nuevoNodo = new Buscador.CNodoBusqueda();
                        nuevoNodo.Nombre = hijo.Nombre;
                        nuevoNodo.Motor = hijo.Motor;
                        nuevoNodo.Tipo = hijo.Tipo;
                        nuevoNodo.Tag = padre;
                        n.Nodes.Add(nuevoNodo);
                    }
                    catch (System.Exception ex)
                    {
                        Mensaje = ex.Message;
                    }
                    return;
                }
                //como no es el padre, sigo la busqueda
                AgregaNodo(n, padre, hijo);
            }
        }
        private void TimerLLena_Tick(object sender, EventArgs e)
        {
            try
            {

                while (Encontrados.Count() > 0)
                {
                    Buscador.CNodoBusqueda nodo = Encontrados[0];
                    Encontrados.RemoveAt(0);
                    if (nodo.Nombre.ToUpper().Trim() == "Liq_EDOCTAContratoChkHist".ToUpper().Trim())
                        nodo.Nombre = "Liq_EDOCTAContratoChkHist";
                    //busco su lugar en la lista
                    if (nodo.Nombre.ToUpper().Trim() ==TBuscar.Text.ToUpper().Trim())
                    {
                        ListaObjetos.Nodes.Add(nodo);
                        return;

                    }
                    //no es el nodo raiz, por lo que recorro los nodos buscando el padre
                    Buscador.CObjetoBusquedaAvanzado padre = (Buscador.CObjetoBusquedaAvanzado)nodo.Tag;
                    foreach (Buscador.CNodoBusqueda n in ListaObjetos.Nodes)
                    {

                        if (padre != null && n.Nombre.ToUpper().Trim() == padre.Nombre.ToUpper().Trim() && n.Motor.GetDataBseName() == padre.Motor.GetDataBseName() && n.Tipo == padre.Tipo)
                        {
                            n.Nodes.Add(nodo);
                            return;
                        }
                        else
                        {
                            //como no es el padre, sigo la busqueda
                            AgregaNodo(n, padre, nodo);
                        }
                    }
                }
                if (EnableButtons == true)
                {
                    return;
                }
                LResultado.Text = Mensaje;
            }
            catch(System.Exception ex)
            {
                LResultado.Text = ex.Message;
                return;
            }
         //   LResultado.Text = ListaObjetos.Nodes.Count.ToString() + " Objetos encontrados";
        }
        
        //private void cBuscadorTabla1_OnMensaje(CBuscadorDependencias sender, string mensaje)
//        {
    //    }
         /// <summary>
        /// muestra el codigo del nodo y de todos sus hijos
        /// </summary>
        /// <param name="nodo"></param>
        private void VerCodigoCascada(Buscador.CNodoBusqueda nodo)
        {
            if (OnVerObjeto != null)
            {
                OnVerObjeto(nodo.Motor, nodo.Nombre, nodo.Tipo);
            }
            foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            {
                VerCodigoCascada(n);
            }
        }
        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea ver el codigo de todos los objetos? \nesta operacion puede ser muy tardada", "Ver codigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            foreach (Buscador.CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                VerCodigoCascada(nodo);
            }

        }

        private void verCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                OnVerObjeto(nodo.Motor, nodo.Nombre, nodo.Tipo);
            }
        }

        private void copiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            Clipboard.SetText(nodo.Nombre);
        }

        private void BGenerarReporte_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.Nodes.Count == 0)
                return;           
            DataReporte.Clear();
            //Tabla = DataReporte.Tables["Tabla"];
            //Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.Nodes[0]; //siempre el primer nodo es el origen
            //Origen = nodo.Nombre;
            //recorro todos los nodos hijos para agregarlos a la tabla
            //foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            //{
            //    AgregaATabla(nodo.Nombre, n);
            //}
            GeneraReporteArbol();
            GuardaArchivo();
        }
        private void agregaRegistro(string Origen, string Servidor, string Base, string Padre, string Objeto)
        {
            DataRow dr = Tabla.NewRow();
            dr["Origen"] = Origen;
            dr["Servidor"] = Servidor;
            dr["Base"] = Base;
            dr["Padre"] = Padre;
            dr["Objeto"] = Objeto;
            Tabla.Rows.Add(dr);
        }
        private void AgregaATabla(string padre, Buscador.CNodoBusqueda nodo)
        {
            //agrego el registro a la tabla
            ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(nodo.Motor);
            agregaRegistro(Origen, propiedades.Grupo, propiedades.Conexion.Nombre, padre, nodo.Nombre);
            //agrego todos sus hijos
            foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            {
                AgregaATabla(nodo.Nombre, n);
            }
        }
        /// <summary>
        /// guarda los datos en un archivo en csv
        /// </summary>
        private void GuardaArchivo()
        {
            BuscadorSeguidor.FormResultadoReporte dlg = new BuscadorSeguidor.FormResultadoReporte(Tabla);
            dlg.ShowDialog();
        }

        private void cBuscadorDependencias1_OnFinBusqueda(BuscadorDependencias.CBuscadorDependencias sender)
        {
            EnableButtons = true;
            waitControl1.Animar = false;
        }

        private void cBuscadorDependencias1_OnInicioBusqueda(BuscadorDependencias.CBuscadorDependencias sender)
        {
            LResultado.Text = "Buscando";
            Encontrados = new List<Buscador.CNodoBusqueda>();
            ListaObjetos.Nodes.Clear();
      //      Buscador.CNodoBusqueda nodo = new Buscador.CNodoBusqueda();
    //        nodo.Nombre = TBuscar.Text;
  //          nodo.Motor = null;
//            ListaObjetos.Nodes.Add(nodo);
            waitControl1.Animar = true;
            Mensaje = "Analizando:" + TBuscar.Text;

        }

        private void cBuscadorDependencias1_OnMotorChange(BuscadorDependencias.CBuscadorDependencias sender)
        {

        }

        private void cBuscadorDependencias1_OnObjetoEncontrado(BuscadorDependencias.CBuscadorDependencias sender, BuscadorDependencias.CObjetoBusquedaDependencia objeto)
        {
            Buscador.CNodoBusqueda nodo = new Buscador.CNodoBusqueda();
            nodo.Nombre = objeto.Nombre;
            //            if (hijo.NombreLargo.Trim() != "")
            //              nodo.Nombre = hijo.NombreLargo;
            //nodo.Tag = hijo.Nombre;
            nodo.Tipo = objeto.Tipo;
            nodo.Motor = objeto.Motor;
            nodo.Tag = objeto.objetoPadre;
            Encontrados.Add(nodo);
        }

        private void cBuscadorDependencias1_OnMensaje(BuscadorDependencias.CBuscadorDependencias sender, string msg)
        {
                      Mensaje = msg;

        }

        private void resaltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            nodo.BackColor = Color.YellowGreen;
//            Clipboard.SetText(nodo.Nombre);

        }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            //nodo.BackColor = Color.Red;
            ListaObjetos.Nodes.Remove(nodo);

        }

        private void copiarYResaltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            nodo.BackColor = Color.YellowGreen;
            Clipboard.SetText(nodo.Nombre);

        }
        /// <summary>
        /// genera el reporte en forma de arbol
        /// </summary>
        private void GeneraReporteArbol()
        {
            Tabla = new DataTable();
            Tabla.Columns.Add("Columna1");
            //ahora recorro toos los nodos raiz para irlos agregando
            foreach(Buscador.CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                AgregaNodoReporteArbol(nodo, 1);
            }
        }
        /// <summary>
        /// Agrega el nodo al reporte 
        /// </summary>
        /// <param name="nodo">Nodo que se va a agregar</param>
        /// <param name="nivel">Numero de columna en la que hay que agregarlo</param>
        private void AgregaNodoReporteArbol(Buscador.CNodoBusqueda nodo, int nivel)
        {
            //verifico si existe la columna
            VerificaColumna(nivel);
            //agrego el registro
            DataRow dr = Tabla.NewRow();
            string nombreColumna = "Columna" + nivel;
            dr[nombreColumna] = nodo.ToString();
            Tabla.Rows.Add(dr);
            //ahora agrego todos sus hijos
            foreach(Buscador.CNodoBusqueda nodo2 in nodo.Nodes)
            {
                AgregaNodoReporteArbol(nodo2, nivel + 1);
            }
        }
        /// <summary>
        /// checa si en la tabla ya existe la columna correspondiente al nivel y si no esta lo agrega
        /// </summary>
        /// <param name="nivel"></param>
        private void VerificaColumna(int nivel)
        {
            string nombreColumna = "Columna" + nivel;
            foreach(DataColumn col in Tabla.Columns)
            {
                if (col.ColumnName == nombreColumna)
                    return;
            }
            //no existe, por lo que lo agrego
            Tabla.Columns.Add(nombreColumna);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cBuscadorDependencias1.AdministraExcluidos();
        }

        private void enviarAExcluidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            cBuscadorDependencias1.AgregarExcluido(nodo.ToString());
        }

        private void desmarcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
            {
                return;
            }
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            nodo.BackColor = Color.White;

        }

        private void ListaObjetos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Buscador.CNodoBusqueda nodo = (Buscador.CNodoBusqueda)e.Node;
            string nombre = "";
            if (nodo != null)
                nombre=nodo.Nombre.ToUpper().Trim();
            foreach(Buscador.CNodoBusqueda n in ListaObjetos.Nodes)
            {
                if(n.Nombre.ToUpper().Trim()==nombre)
                {
                    n.ForeColor = Color.BlueViolet;
                }
                else
                {
                    n.ForeColor = Color.Black;
                }
                resalta(n, nombre);
            }
        }
        /// <summary>
        /// marca todos los nodos que tengan el mismo nombre
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="nombre"></param>
        private void resalta(Buscador.CNodoBusqueda nodo, string nombre)
        {
            foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            {
                if (n.Nombre.ToUpper().Trim() == nombre)
                {
                    n.ForeColor = Color.BlueViolet; //BlueViolet Coral Tan Tomato
                }
                else
                {
                    n.ForeColor = Color.Black;
                }
                resalta(n, nombre);
            }
        }
    }
}

