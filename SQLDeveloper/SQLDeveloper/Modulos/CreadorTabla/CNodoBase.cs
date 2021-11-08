using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public class CNodoBase:TreeNode
    {
        protected System.ComponentModel.IContainer components = null;
        protected System.ComponentModel.ComponentResourceManager resources;
        public CNodoBase()
        {
            this.components = new System.ComponentModel.Container();
            resources = GetResource();
            //por default creo el menu
            this.ContextMenuStrip=CreaMenu();
        }
        public virtual void Expandido()
        {
            //se sobre escibe para manejar el vento de expandido
        }
        public virtual void Colapsado()
        {
            //se sobre escibe para manejar el vento de colapsado

        }
        public virtual CVisorBase GetVisor()
        {
            //regresa el visor que se va a mostrar en el panel dechecho
            CVisorBase visor = new CVisorBase();
            //por default regresa el visor base para que no muestre nada
            return visor;
        }
        public virtual void RefreshData()
        {
            //se debe de sustituir para manejarlo por separado
        }
        protected System.ComponentModel.ComponentResourceManager GetResource()
        {
            return new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
        }
        protected virtual ContextMenuStrip CreaMenu()
        {
            return null;
        }
        protected void RefreshParent()
        {
            CNodoBase padre = (CNodoBase)this.Parent;
            padre.RefreshData();
        }
    }
}
