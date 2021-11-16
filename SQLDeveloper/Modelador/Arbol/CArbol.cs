using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditorManager;
namespace Modelador.Arbol
{
    public partial class CArbol : UserControl
    {
        public event OnShowEditorGenericoEvent OnVerModelo;
        public event OnShowEditorGenericoEvent OnVerCodigo;
        private CNodoProyecto NodoProyecto;
        private Modelo.ModeloDatos FModelo=null;
        public Modelo.ModeloDatos Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if (FModelo == null)
                    return;
                Inicializa();
            }
        }
        public CArbol()
        {
            InitializeComponent();
        }
        private void Inicializa()
        {
            NodoProyecto = new CNodoProyecto();
            NodoProyecto.Modelo = FModelo;
            NodoProyecto.VerModelo += OnVerModelo;
            NodoProyecto.VerCodigo += OnVerCodigo;
            treeView1.Nodes.Add(NodoProyecto);
        }
        public void VerDiseñador()
        {
            NodoProyecto.VerDiseñador();
        }
        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)e.Node;
            nodo.Colapsado();

        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)e.Node;
            nodo.Expandido();
            nodo.PreparaMenu();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)e.Node;
            if (nodo == null)
                return;
            nodo.Seleccionado();

        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            Arbol.CNodoBase destino = (Arbol.CNodoBase)treeView1.GetNodeAt(targetPoint);
            Arbol.CNodoBase nodo = null;
            if (destino == null)
            {
                return;
            }
            
            nodo = (Arbol.CNodoBase)e.Data.GetData(typeof(Arbol.CNodoCapa));
            if (nodo == null)
            {
                nodo = (Arbol.CNodoBase)e.Data.GetData(typeof(Arbol.CNodoCapa));
            }
            if (nodo == null)
            {
                nodo = (Arbol.CNodoBase)e.Data.GetData(typeof(Arbol.CnodoRegion));
            }
            if (nodo == null)
            {
                nodo = (Arbol.CNodoBase)e.Data.GetData(typeof(Arbol.CNodoTabla));
            }
            if (nodo == null)
            {
                nodo = (Arbol.CNodoBase)e.Data.GetData(typeof(Arbol.CNodoTablaCapa));
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

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;

        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            // Select the node at the mouse position.
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)e.Item;
            if (nodo == null)
            {
                return;
            }
            if (nodo.GetType() == typeof(CnodoRegion) || nodo.GetType() == typeof(CNodoCapa) || nodo.GetType() == typeof(CNodoTabla) || nodo.GetType() == typeof(CNodoTablaCapa))// || nodo.GetType() == typeof(Arbol.CNodoObjetoCarpeta))
            {
                //aqui se pone lo base bueno
                DoDragDrop(nodo, DragDropEffects.Move);
            }

        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)treeView1.SelectedNode;
            nodo.KeyPress(nodo, e);

        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)treeView1.SelectedNode;
            nodo.KeyUp(nodo, e);

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)treeView1.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            nodo.PreparaMenu();

        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)treeView1.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            treeView1.SelectedNode = nodo;
            //nodo.Seleccionado();

        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Arbol.CNodoBase nodo = (Arbol.CNodoBase)e.Node;
            if (nodo != null)
                nodo.DoubleClick(e);

        }
    }
}
