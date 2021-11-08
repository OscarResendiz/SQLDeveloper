using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public delegate EditorManager.EditorGenerico OnFormAppsAnalizerCodigoEvent(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null);
    public delegate void FormAppsAnalizerEvent(FormAppsAnalizer sender, string value);
    public delegate void FormAppsAnalizerSimpleEvent(string value);
    public delegate void FormAppsAnalizerEventEditorComentaro(Editores.CEditorComentarios editor, string nombre);
    public partial class FormAppsAnalizer : Form
    {
        public event OnFormAppsAnalizerCodigoEvent ONVerCodigo;
        public event FormAppsAnalizerEvent OnCerrarProyecto;
        public event FormAppsAnalizerSimpleEvent OnAbrirArchivo;
        Nodos.CNodoProyecto Proyecto;
        public event FormAppsAnalizerEventEditorComentaro OnEditorComentaro;
        private bool cerrando = false;
        public FormAppsAnalizer()
        {
            InitializeComponent();
            cProcesoAvance1.SetHistoryModel(cHistoryModel1);
            Lista.Tag = this;
            CargaProyecto();
        }
        private void CargaProyecto()
        {
            foreach(Nodos.CNodoBase n in Lista.Nodes)
            {
                n.Free();
            }
            Lista.Nodes.Clear();

            if (Proyecto != null)
            {
            //    Proyecto.OnCerrarproyecto -= CerrarProyecto;
                Proyecto = null;
            }
            Proyecto = new Nodos.CNodoProyecto();
            Proyecto.Modelo = appModel1;
            Lista.Nodes.Add(Proyecto);
            //Proyecto.Nombre = DameNombre(modeloBasico1.FileName);
            //Proyecto.OnCerrarproyecto += new CNodoProyectoEvent(CerrarProyecto);
            //appModel1.MonitorearEnable = true;
//            this.Text = Proyecto.Nombre;
        }
        private bool FiltraNodos(Nodos.CNodoBase nodo, string filtro, bool ocultarHijos = true)
        {
            bool encontrado = false;
            bool borrar = true;
            if (nodo.Nombre.ToUpper().Contains(filtro.ToUpper().Trim()))
            {
                //lo resalto y dejo todo su contenido
                nodo.ForeColor = Color.Red;
                encontrado = true;
                borrar = false;
                ocultarHijos = false;
            }

            int max = nodo.Nodes.Count;
            for (int i = max - 1; i >= 0; i--)
            {
                Nodos.CNodoBase n = (Nodos.CNodoBase)nodo.Nodes[i];
                if (FiltraNodos(n, filtro, ocultarHijos) == true)
                {
                    encontrado = true;
                    nodo.Expand();
                }
                else
                {
                    if (borrar && ocultarHijos)
                        nodo.Nodes.Remove(n);
                }
            }
            //veo si coincide el mio
            return encontrado;
        }

        private void TBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BBuscar_Click(null, null);
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            CargaProyecto();
            if (TBuscar.Text.Trim() != "")
                FiltraNodos(Proyecto, TBuscar.Text);
        }

        private void Lista_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)e.Node;
            nodo.Colapsado();
        }

        private void Lista_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)e.Node;
            nodo.Expandido();
            nodo.PreparaMenu();

        }

        private void Lista_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)e.Node;
            if (nodo == null)
                return;
            nodo.Seleccionado();

        }

        private void Lista_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = Lista.PointToClient(new Point(e.X, e.Y));
            Nodos.CNodoBase destino = (Nodos.CNodoBase)Lista.GetNodeAt(targetPoint);
            Nodos.CNodoBase nodo = null;
            if (destino == null)
            {
                return;
            }
            
            nodo = (Nodos.CNodoBase)e.Data.GetData(typeof(Nodos.CNodoCarpeta));
            if (nodo == null)
            {
                nodo = (Nodos.CNodoBase)e.Data.GetData(typeof(Nodos.CNodoArchivo));
            }
            if (nodo == null)
            {
                nodo = (Nodos.CNodoBase)e.Data.GetData(typeof(Nodos.CNodoDocumento));
            }
            if (nodo == null)
            {
                nodo = (Nodos.CNodoBase)e.Data.GetData(typeof(Nodos.CNodoScript));
            }
            if (nodo == null)
            {
                nodo = (Nodos.CNodoBase)e.Data.GetData(typeof(Nodos.CNodoObjetoCarpeta));
            }
             
            if (nodo == null)
                return;
            try
            {
                destino.NodeDrop(nodo);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lista_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void Lista_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = Lista.PointToClient(new Point(e.X, e.Y));
            // Select the node at the mouse position.
            Lista.SelectedNode = Lista.GetNodeAt(targetPoint);

        }

        private void Lista_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)e.Item;
            if (nodo == null)
            {
                return;
            }
            if (nodo.GetType() == typeof(Nodos.CNodoCarpeta) || nodo.GetType() == typeof(Nodos.CNodoArchivo) || nodo.GetType() == typeof(Nodos.CNodoDocumento) || nodo.GetType() == typeof(Nodos.CNodoScript) || nodo.GetType() == typeof(Nodos.CNodoObjetoCarpeta))
            {
                //aqui se pone lo base bueno
                DoDragDrop(nodo, DragDropEffects.Move);
            }

        }

        private void Lista_MouseDown(object sender, MouseEventArgs e)
        {
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)Lista.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            nodo.PreparaMenu();

        }

        private void Lista_MouseUp(object sender, MouseEventArgs e)
        {
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)Lista.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            Lista.SelectedNode = nodo;
            //nodo.Seleccionado();

        }

        private void Lista_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)e.Node;
            if (nodo != null)
                nodo.DoubleClick(e);

        }

        private void FormAppsAnalizer_Load(object sender, EventArgs e)
        {
            cProcesoAvance1_VisibleOff(null);
            appModel1.CerrarModeloEvent += new ObjetosModelo.OnModeloEventDelegate(appModel1_CerrarModeloEvent_);
            cHistoryModel1.Modelo = appModel1;
            //cHistoryModel1.Inicializa(appModel1);
        }
        public void appModel1_CerrarModeloEvent_(ObjetosModelo.AppModel obj)
        {
            if (OnCerrarProyecto != null)
                OnCerrarProyecto(this, appModel1.FileName); 
        }
        public EditorManager.EditorGenerico VerCodigo(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null)
        {
            if (ONVerCodigo != null)
            {
                return ONVerCodigo(objeto, codigo, motor, grupo, conexion, fm);
            }
            return null;
        }
        public void EditorComentario(Editores.CEditorComentarios edit, string nombre)
        {
            if (OnEditorComentaro != null)
                OnEditorComentaro(edit, nombre);
        }
        public void AbirArchivo(string archivo)
        {
            if (OnAbrirArchivo != null)
                OnAbrirArchivo(archivo);
        }
        public CProcesoAvance getProcesoAvance()
        {
            return cProcesoAvance1;
        }

        private void cProcesoAvance1_VisibleOn(CProcesoAvance e)
        {
            splitContainer1.Panel2Collapsed = false;
        }

        private void cProcesoAvance1_VisibleOff(CProcesoAvance e)
        {
            splitContainer1.Panel2Collapsed = true;

        }

        private void FormAppsAnalizer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrando == false)
            {
                cerrando = true;
                appModel1.Cerrar();
            }
        }

        private void Lista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Lista.SelectedNode==null)
                return;
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)Lista.SelectedNode;
            nodo.KeyPress(nodo,e);
        }

        private void Lista_KeyUp(object sender, KeyEventArgs e)
        {
            if (Lista.SelectedNode == null)
                return;
            Nodos.CNodoBase nodo = (Nodos.CNodoBase)Lista.SelectedNode;
            nodo.KeyUp(nodo, e);

        }
        public ObjetosModelo.CHistoryModel GetHistoryModel()
        {
            return cHistoryModel1;
        }
    }
}
   