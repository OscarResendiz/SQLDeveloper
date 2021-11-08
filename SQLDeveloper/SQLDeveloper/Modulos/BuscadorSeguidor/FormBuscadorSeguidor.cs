using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace SQLDeveloper.Modulos.BuscadorSeguidor
{
    public partial class FormBuscadorSeguidor : Form
    {
        private List<Buscador.CNodoBusqueda> Encontrados = new List<Buscador.CNodoBusqueda>();
        MotorDB.IMotorDB MotorInicial;
        public event MotorDB.OnVerObjetoEvent OnVerObjeto;
        ManagerConnect.CNodoRaiz NodoRaiz;
        private string Mensaje="";
        private DataTable Tabla;
        string Origen;
        public FormBuscadorSeguidor(MotorDB.IMotorDB motor)
        {
            MotorInicial = motor;
            InitializeComponent();
            CargaConexiones();
        }
        private void CargaConexiones()
        {
            NodoRaiz = new ManagerConnect.CNodoRaiz();
            treeView1.Nodes.Add(NodoRaiz);
            NodoRaiz.CargaGrupos();
            if (MotorInicial != null)
            {
                NodoRaiz.MarcaMotor(MotorInicial);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ManagerConnect.CNodoBase nodo = (ManagerConnect.CNodoBase)e.Node;
            nodo.AfterCheck();

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (TBuscar.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el objeto a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //me traigo las conexiones seleccionadas
            List<ManagerConnect.CConexion> conexiones = NodoRaiz.DameConexionesSeleccionadas();
            if (conexiones.Count() == 0)
            {
                MessageBox.Show("Seleccione las conexiones a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //agrego las conexiones
            cBuscadorSeguidor1.DameMotores().Clear();
            foreach (ManagerConnect.CConexion obj in conexiones)
            {

                cBuscadorSeguidor1.AgregaMotor(ManagerConnect.ControladorConexiones.DameMotor(obj));
            }
            EnableButtons = false;
            cBuscadorSeguidor1.ObjetoBuscar = TBuscar.Text;
            cBuscadorSeguidor1.Buscar();

        }
        private bool EnableButtons
        {
            set
            {
                BBuscar.Enabled = value;
                TBuscar.Enabled = value;
                treeView1.Enabled = value;
                BGenerarReporte.Enabled = value;
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

        private void cBuscadorSeguidor1_OnInicio(CBuscadorSeguidor sender)
        {
            LResultado.Text = "Buscando";
            Encontrados = new List<Buscador.CNodoBusqueda>();
            ListaObjetos.Nodes.Clear();
            Buscador.CNodoBusqueda nodo = new Buscador.CNodoBusqueda();
            nodo.Nombre = TBuscar.Text;
            nodo.Motor = null;
            ListaObjetos.Nodes.Add(nodo);
            waitControl1.Animar = true;
            Mensaje = "Analizando:" + TBuscar.Text;        
        }

        private void cBuscadorSeguidor1_OnFinProceso(CBuscadorSeguidor sender)
        {
            EnableButtons = true;
            waitControl1.Animar = false;
        }

        private void cBuscadorSeguidor1_OnObjetoEncontrado(CBuscadorSeguidor sender, Buscador.CObjetoBusquedaAvanzado padre, Buscador.CObjetoBusquedaAvanzado hijo)
        {
            Buscador.CNodoBusqueda nodo = new Buscador.CNodoBusqueda();
            nodo.Nombre = hijo.Nombre;
            nodo.Tipo = hijo.Tipo;
            nodo.Motor = hijo.Motor;
            nodo.Tag = padre;
            Encontrados.Add(nodo);

        }
        private void AgregaNodo(Buscador.CNodoBusqueda nodo, Buscador.CObjetoBusquedaAvanzado padre, Buscador.CNodoBusqueda hijo)
        {
            foreach (Buscador.CNodoBusqueda n in nodo.Nodes)
            {
                if (n.Nombre.ToUpper().Trim() == padre.Nombre.ToUpper().Trim() && n.Motor.GetConnectionName() == padre.Motor.GetConnectionName())
                {
                    try
                    {
                        Buscador.CNodoBusqueda nuevoNodo = new Buscador.CNodoBusqueda();
                        nuevoNodo.Nombre = hijo.Nombre;
                        nuevoNodo.Motor = hijo.Motor;
                        nuevoNodo.Tipo = hijo.Tipo;
                        n.Nodes.Add(nuevoNodo);
                    }
                    catch(System.Exception ex)
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
            
            while (Encontrados.Count() > 0)
            {
                Buscador.CNodoBusqueda nodo = Encontrados[0];
                Encontrados.RemoveAt(0);
                //busco su lugar en la lista
                //no es el nodo raiz, por lo que recorro los nodos buscando el padre
                Buscador.CObjetoBusquedaAvanzado padre = (Buscador.CObjetoBusquedaAvanzado)nodo.Tag;
                foreach (Buscador.CNodoBusqueda n in ListaObjetos.Nodes)
                {

                    if (n.Text.ToUpper().Trim() == padre.Nombre.ToUpper().Trim())
                    {
                        if (n.Motor == null)
                        {
                            n.Nodes.Add(nodo);
                        }
                        else if (n.Motor.GetConnectionName() == padre.Motor.GetConnectionName())
                        {
                            n.Nodes.Add(nodo);
                        }
                        return;
                    }
                    else
                    {
                        //como no es el padre, sigo la busqueda
                        AgregaNodo(n, padre, nodo);
                    }
                }
            }
            LResultado.Text = Mensaje;
            //LResultado.Text = ListaObjetos.Nodes.Count.ToString() + " Objetos encontrados";
        }

        private void cBuscadorSeguidor1_OnMensaje(CBuscadorSeguidor sender, string mensaje)
        {
            Mensaje = mensaje;
        }
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
            if(MessageBox.Show("¿Seguro que desea ver el codigo de todos los objetos? \nesta operacion puede ser muy tardada","Ver codigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.Yes)
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
            if(ListaObjetos.SelectedNode==null)
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
            if(treeView1.Nodes.Count==0)
                return;
            DataReporte.Clear();
             Tabla= DataReporte.Tables["Tabla"];
             TreeNode nodo = ListaObjetos.Nodes[0]; //siempre el primer nodo es el origen
            Origen=nodo.Text;
            //recorro todos los nodos hijos para agregarlos a la tabla
            foreach(Buscador.CNodoBusqueda n in nodo.Nodes)
            {
                AgregaATabla(nodo.Text, n);
            }
            GuardaArchivo();
        }
        private void agregaRegistro(string Origen,string Servidor,string Base,string Padre,string Objeto)
        {
            DataRow dr = Tabla.NewRow();
            dr["Origen"]=Origen;
            dr["Servidor"]=Servidor;
            dr["Base"]=Base;
            dr["Padre"]=Padre;
            dr["Objeto"]=Objeto;
            Tabla.Rows.Add(dr);
        }
        private void AgregaATabla(string padre, Buscador.CNodoBusqueda nodo )
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
            FormResultadoReporte dlg = new FormResultadoReporte(Tabla);
            dlg.ShowDialog();
        }

    }
}

   