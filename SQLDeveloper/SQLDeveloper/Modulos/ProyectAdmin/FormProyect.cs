using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public delegate EditorManager.EditorGenerico OnFormProyectCodigoEvent(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null);
    public delegate void FormProyectEvent(FormProyect sender,string value);
    public delegate void FormProyectEventComparer(string opcion1, string opcion2, string titulo1, string titulo2, string ColorEditor);
    public delegate void FormProyectEventEditorComentaro(Editores.CEditorComentarios editor,string nombre);
    public partial class FormProyect : Form
    {
        public event OnFormProyectCodigoEvent ONVerCodigo;
        private CNodoProyecto Proyecto;
        public event FormProyectEvent OnCerrarProyecto;
        public event FormProyectEventComparer OnComparar;
        public event FormProyectEventEditorComentaro OnEditorComentaro;
        public FormProyect(string filename)
        {
            InitializeComponent();
            modeloBasico1.FileName = filename;
            Lista.Tag = this;
        }
        public FormProyect(ModeloBasico modelo)
        {
            InitializeComponent();
            modeloBasico1=modelo;
            Lista.Tag = this;
        }
        private string DameNombre(string filename)
        {
            //le quito la ruta y la extencion
            string s = "";
            int posDiagonal = filename.Length-1;
            while (posDiagonal > 0 && filename[posDiagonal] != '\\')
                posDiagonal--;
            int posPunto = posDiagonal;
            while (posPunto < filename.Length && filename[posPunto] != '.')
                posPunto++;
            s=filename.Substring(posDiagonal+1,posPunto-posDiagonal-1);
            if (s == "")
                return "Sin Nombre";
            return s;
        }
        private void CargaProyecto()
        {
            Lista.Nodes.Clear();
            if(Proyecto!=null)
            {
                Proyecto.OnCerrarproyecto -= CerrarProyecto;
                Proyecto = null;
            }
            GC.Collect(); 
            Proyecto = new CNodoProyecto();
            Proyecto.Modelo = modeloBasico1;
            Proyecto.Nombre = DameNombre(modeloBasico1.FileName);
            Proyecto.OnCerrarproyecto += new CNodoProyectoEvent(CerrarProyecto);
            Lista.Nodes.Add(Proyecto);
            modeloBasico1.MonitorearEnable = true;
            this.Text = Proyecto.Nombre;
        }
        private void FormProyect_Load(object sender, EventArgs e)
        {
            CargaProyecto();
        }
        private void Lista_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Colapsado();
        }

        private void Lista_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.Expandido();
            nodo.PreparaMenu();

        }
        private void Lista_MouseUp(object sender, MouseEventArgs e)
        {
            CNodoBase nodo=(CNodoBase)Lista.GetNodeAt(e.X,e.Y);
            if(nodo==null)
                return;
           Lista.SelectedNode=nodo;
           nodo.Seleccionado();
        }
        private void Monitorea(CNodoBase nodo)
        {
            foreach(CNodoBase nodo2 in nodo.Nodes)
            {
                nodo2.Monitorea();
                Monitorea(nodo2);
            }
        }
        private void IniciaMonitoreo()
        {
            foreach (CNodoBase nodo in Lista.Nodes)
            {
                nodo.Monitorea();
                Monitorea(nodo);
            }

        }
        private void TimerMonitoreo_Tick(object sender, EventArgs e)
        {
            //IniciaMonitoreo();
        }

        private void TimerInicial_Tick(object sender, EventArgs e)
        {
         //   TimerInicial.Enabled = false;
            //IniciaMonitoreo();
        }
        public EditorManager.EditorGenerico VerCodigo(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null)
        {
            if (ONVerCodigo != null)
            {
                return ONVerCodigo(objeto, codigo, motor, grupo, conexion, fm);
            }
            return null;
        }

        private void Lista_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            if (nodo == null)
                return;
            nodo.Seleccionado();

        }
        private void CerrarProyecto(CNodoProyecto sender)
        {
            if (OnCerrarProyecto != null)
                OnCerrarProyecto(this, modeloBasico1.FileName);
        }

        private void Lista_MouseDown(object sender, MouseEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)Lista.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            nodo.PreparaMenu();
        }

        private void Lista_ItemDrag(object sender, ItemDragEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Item;
            if (nodo == null)
            {
                return;
            }
            if (nodo.GetType() == typeof(CNodoCarpeta) || nodo.GetType() == typeof(CNodoObjeto) || nodo.GetType() == typeof(CNodoScript) || nodo.GetType() == typeof(CNodoDocument))
            {
                //aqui se pone lo base bueno
                DoDragDrop(nodo, DragDropEffects.Move);
            }
        }

        private void Lista_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = Lista.PointToClient(new Point(e.X, e.Y));
            CNodoBase destino = (CNodoBase)Lista.GetNodeAt(targetPoint);
            CNodoBase nodo = null;
            if(destino==null)
            {
                return;
            }
            //if(e.Data.GetDataPresent())
            nodo = (CNodoBase)e.Data.GetData(typeof(CNodoObjeto));
            if (nodo == null)
            {
                nodo = (CNodoBase)e.Data.GetData(typeof(CNodoCarpeta));
            }
            if (nodo == null)
            {
                nodo = (CNodoBase)e.Data.GetData(typeof(CNodoScript));
            }
            if (nodo == null)
            {
                nodo = (CNodoBase)e.Data.GetData(typeof(CNodoDocument));
            }
            if (nodo == null)
                return;
            try
            {
                destino.NodeDrop(nodo);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lista_DragOver(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Move;
            Point targetPoint = Lista.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            Lista.SelectedNode = Lista.GetNodeAt(targetPoint);
        }

        private void Lista_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = e.AllowedEffect;
        }
        public void Comparar(string opcion1, string opcion2, string titulo1, string titulo2, string ColorEditor)
        {
            if (OnComparar != null)
                OnComparar(opcion1, opcion2, titulo1, titulo2, ColorEditor);
        }
        public void EditorComentario(Editores.CEditorComentarios edit, string nombre)
        {
            if (OnEditorComentaro != null)
                OnEditorComentaro(edit, nombre);
        }

        private void Lista_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            if (nodo != null)
                nodo.DoubleClick(e);
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            CargaProyecto();
            if(TBuscar.Text.Trim()!="")
                FiltraNodos(Proyecto, TBuscar.Text);
        }
        private bool FiltraNodos(CNodoBase nodo, string filtro, bool ocultarHijos=true)
        {
            bool encontrado = false;
            bool borrar = true;
            if (nodo.Nombre.ToUpper().Contains(filtro.ToUpper().Trim()))
            {
                //lo resalto y dejo todo su contenido
                nodo.ForeColor = Color.Red;
                encontrado= true;
                borrar = false;
                ocultarHijos = false;
            }
                
            int max = nodo.Nodes.Count;
            for (int i = max - 1; i >= 0; i--)
            {
                CNodoBase n = (CNodoBase)nodo.Nodes[i];
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
    }
}
   