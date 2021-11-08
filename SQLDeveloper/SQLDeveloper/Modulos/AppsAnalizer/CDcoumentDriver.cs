using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.AppsAnalizer
{
    public class CDcoumentDriver : Editores.IComenarioDriver
    {
        public CDcoumentDriver(int id_document,ObjetosModelo.AppModel modelo)
        {
            ID_Document = id_document;
            Modelo = modelo;
        }
        public int ID_Document
        {
            get;
            set;
        }
        public ObjetosModelo.AppModel Modelo
        {
            get;
            set;
        }
        #region implementacion de la interface IComentarioDriver
        private event Editores.IComentarioDriverEvent onDocumentChage;
        public void setDocumentChage(Editores.IComentarioDriverEvent DocumentChage)
        {
            onDocumentChage += DocumentChage;
        }
        public int getId()
        {
            return this.ID_Document;
        }
        public void setId(int id)
        {
            ID_Document = id;
        }
        public string getText()
        {
            return Modelo.GetDocumento(ID_Document).Texto;
        }
        public void setText(string texto)
        {
            ObjetosModelo.CDocumento obj = Modelo.GetDocumento(ID_Document);
            obj.Texto = texto;
            obj.update();
        }
        public void Save()
        {

        }
        public string getName()
        {
            ObjetosModelo.CDocumento obj = Modelo.GetDocumento(ID_Document);
            return obj.Nombre;
        }
        public void setName(string nombre)
        {
            ObjetosModelo.CDocumento obj = Modelo.GetDocumento(ID_Document);
            obj.Nombre = nombre;
            obj.update();
        }
        private void CodigoDocumentChange(int id_Document)
        {
            if (this.ID_Document == id_Document)
            {
                if (onDocumentChage != null)
                    onDocumentChage(this.ID_Document);
            }
        }
        #endregion
    }
}
   