using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    public class CNodoBase : TreeNode
    {
        #region menus
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        #endregion
        protected System.ComponentModel.IContainer components = null;
        private ObjetosModelo.AppModel FMOdelo;
        public int ID_Objeto
        {
            get;
            set;
        }
        public CNodoBase()
        {
            this.components = new System.ComponentModel.Container();
        }
        public virtual void Expandido()
        {
            //se sobre escibe para manejar el vento de expandido
        }
        public virtual void Colapsado()
        {
            //se sobre escibe para manejar el vento de colapsado

        }
        public virtual void RefreshData()
        {
            //se debe de sustituir para manejarlo por separado
        }
        public virtual void ModeloAsignado()
        {
            //se debe de sustituir para manejarlo por separado
        }
        public virtual void Seleccionado()
        {
            //se llama cuando el usuario lo selecciona
        }
        /// <summary>
        /// agrega un item al menu del nodo
        /// </summary>
        /// <param name="nombre">nombre que se le dara al menu</param>
        /// <param name="texto">texto que mostrara el menu</param>
        /// <param name="icono">Imagen que mostrara el menu</param>
        /// <param name="funcion">funcion que se ejecutara cuando se presiione el menu</param>
        protected void AddMenuItem( string texto, string imagen, System.EventHandler funcion)
        {
            string nombre="menuItem"+(this.MenuPrinciapl.Items.Count+1).ToString();
                
            System.Windows.Forms.ToolStripMenuItem MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // propiedades del menu
            // 
            MenuItem.Image = SQLDeveloper.Modulos.ProyectAdmin.ImageManager.getImagen(imagen);
            MenuItem.Name = nombre;
            MenuItem.Size = new System.Drawing.Size(201, 22);
            MenuItem.Text = texto;
            MenuItem.Click += funcion;// new System.EventHandler(funcion);                        
            this.MenuPrinciapl.Items.Add(MenuItem);
        }
        protected void EnableMenuItem(string menu, bool enable)
        {
            foreach(System.Windows.Forms.ToolStripMenuItem MenuItem  in MenuPrinciapl.Items)
            {
                if(MenuItem.Text==menu)
                {
                    MenuItem.Enabled = enable;
                    return;
                }
            }
        }
        /// <summary>
        /// se llama cuando se quiere que los nodos agregen opciones al menu
        /// </summary>
        protected virtual void InicializaMenu()
        {
            AddMenuItem("Copiar nombre al portapapeles", "copiar", this.MenuCoiarNombre_Click);
            AddMenuItem("Buscar", "buscar", this.MenuBuscar_Click);

        }
        /// <summary>
        /// inicializa el menu
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreaMenu()
        {
            if (MenuPrinciapl != null)
                return MenuPrinciapl;
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            return MenuPrinciapl;
        }
        /// <summary>
        /// busca un texto en en los nodos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuBuscar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Text = "Buscar";
            dlg.OnNombre += new Forms.ONFormNombreEvent(BuscarNombreCarpeta);
            dlg.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool BuscarNombreCarpeta(Forms.FormNombre sender, string nombre)
        {
            BuscaNodo(nombre);
            return true;
        }
        /// <summary>
        /// copia el nombre del nodo en el portapapeles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MenuCoiarNombre_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Nombre);
        }
        /// <summary>
        /// refresca los nodos del nodo padre
        /// </summary>
        protected void RefreshParent()
        {
            CNodoBase padre = (CNodoBase)this.Parent;
            padre.RefreshData();
        }
        /// <summary>
        /// nombre del nodo
        /// </summary>
        public string Nombre
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        /// <summary>
        /// modelo
        /// </summary>
        public ObjetosModelo.AppModel Modelo
        {
            get
            {
                return FMOdelo;
            }
            set
            {
                FMOdelo = value;
                if (FMOdelo != null)
                {
                    ModeloAsignado();
                }
            }
        }

        public virtual void Monitorea()
        {
            //esta funcion debe de sobrecargarse cuando se nececite hacer una revision de los objetos 
            //que se estan monitoreando
        }
        /// <summary>
        /// prepara el menu justo antes de ser mostrado
        /// </summary>
        public void PreparaMenu()
        {
            if (ContextMenuStrip == null)
            {
                //creo el menu principal
                this.ContextMenuStrip = CreaMenu();
                //mando a que le asignen sus opciones
                InicializaMenu();
            }

        }
        public virtual void NodeDrop(CNodoBase nodo)
        {

        }
        public virtual void DoubleClick(TreeNodeMouseClickEventArgs e)
        {
            //hay que sobre escribirlo

        }
        /// <summary>
        /// busca el contenido dentro del nodo
        /// </summary>
        /// <param name="nombre"></param>
        protected void BuscaNodo(string nombre)
        {
            //veo si soy yo
            if (Nombre.ToUpper().Trim() == nombre.ToUpper().Trim())
            {
                this.TreeView.SelectedNode = this;
                ForeColor = Color.Red;
                // return;
            }
            else
            {
                ForeColor = Color.Black;
            }
            foreach (CNodoBase n in Nodes)
            {
                n.BuscaNodo(nombre);
            }
        }
        /// <summary>
        /// se usa para que libere sus recursos antes de ser eliminado
        /// </summary>
        public virtual void Free()
        {
            foreach(CNodoBase n in Nodes)
            {
                n.Free();
            }
        }
        /// <summary>
        /// regresa el nodo que tenga el id y el tipo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public CNodoBase getNodo(int id,Type tipo)
        {
            if(this.GetType()==tipo)
            {
                //soy del mismo tipo
                if(this.ID_Objeto==id)
                {
                    //tengo el mismo id, por lo que a quien buscan es a mi
                    return this;
                }
            }
            //bueco en todos mis hijos para ver si lo encuentro
            foreach(CNodoBase nodo in this.Nodes)
            {
                CNodoBase n2=nodo.getNodo(id,tipo);
                if (n2 != null)
                    return n2; //ya lo encontre
            }
            //no lo tengo yo
            return null;
        }
        public virtual void AgregaRegistrosReporte(System.Data.DataTable tabla,DataRow rp, int nivel)
        {

        }
        public virtual int calculaNivel(int n)
        {
            return n;
        }
        protected string AgregaColumna(System.Data.DataTable tabla, int nivel)
        {
            string nombreColumna = "Nivel " + nivel.ToString();
            foreach(DataColumn dc in tabla.Columns )
            {
                if(dc.ColumnName==nombreColumna)
                {
                    return nombreColumna;
                }
            }
            //no existe, por lo que lo agrego
            tabla.Columns.Add(nombreColumna);
            return nombreColumna;
        }
        protected void setAnalizador(Analizadores.IAnalizer analizer)
        {
            //me traigo el acceso al formulario
            Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
            Formularios.CProcesoAvance pa = dlg.getProcesoAvance();
            pa.Analizador = analizer;
            pa.Analiza();

        }
        /// <summary>
        /// se llama cuando se presiona una tecla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        /// <summary>
        /// se llama cuando se termina de presionar una tecla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void KeyUp(object sender, KeyEventArgs e)
        {

        }
        protected void DesmarcarTodo()
        {
            BackColor = Color.White;
            foreach(CNodoBase nodo in Nodes)
            {
                nodo.DesmarcarTodo();
            }
        }
        protected void ExpandeTodo()
        {
            Seleccionado();
            Expand();
            foreach(CNodoBase n in Nodes)
            {
                n.ExpandeTodo();
            }
        }
        protected Formularios.FormAppsAnalizer GetFormAppsAnalizer()
        {
            System.Windows.Forms.Control obj = this.TreeView;
            while (obj.GetType() != typeof(Formularios.FormAppsAnalizer))
            {
                obj = obj.Parent;
            }
            Formularios.FormAppsAnalizer form = (Formularios.FormAppsAnalizer)obj;
            return form;
        }
        protected void PausaHistoricos()
        {
            Formularios.FormAppsAnalizer f = GetFormAppsAnalizer();
            ObjetosModelo.CHistoryModel h = f.GetHistoryModel();
            h.Pausa = true;
        }
    }
}
   