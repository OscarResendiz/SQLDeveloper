using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public partial class FormLybraryGenrator : Form
    {
        CNodoProyecto Proyecto;
        private string FileName;
        Generadores.IGenradorCodigo Generador = null;
        public FormLybraryGenrator( )
        {
            InitializeComponent();
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

        private void Lista_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            if (nodo == null)
                return;
            nodo.Seleccionado();
        }

        private void Lista_MouseDown(object sender, MouseEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)Lista.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            nodo.PreparaMenu();

        }

        private void Lista_MouseUp(object sender, MouseEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)Lista.GetNodeAt(e.X, e.Y);
            if (nodo == null)
                return;
            Lista.SelectedNode = nodo;
            nodo.Seleccionado();
        }

        private void Lista_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = Lista.PointToClient(new Point(e.X, e.Y));
            CNodoBase destino = (CNodoBase)Lista.GetNodeAt(targetPoint);
            CNodoBase nodo = null;
            if (destino == null)
            {
                return;
            }
            /*
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
             */ 
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
            Lista.SelectedNode = Lista.GetNodeAt(targetPoint);
        }

        private void Lista_ItemDrag(object sender, ItemDragEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Item;
            if (nodo == null)
            {
                return;
            }
//            if (nodo.GetType() == typeof(CNodoCarpeta) || nodo.GetType() == typeof(CNodoObjeto) || nodo.GetType() == typeof(CNodoScript) || nodo.GetType() == typeof(CNodoDocument))
            {
                //aqui se pone lo base bueno
                DoDragDrop(nodo, DragDropEffects.Move);
            }
        }
        private void FormLybraryGenrator_Load(object sender, EventArgs e)
        {
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            modeloNet1.Clear();
            Lista.Nodes.Clear();
            FileName = "";
            modeloNet1.ProjectName="Sin_Nombre";
            CargaModelo();
        }

        private void BAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    modeloNet1.Clear();
                    Lista.Nodes.Clear();
                    FileName = openFileDialog1.FileName;
                    modeloNet1.FileName = FileName;
                    modeloNet1.Abrir();
//                    modeloNet1.ReadXml(FileName);                    
                    CargaModelo();
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ProjectName()
        {
            // separo el nombre delarchivo de la ruta
            string [] l=FileName.Split('\\');
            string tmp=l[l.Length-1];
            //quito la extencion
            l=tmp.Split('.');
            string tmp2=l[0];
            return tmp2;
        }
        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileName == "")
                {
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    FileName = saveFileDialog1.FileName;
                    modeloNet1.SetPropertyString("FileName", FileName);
                    modeloNet1.ProjectName=ProjectName();
                    Proyecto.Nombre = modeloNet1.ProjectName;
                    modeloNet1.FileName = FileName;
                }
                modeloNet1.Guardar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargaModelo()
        {
            Proyecto = new CNodoProyecto();
            Proyecto.Modelo = modeloNet1;
            Proyecto.Nombre = modeloNet1.ProjectName;
            Lista.Nodes.Add(Proyecto);
        }

        private void generadorCSharp1_OnFin(int maximo, int progreso, string mensaje)
        {
            Muestraprogreso(maximo, progreso, mensaje);

        }

        private void generadorCSharp1_OnInicio(int maximo, int progreso, string mensaje)
        {
            Muestraprogreso(maximo, progreso, mensaje);
        }

        private void generadorCSharp1_OnProgreso(int maximo, int progreso, string mensaje)
        {
            Muestraprogreso(maximo, progreso, mensaje);
        }
        private void Muestraprogreso(int maximo, int progreso, string mensaje)
        {
            try
            {
                Lmensaje.Text = mensaje;
                toolStripProgressBar1.Maximum = maximo;
                toolStripProgressBar1.Value = progreso;
            }
            catch(System.Exception ex)
            {
                return;
            }

        }
        private void BGenerar_Click(object sender, EventArgs e)
        {
            Generador = modeloNet1.DameGenerador();
            this.Generador.OnProgreso += new SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores.OnGenradorCodigoEvent(this.generadorCSharp1_OnProgreso);
            this.Generador.OnInicio += new SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores.OnGenradorCodigoEvent(this.generadorCSharp1_OnInicio);
            this.Generador.OnFin += new SQLDeveloper.Modulos.CSharpLibaryGenerator.Generadores.OnGenradorCodigoEvent(this.generadorCSharp1_OnFin);
            Generador.Generar();
        }
    }
}
