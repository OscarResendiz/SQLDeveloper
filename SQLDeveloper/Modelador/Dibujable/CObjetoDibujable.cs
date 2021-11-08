using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.Dibujable
{
    public delegate void CObjetoDibujableDelegate(CObjetoDibujable sender);
    public delegate bool CObjetoDibujableDelegate2(CObjetoDibujable sender);
    public delegate void CObjetoDibujableDelegateCurdor(CObjetoDibujable sender,Cursor cursor);
    /// <summary>
    /// clase generica para objetos que representan algun objeto dentro del modelo
    /// </summary>
    public class CObjetoDibujable: CDibujable
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;

        public event CObjetoDibujableDelegate OnRedibuja;
        public event CObjetoDibujableDelegate OnMouseCapture;
        public event CObjetoDibujableDelegate OnMouseFree;
        public event CObjetoDibujableDelegate OnAddObjetc;
        public event CObjetoDibujableDelegate OnRemovebjetc;
        public event CObjetoDibujableDelegateCurdor OnChangeCursor;
        public event CObjetoDibujableDelegate2 OnEstoyAlFrente;
        private Modelo.ModeloDatos FModelo;
        private bool FMouseCapturado;
        public bool MouseCapturado
        {
            get
            {
                return FMouseCapturado;
            }
        }
        public Modelo.ModeloDatos Modelo
        {
            get
            {
                return FModelo;
            }
            set
            {
                FModelo = value;
                if(FModelo!=null)
                    ModeloAsignado();
            }
        }
        /// <summary>
        /// se llama cuando se asigna el mopdeli
        /// </summary>
        protected virtual void ModeloAsignado()
        {

        }
        /// <summary>
        /// se llama cuando se da un doble click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnDoubleClick(object sender, EventArgs e, int x, int y)
        {
            return false;
        }
        /// <summary>
        /// se llama cuando se da click con el boton de raton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseClick(object sender, MouseEventArgs e, int x, int y)
        {
            return false;
        }
        /// <summary>
        /// se ejecuta cuando se presiona el boton del raton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseDown(object sender, MouseEventArgs e, int x,int y)
        {
            return false;
        }
        /// <summary>
        /// se llama cuando el raton se mueve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseMove(object sender, MouseEventArgs e, int x, int y)
        {
            return false;
        }
        /// <summary>
        /// se llama cuando se suelta el boton del raton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseUp(object sender, MouseEventArgs e, int x, int y)
        {
            return false;
        }
        /// <summary>
        /// regresa true si las corrdenadas del raton estan dentro del objeto
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseIn(int x, int y)
        {
            return false;
        }
        /// <summary>
        /// se llama cuando se da doble click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>si regresa true significa que fue manejado y no debe propagarse</returns>
        public virtual bool OnMouseDoubleClick(object sender, MouseEventArgs e, int x, int y)
        {
            return false;
        }
        //manda a repintar la pantalla
        protected void Redibuja()
        {
            if (OnRedibuja != null)
                OnRedibuja(this);
        }
        /// <summary>
        /// toma el control de raton
        /// </summary>
        protected void CapturaMouse()
        {
            FMouseCapturado = true;
            if (OnMouseCapture != null)
                OnMouseCapture(this);
        }
        /// <summary>
        /// libera el control del raton
        /// </summary>
        protected void LiberaRaton()
        {
            FMouseCapturado = false;
            if (OnMouseFree != null)
                OnMouseFree(this);
        }
        /// <summary>
        /// agrega el objeto a la lista principal para que sea manejado por el raton
        /// </summary>
        public void AgregaObjetoControl(CObjetoDibujable obj)
        {
            if (OnAddObjetc != null)
                OnAddObjetc(obj);
        }
        /// <summary>
        /// quita el objeto del control del raton
        /// </summary>
        /// <param name="obj"></param>
        public void QuitaObjetoControl(CObjetoDibujable obj)
        {
            if (OnRemovebjetc != null)
                OnRemovebjetc(obj);
        }
        /// <summary>
        /// regresa true si el objeto es visible
        /// </summary>
        /// <returns></returns>
        public virtual bool IsVisible()
        {
            return true;
        }
        /// <summary>
        /// modifica el cursor del raton
        /// </summary>
        /// <param name="cursor"></param>
        protected void CmbiaCursor(Cursor cursor)
        {
            if (OnChangeCursor!= null)
                OnChangeCursor(this, cursor);
        }
        protected bool EstoyAlFrente()
        {
            if (OnEstoyAlFrente != null)
                return OnEstoyAlFrente(this);
            return false;
        }
        #region manejo de menus
        /// <summary>
        /// agrega un item al menu del nodo
        /// </summary>
        /// <param name="nombre">nombre que se le dara al menu</param>
        /// <param name="texto">texto que mostrara el menu</param>
        /// <param name="icono">Imagen que mostrara el menu</param>
        /// <param name="funcion">funcion que se ejecutara cuando se presiione el menu</param>
        protected void AddMenuItem(string texto, string imagen, System.EventHandler funcion)
        {
            string nombre = "menuItem" + (this.MenuPrinciapl.Items.Count + 1).ToString();

            System.Windows.Forms.ToolStripMenuItem MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // propiedades del menu
            // 
            MenuItem.Image = ImageManager.getImagen(imagen);
            MenuItem.Name = nombre;
            MenuItem.Size = new System.Drawing.Size(201, 22);
            MenuItem.Text = texto;
            MenuItem.Click += funcion;// new System.EventHandler(funcion);                        
            this.MenuPrinciapl.Items.Add(MenuItem);
        }
        protected void AddMenuSeparator()
        {
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            this.MenuPrinciapl.Items.Add(toolStripSeparator1);
        }
        protected void EnableMenuItem(string menu, bool enable)
        {
            foreach (System.Windows.Forms.ToolStripMenuItem MenuItem in MenuPrinciapl.Items)
            {
                if (MenuItem.Text == menu)
                {
                    MenuItem.Enabled = enable;
                    return;
                }
            }
        }
        /// <summary>
        /// se llama cuando se quiere que los nodos agregen opciones al menu
        /// </summary>
        protected virtual void InicializaMenu(int x,int y)
        {
//            AddMenuItem("Copiar nombre al portapapeles", "copiar", this.MenuCoiarNombre_Click);
            //            AddMenuItem("Buscar", "buscar", this.MenuBuscar_Click);

        }
        /// <summary>
        /// inicializa el menu
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreaMenu(System.ComponentModel.IContainer container)
        {
            if (MenuPrinciapl != null)
                return MenuPrinciapl;
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(container);
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            return MenuPrinciapl;
        }
        public virtual ContextMenuStrip PreparaMenu(System.ComponentModel.IContainer container, int x, int y)
        {
            if (MenuPrinciapl == null)
            {
                //creo el menu principal
                 CreaMenu(container);
            }
            if(MenuPrinciapl.Items.Count==0)
            {
                //mando a que le asignen sus opciones
                InicializaMenu(x, y);
            }
            return MenuPrinciapl;
        }

        #endregion
    }
}
