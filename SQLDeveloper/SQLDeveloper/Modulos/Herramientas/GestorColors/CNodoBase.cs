using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public delegate void ONSelectecdNodeEvent(CNodoBase nodo);
    public class CNodoBase : TreeNode
    {
        protected System.ComponentModel.IContainer components = null;
        protected System.ComponentModel.ComponentResourceManager resources;
        public event ONSelectecdNodeEvent ONSelectecdNode;
        private CControlBase FVisor; //contenedor
        private CObjetoBase FObjeto; //objeto general
        public CNodoBase()
        {
            this.components = new System.ComponentModel.Container();
            resources = GetResource();

        }
        public CControlBase Visor //contenedor
        {
            get
            {
                return FVisor;
            }
            set
            {
                FVisor = value;
                if (FVisor != null)
                {
                    FVisor.Objeto = Objeto;
                    FVisor.Recarga();
                }
            }
        }
        public CObjetoBase Objeto //objeto general
        {
            get
            {
                return FObjeto;
            }
            set
            {
                FObjeto = value;
                if (FVisor != null)
                {
                    FVisor.Objeto = Objeto;
                    FVisor.Recarga();
                }
            }
        }
        public void Seleccionado()
        {
            //se ha seleccionado el nodo
            if (ONSelectecdNode != null)
                ONSelectecdNode(this);
        }
        public virtual void Recarga()
        {
            //hay que refrescar la informacion
        }
        protected System.ComponentModel.ComponentResourceManager GetResource()
        {
            return new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
        }
        protected virtual ContextMenuStrip CreaMenu()
        {
            return null;
        }
    }
}
