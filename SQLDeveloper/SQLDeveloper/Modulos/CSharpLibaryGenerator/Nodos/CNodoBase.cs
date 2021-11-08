using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CNodoBase : TreeNode
    {
        private ModeloNet FMOdelo;
        protected System.ComponentModel.IContainer components = null;
        protected System.ComponentModel.ComponentResourceManager resources;
        public CNodoBase()
        {
            this.components = new System.ComponentModel.Container();
            resources = GetResource();
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
        public ModeloNet Modelo
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
                    CargaModelo();
                }
            }
        }
        public virtual void PreparaMenu()
        {
            if (ContextMenuStrip == null)
                this.ContextMenuStrip = CreaMenu();

        }
        public virtual void NodeDrop(CNodoBase nodo)
        {

        }
        /// <summary>
        /// carga los objetos del modelo que se requieran y se llama automaticamente cuando el modelo es asignado
        /// </summary>
        public virtual void CargaModelo()
        {

        }
    }
}
